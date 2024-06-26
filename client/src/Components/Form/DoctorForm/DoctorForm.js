import React, { useEffect, useState } from 'react';
import * as yup from 'yup';
import {
    Label,
    CustomInput,
    StyledInlineErrorMessage,
    Submit,
} from "../styles";
import { Form, Formik } from 'formik';
import { Button, Col, Row, Input } from 'reactstrap';
import { useDispatch, useSelector } from 'react-redux';
import { addDoctor, updateDoctor } from '../../Doctor/store/action';
import { getAllDepts } from '../../Department/store/action';

const DoctorForm = (props) => {

    const dispatch = useDispatch();
    const AllDepts = useSelector(state => state.DepartmentsStore);

    const [doctorInputs, setDoctorInputs] = useState({
        name: '',
        surname: '',
        title: '',
        description: '',
        education: '',
        experience: '',
        fee: '',
        phone: '',
        email: '',
        imageURL: '',
        department: ''
    })

    const docInputsSchema = yup.object().shape({
        name: yup.string().required("Doctor Name is requierd").min(3),
        title: yup.string().required("Title is Requierd").min(3),
        phone: yup.number().required("Phone is Requierd").min(3),
        email: yup.string().email().required("Email is requierd"),
        fee: yup.number().required("Fee is requierd")
    })

    const handleData = (e) => {
        setDoctorInputs({ ...doctorInputs, [e.target.name]: e.target.value })
    }

    const resetForm = () => {
        setDoctorInputs({
            name: '',
            surname: '',
            title: '',
            description: '',
            education: '',
            experience: '',
            fee: '',
            phone: '',
            email: '',
            imageURL: '',
            department: '',
            DepartmentID: ''
        });
        props.refresh()
    }

    useEffect(() => {
        dispatch(getAllDepts())
    }, [dispatch]);


    useEffect(() => {
        if (props.selectedItem) {
            setDoctorInputs({
                id: props.selectedItem.id,
                name: props.selectedItem.name,
                surname: props.selectedItem.surname,
                title: props.selectedItem.title,
                description: props.selectedItem.description,
                education: props.selectedItem.education,
                experience: props.selectedItem.experience,
                fee: props.selectedItem.fee,
                phone: props.selectedItem.phone,
                email: props.selectedItem.email,
                imageURL: props.selectedItem.imageURL,
                department: props.selectedItem.department,
                departmentID: props.selectedItem.departmentID
            })
        }

    }, [props.selectedItem]);

    const handleSubmit = (values) => {
        if (props.selectedItem) {
            dispatch(updateDoctor(doctorInputs))
            resetForm();
        } else {
            dispatch(addDoctor(doctorInputs))
            resetForm();
        }
    }

    return (
        <>
            <Formik
                initialValues={doctorInputs}
                validationSchema={docInputsSchema}
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
                                    name="name"
                                    type="text"
                                    value={doctorInputs.name}
                                    onChange={handleData}
                                    autoCorrect="off"
                                    placeholder="Doctor Name"
                                    valid={touched.name && !errors.name}
                                    error={touched.name && errors.name}
                                />
                                {errors.name && touched.name ? <StyledInlineErrorMessage>{errors.name}</StyledInlineErrorMessage> : null}

                            </Col>

                            <Col xs="6">
                                <CustomInput
                                    name="surname"
                                    type="text"
                                    value={doctorInputs.surname}
                                    onChange={handleData}
                                    autoCorrect="off"
                                    placeholder="Doctor Surname"
                                    valid={touched.surname && !errors.surname}
                                    error={touched.surname && errors.surname}
                                />
                                {errors.surname && touched.surname ? <StyledInlineErrorMessage>{errors.surname}</StyledInlineErrorMessage> : null}

                            </Col>
                        </Row>

                        <Row>
                            <Col xs="6">
                                <Label htmlFor="Title">
                                    <CustomInput
                                        name="title"
                                        type="text"
                                        value={doctorInputs.title}
                                        onChange={handleData}
                                        autoCorrect="off"
                                        placeholder="Doctor Title"
                                        valid={touched.title && !errors.title}
                                        error={touched.title && errors.title}
                                    />
                                </Label>
                                {errors.title && touched.title ? <StyledInlineErrorMessage>{errors.title}</StyledInlineErrorMessage> : null}

                            </Col>

                            <Col xs="6">
                                <Label htmlFor="Education">
                                    <CustomInput
                                        name="education"
                                        type="text"
                                        value={doctorInputs.education}
                                        onChange={handleData}
                                        autoCorrect="off"
                                        placeholder="Doctor Education"
                                        valid={touched.education && !errors.education}
                                        error={touched.education && errors.education}
                                    />
                                </Label>
                                {errors.education && touched.education ? <StyledInlineErrorMessage>{errors.education}</StyledInlineErrorMessage> : null}

                            </Col>

                        </Row>

                        <Row>
                            <Col xs="6">
                                <Label htmlFor="Experience">
                                    <CustomInput
                                        name="experience"
                                        type="text"
                                        value={doctorInputs.experience}
                                        onChange={handleData}
                                        autoCorrect="off"
                                        placeholder="Doctor Experience"
                                        valid={touched.experience && !errors.experience}
                                        error={touched.experience && errors.experience}
                                    />
                                </Label>
                                {errors.experience && touched.experience ? <StyledInlineErrorMessage>{errors.experience}</StyledInlineErrorMessage> : null}

                            </Col>
                            <Col xs="6">
                                <Label htmlFor="Phone">
                                    <CustomInput
                                        number
                                        name="phone"
                                        type="text"
                                        value={doctorInputs.phone}
                                        onChange={handleData}
                                        autoCorrect="off"
                                        placeholder="Doctor Phone"
                                        valid={touched.phone && !errors.phone}
                                        error={touched.phone && errors.phone}
                                    />
                                </Label>
                                {errors.phone && touched.phone ? <StyledInlineErrorMessage>{errors.phone}</StyledInlineErrorMessage> : null}

                            </Col>
                        </Row>

                        <Row>
                            <Col xs="6">
                                <Label htmlFor="Email">
                                    <CustomInput
                                        email
                                        name="email"
                                        type="email"
                                        value={doctorInputs.email}
                                        onChange={handleData}
                                        autoCorrect="off"
                                        placeholder="Doctor Email"
                                        valid={touched.email && !errors.email}
                                        error={touched.email && errors.email}
                                    />
                                </Label>
                                {errors.email && touched.email ? <StyledInlineErrorMessage>{errors.email}</StyledInlineErrorMessage> : null}

                            </Col>

                            <Col xs="6">
                                <Label htmlFor="Fee">
                                    <CustomInput
                                        name="fee"
                                        type="number"
                                        value={doctorInputs.fee}
                                        onChange={handleData}
                                        autoCorrect="off"
                                        placeholder="Doctor Fee"
                                        valid={touched.fee && !errors.fee}
                                        error={touched.fee && errors.fee}
                                    />
                                </Label>
                                {errors.fee && touched.fee ? <StyledInlineErrorMessage>{errors.fee}</StyledInlineErrorMessage> : null}

                            </Col>
                        </Row>
                        <Row className='mt-3 w-100 ms-0'>
                            <Input
                                id="exampleSelect"
                                name="departmentID"
                                type="select"
                                onChange={handleData}

                            >
                                <option value={null}>choose Department</option>
                                {AllDepts.data?.map((dept) => (

                                    <option key={dept.id} value={dept.id} selected={doctorInputs.departmentID === dept.id} >{dept.name}</option>
                                ))}
                            </Input>
                        </Row>


                        <Row>
                            <Label htmlFor="Description">
                                <CustomInput
                                    name="description"
                                    type="text"
                                    value={doctorInputs.description}
                                    onChange={handleData}
                                    autoCorrect="off"
                                    placeholder="Description"
                                    valid={touched.description && !errors.description}
                                    error={touched.description && errors.description}
                                />
                            </Label>
                            {errors.description && touched.description ? <StyledInlineErrorMessage>{errors.description}</StyledInlineErrorMessage> : null}

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

export default DoctorForm;