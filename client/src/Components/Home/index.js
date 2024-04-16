import { React, useEffect } from 'react';
import MyForm from '../Form';
import MyNavbar from '../../Components/Navbar/index';
import MyDataTable from '../Datatable';
import { useDispatch, useSelector } from 'react-redux';
import { Col, Row, Modal, Spinner } from 'reactstrap';
import { usename, useParams } from 'react-router-dom';
import Header from '../Header';
import Footer from '../Footer'
import { deleteDept, getAllDepts } from '../Department/store/action';
import { deleteDoctor, getAllDoctors } from '../Doctor/store/action';
import { getAllAppoint } from '../Appointment/store/action';
import Swal from 'sweetalert2'
import withReactContent from 'sweetalert2-react-content'
import { useNavigate } from "react-router-dom";


const Home = () => {

    const dispatch = useDispatch();
    const navigate = useNavigate();

    let myStore = {}

    let { name, id } = useParams();
    // console.log(name)

    switch (name) {
        case 'Department':
            // eslint-disable-next-line react-hooks/rules-of-hooks
            myStore = useSelector(state => state.DepartmentsStore);
            break;
        case 'Doctor':
            // eslint-disable-next-line react-hooks/rules-of-hooks
            myStore = useSelector(state => state.DoctorsStore);
            break;
        case 'Appointment':
            // eslint-disable-next-line react-hooks/rules-of-hooks
            myStore = useSelector(state => state.AppointmentStore);
            break;
        default:
            break;
    }


    const handleDelete = async (Id) => {
        console.log(Id)
        const MySwal = withReactContent(Swal)
        return MySwal.fire({
            title: 'Are You Sure Form Deleteing this',
            icon: 'warning',
            showCancelButton: true,
            cancelButtonText: 'Cancel',
            confirmButtonText: 'Yes !',
            customClass: {
                cancelButton: 'btn btn-outline-danger ml-1',
                confirmButton: 'btn btn-primary',
            },
            buttonsStyling: true
        }).then(() => {
            if (name === 'Department')
                dispatch(deleteDept(Id))
            else if (name === 'Doctor')
                dispatch(deleteDoctor(Id))
        })
    }

    useEffect(() => {
        if (name === 'Department') {
            dispatch(getAllDepts(handleDelete));
        }
        else if (name === 'Doctor') {
            dispatch(getAllDoctors(handleDelete));
        }
        else if (name === 'Appointment') {
            dispatch(getAllAppoint(handleDelete));
        }

    }, [name])

    useEffect(() => {
        // console.log("ok")
        dispatch({
            type: 'Get_Dept',
            id
        })
        // dispatch({
        //     type: 'Get_Doctor',
        //     id
        // })
    }, [id])

    const Refresh = () => {
        navigate(`/${name}`)
    };

    console.log(myStore)

    return (
        <>
            <Header />
            <Row className=' mt-4'>
                <Col className="bg-light border" xs="4">
                    <MyForm formName={`${name} Form`} name={name} selectedItem={myStore.selectedItem} refresh={Refresh} />
                </Col>
                <Col className="bg-light border" xs="8">

                    {myStore.loading ? (

                        <div className=' text-center p-lg-4 mt-5 b-transparent center'>
                            <Spinner color='danger custom-spinner-loading' />
                            <span>Loading Data...</span>
                        </div>
                    ) :
                        <MyDataTable columns={myStore.columns} data={myStore.data} title={name + "s"} />
                    }
                </Col>
            </Row>
            <Footer />

        </>
    )
}

export default Home;

