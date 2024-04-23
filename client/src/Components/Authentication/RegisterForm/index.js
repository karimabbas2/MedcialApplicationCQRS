import { Form, Formik } from 'formik';
import React, { useState } from 'react';
import * as yup from 'yup';
import {
    Label,
    CustomInput,
    StyledInlineErrorMessage,
    Submit,
} from "../../Form/styles.js";
import { Col, Row } from 'reactstrap';
import { useDispatch } from 'react-redux';
import { register } from '../store/action/index.js';
import { useNavigate } from 'react-router-dom';


const RegisterForm = () => {

    const dispatch = useDispatch();
    const navigate = useNavigate();

    const [userInput, setUserInput] = useState({
        fullName: '',
        email: '',
        phoneNumber: '',
        password: '',
        confirmPassword: ''
    });

    const RegisterInputs = yup.object({
        fullName: yup.string().required("FullName is requierd"),
        email: yup.string().required("Email is requierd").email("please inter valid email"),
        phoneNumber: yup.number("please valid number").required("Phone number is requierd"),
        password: yup.string().required("Password is required").min(5, "Password must be at least 8 characters long"),
        confirmPassword: yup.string().required("Confirm Passwords is Requried").oneOf([yup.ref('password'), null], 'Passwords must match')
    })

    const handleData = (e) => {
        setUserInput({ ...userInput, [e.target.name]: e.target.value })
    }

    const handleSubmit = (values) => {
        console.log(userInput);
        dispatch(register(userInput))
        resetForm();
    }

    const resetForm = () => {
        setUserInput({
            fullName: '',
            email: '',
            phoneNumber: '',
            password: '',
            confirmPassword: ''
        });
        navigate("/login")
    }

    return (
        <>
            <Formik
                validationSchema={RegisterInputs}
                initialValues={userInput}
                enableReinitialize={true}
                onSubmit={(values) => {
                    handleSubmit(values);
                    resetForm();
                }}
            >
                {({ errors, touched, isValid }) => {

                    return (
                        <div className='w-50 mb-5 m-auto p-5'>
                            <h5>Welcome To Medical App, <span className=' badge bg-success'>plesse full up the form </span> </h5>
                            <Form>
                                <Label htmlFor="Full Name">
                                    <CustomInput
                                        name="fullName"
                                        type="text"
                                        onChange={handleData}
                                        value={userInput.fullName}
                                        autoCorrect="off"
                                        placeholder="fullName"
                                        valid={touched.fullName && !errors.fullName}
                                        error={touched.fullName && errors.fullName}
                                    />
                                </Label>

                                {errors.fullName && touched.fullName ? <StyledInlineErrorMessage>{errors.fullName}</StyledInlineErrorMessage> : null}

                                <Row xs={12}>
                                    <Col xs={6}>
                                        <Label htmlFor="email">
                                            <CustomInput
                                                name="email"
                                                type="email"
                                                autoCorrect="off"
                                                onChange={handleData}
                                                value={userInput.email}
                                                placeholder="email"
                                                valid={touched.email && !errors.email}
                                                error={touched.email && errors.email}
                                            />
                                        </Label>
                                        {errors.email && touched.email ? <StyledInlineErrorMessage>{errors.email}</StyledInlineErrorMessage> : null}

                                    </Col>

                                    <Col xs={6}>
                                        <Label htmlFor="phoneNumber">
                                            <CustomInput
                                                name="phoneNumber"
                                                type="text"
                                                autoCorrect="off"
                                                onChange={handleData}
                                                value={userInput.phoneNumber}
                                                placeholder="phoneNumber"
                                                valid={touched.phoneNumber && !errors.phoneNumber}
                                                error={touched.phoneNumber && errors.phoneNumber}
                                            />
                                        </Label>
                                        {errors.phoneNumber && touched.phoneNumber ? <StyledInlineErrorMessage>{errors.phoneNumber}</StyledInlineErrorMessage> : null}

                                    </Col>
                                </Row>
                                <Row>
                                    <Col xs={6}>
                                        <Label htmlFor="password">
                                            <CustomInput
                                                name="password"
                                                type="text"
                                                autoCorrect="off"
                                                onChange={handleData}
                                                value={userInput.password}
                                                placeholder="password"
                                                valid={touched.password && !errors.password}
                                                error={touched.password && errors.password}
                                            />
                                        </Label>
                                        {errors.password && touched.password ? <StyledInlineErrorMessage>{errors.password}</StyledInlineErrorMessage> : null}
                                    </Col>
                                    <Col xs={6}>
                                        <Label htmlFor="confirmPassword">
                                            <CustomInput
                                                name="confirmPassword"
                                                type="text"
                                                autoCorrect="off"
                                                onChange={handleData}
                                                value={userInput.confirmPassword}
                                                placeholder="confirmPassword"
                                                valid={touched.confirmPassword && !errors.confirmPassword}
                                                error={touched.confirmPassword && errors.confirmPassword}
                                            />
                                        </Label>
                                        {errors.confirmPassword && touched.confirmPassword ? <StyledInlineErrorMessage>{errors.confirmPassword}</StyledInlineErrorMessage> : null}

                                    </Col>
                                </Row>

                                <Submit type="submit" className='btn btn-success' disabled={!isValid}>
                                    save
                                </Submit>

                                {/* <Button type="reset" className='btn btn-warning w-100 mt-2' onClick={() => { resetForm() }}>
                                Reset
                            </Button> */}

                            </Form>
                        </div>
                    )
                }}
            </Formik>
        </>
    );
};

export default RegisterForm;