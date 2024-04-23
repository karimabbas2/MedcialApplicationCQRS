import React, { useEffect, useState } from 'react';
import { Card, Input } from 'reactstrap';
import { useDispatch, useSelector } from 'react-redux';
import { getAllDepts } from '../Department/store/action';
import DoctorCard from './DoctorCard';
import { getDoctorsByDept } from './Store/action';

const FrontPage = () => {

    const dispatch = useDispatch();
    const AllDepts = useSelector(state => state.DepartmentsStore);
    const result = useSelector(state => state.FrontPageStore);
    const doctors = result.data.doctors

    const [inputValue, setInputValue] = useState();

    const handleData = (e) => {
        const targetValue = { [e.target.name]: e.target.value }
        setInputValue(targetValue.departmentID)
    }

    useEffect(() => {
        dispatch(getAllDepts())
    }, [dispatch]);

    useEffect(() => {
        dispatch(getDoctorsByDept(inputValue))
    }, [dispatch, inputValue]);

    return (


        <main role="main">
            <section class="jumbotron text-center mt-5">
                <div class="container">
                    <h1 class="jumbotron-heading">Medical App</h1>
                    <p class="lead text-muted">To Find Doctors , Select Specialty</p>
                    <p>
                        <Input
                            id="exampleSelect"
                            name="departmentID"
                            type="select"
                            onChange={handleData}

                        >
                            <option value={null}>select Specialty...</option>
                            {AllDepts.data?.map((dept) => (

                                <option key={dept.id} value={dept.id} >{dept.details}</option>
                            ))}
                        </Input>
                    </p>
                </div>
            </section>

            <div class="album py-5 bg-light">
                <div class="container">
                    <div class="row">
                        {
                            doctors !== undefined && doctors !== null && doctors.length > 0 ?
                                doctors.map((doctor) => (
                                    <div key={doctor.id} class="col-md-4">
                                        <DoctorCard
                                            id={doctor.id}
                                            name={doctor.name}
                                            title={doctor.title}
                                            fee={doctor.fee}
                                            phone={doctor.phone}
                                            education={doctor.education}
                                            email={doctor.email}
                                            experience={doctor.experience}
                                        />
                                    </div>

                                ))
                                : doctors !== undefined && doctors !== null ?
                                    <span className=' badge bg-danger'>No Doctors in this Specialty yet</span>
                                    :
                                    <span className=' badge bg-info'> Select Specialty to show doctors</span>

                        }
                    </div>
                </div>
            </div>

        </main>
    );
};

export default FrontPage;