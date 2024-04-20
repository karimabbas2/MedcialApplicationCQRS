import React, { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import {
    PageWrapper,
    Title,
    Label,
    CustomInput,
    StyledInlineErrorMessage,
    Submit,
} from "../styles";
import * as yup from 'yup';
import { Form, Formik } from 'formik';
import { Button, Col, Input, Row } from 'reactstrap';
import { addAppointment, getAllAppoint, setLoading, unSetLoading, updateAppointment } from '../../Appointment/store/action';
import { getAllDoctors } from '../../Doctor/store/action';

const AppointmentForm = (props) => {

    const dispatch = useDispatch();
    const CurrentDate = new Date().toLocaleString();
    const adllDoctors = useSelector(state => state.DoctorsStore);

    const [appointmentInput, setAppointmentInput] = useState({
        patientName: '',
        patientPhone: '',
        patientEmail: '',
        patientNotes: '',
        appointmentStatus: '',
        resevtionDate: '',
        doctorId: ''
    })
    const appointmentInputSchema = yup.object().shape({
        patientName: yup.string().required("Name is Requierd").min(3),
        patientEmail: yup.string().required("Email is Requierd").email("Invalid Email"),
        patientPhone: yup.number("Invalid Phone, enter valid numbers").required("phone is Requierd"),
        resevtionDate: yup.date().required().min(CurrentDate, "Resevtion Date Must be greater than today"),
    })

    useEffect(() => {
        dispatch(getAllDoctors())
    }, [dispatch]);

    const handleData = (e) => {
        setAppointmentInput({ ...appointmentInput, [e.target.name]: e.target.value })
    }

    const resetForm = () => {
        setAppointmentInput({
            patientName: '',
            patientPhone: '',
            patientEmail: '',
            patientNotes: '',
            appointmentStatus: '',
            resevtionDate: '',
            doctorId: ''

        });
        props.refresh()
    }

    useEffect(() => {
        if (props.selectedItem) {
            setAppointmentInput({
                id: props.selectedItem.id,
                patientName: props.selectedItem.patientName,
                patientPhone: props.selectedItem.patientPhone,
                patientEmail: props.selectedItem.patientEmail,
                patientNotes: props.selectedItem.patientNotes,
                appointmentStatus: props.selectedItem.appointmentStatus,
                resevtionDate: props.selectedItem.resevtionDate,
                doctorId: props.selectedItem.doctorId,
            })
        }

    }, [props.selectedItem]);

    const handleSubmit = (values) => {
        if (props.selectedItem) {
            dispatch(updateAppointment(appointmentInput))
            resetForm();
        } else {
            dispatch(addAppointment(appointmentInput))
            resetForm();
        }
    }
    console.log(appointmentInput)

    return (
        <>
            <Formik
                initialValues={appointmentInput}
                validationSchema={appointmentInputSchema}
                enableReinitialize={true}
                onSubmit={(values, resetForm) => {
                    handleSubmit(values);
                    resetForm();
                }} >

                {({ errors, touched, isValid }) => (

                    <Form>
                        <Row>
                            <Col xs="6">
                                <CustomInput
                                    name="patientName"
                                    type="text"
                                    value={appointmentInput.patientName}
                                    onChange={handleData}
                                    autoCorrect="off"
                                    placeholder="patient Name"
                                    valid={touched.patientName && !errors.patientName}
                                    error={touched.patientName && errors.patientName}
                                />
                                {errors.patientName && touched.patientName ? <StyledInlineErrorMessage>{errors.patientName}</StyledInlineErrorMessage> : null}
                            </Col>

                            <Col xs="6">
                                <CustomInput
                                    name="patientPhone"
                                    type="text"
                                    value={appointmentInput.patientPhone}
                                    onChange={handleData}
                                    autoCorrect="off"
                                    placeholder="patient Phone"
                                    valid={touched.patientPhone && !errors.patientPhone}
                                    error={touched.patientPhone && errors.patientPhone}
                                />
                                {errors.patientPhone && touched.patientPhone ? <StyledInlineErrorMessage>{errors.patientPhone}</StyledInlineErrorMessage> : null}

                            </Col>
                        </Row>
                        <Row>
                            <Col xs="6">
                                <CustomInput
                                    name="patientEmail"
                                    type="email"
                                    value={appointmentInput.patientEmail}
                                    onChange={handleData}
                                    autoCorrect="off"
                                    placeholder="patient Email"
                                    valid={touched.patientEmail && !errors.patientEmail}
                                    error={touched.patientEmail && errors.patientEmail}
                                />
                                {errors.patientEmail && touched.patientEmail ? <StyledInlineErrorMessage>{errors.patientEmail}</StyledInlineErrorMessage> : null}
                            </Col>

                            <Col xs="6" className='mt-3'>
                                <Input
                                    id="exampleSelect"
                                    name="appointmentStatus"
                                    type="select"
                                    onChange={handleData}
                                >
                                    <option value='Waiting'>Waiting</option>
                                    <option value='Ended'>Ended</option>

                                </Input>

                            </Col>
                        </Row>

                        <Row className='mt-3 w-100 ms-0'>

                            <Input
                                id="exampleSelect"
                                name="resevtionDate"
                                type="datetime-local"
                                value={appointmentInput.resevtionDate}
                                onChange={handleData}
                                valid={touched.resevtionDate && !errors.resevtionDate}
                                error={touched.resevtionDate && errors.resevtionDate}
                            />
                            {errors.resevtionDate && touched.resevtionDate ? <StyledInlineErrorMessage>{errors.resevtionDate}</StyledInlineErrorMessage> : null}

                        </Row>
                        <Row className='mt-3 w-100 ms-0'>
                            <Input
                                id="exampleSelect"
                                name="doctorId"
                                type="select"
                                onChange={handleData}
                            >
                                <option value={null}>choose Doctor</option>
                                {adllDoctors.data?.map((doc) => (
                                    <option key={doc.id} value={doc.id} selected={appointmentInput.doctorId === doc.id} >{doc.name}</option>
                                ))}
                            </Input>
                        </Row>
                        <Row className='mt-3 w-100 ms-0'>

                            <CustomInput
                                name="patientNotes"
                                type="text"
                                value={appointmentInput.patientNotes}
                                onChange={handleData}
                                autoCorrect="off"
                                placeholder="patient Notes"
                                valid={touched.patientNotes && !errors.patientNotes}
                                error={touched.patientNotes && errors.patientNotes}
                            />
                            {errors.patientNotes && touched.patientNotes ? <StyledInlineErrorMessage>{errors.patientNotes}</StyledInlineErrorMessage> : null}

                        </Row>

                        <Submit type="submit" className='btn btn-success' disabled={!isValid}>
                            save
                        </Submit>

                        <Button type="reset" className='btn btn-warning w-100 mt-2' onClick={() => { resetForm() }}>
                            Reset
                        </Button>

                    </Form>
                )}

            </Formik>
        </>
    );
};

export default AppointmentForm;