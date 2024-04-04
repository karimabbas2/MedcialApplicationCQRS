import React from 'react';
import { useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { getAllDepts } from './store/action';
import { Badge, Spinner } from 'reactstrap'
import { Col, Modal, Row } from 'reactstrap/lib';
import MyDataTable from '../Datatable';
import MyForm from '../Form';

const Department = () => {

    const dispatch = useDispatch();

    useEffect(() => {
        dispatch(getAllDepts());
    }, [dispatch])

    const deptStore = useSelector((state) => state.DepartmentsStore);
    const allDepts = deptStore.data;
    console.log(deptStore)

    console.log(deptStore.loading)


    return (
        <>
            {deptStore.loading ? (

                <div className='w-100 h-100 p-0 m-0 b-transparent'>
                    loading...
                </div>
            ) :
                <Row>
                    <Col sm={"12"}>
                        <Col sm={"12"}>
                            <MyDataTable columns={deptStore.columns} data={allDepts} title='Departments' />
                        </Col>
                    </Col>
                </Row>
            }
        </>
    );
};

export default Department;