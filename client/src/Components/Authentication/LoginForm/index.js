import { Form, Formik } from 'formik';
import React, { useState } from 'react';
import { useDispatch } from 'react-redux';
import { useNavigate } from 'react-router-dom';
import { Col, Row } from 'reactstrap';
import * as yup from 'yup';
import {
    Label,
    CustomInput,
    StyledInlineErrorMessage,
    Submit,
} from "../../Form/styles.js";
import { login } from '../store/action/index.js';

const LoginForm = () => {

    const dispatch = useDispatch();
    const navigate = useNavigate();

    const [loginInput, setLoginInput] = useState({
        email: '',
        password: '',
    });

    const LoginInInputs = yup.object({
        email: yup.string().required("Email is requierd").email("please inter valid email"),
        password: yup.string().required("Password is required"),
    })

    const handleData = (e) => {
        setLoginInput({ ...loginInput, [e.target.name]: e.target.value })
    }

    const handleSubmit = (values) => {
        console.log(loginInput);
        dispatch(login(loginInput))
        resetForm();
    }

    const resetForm = () => {
        setLoginInput({
            email: '',
            password: '',
        });
        navigate("/admin")
    }

    return (

        <>
            <Formik
                validationSchema={LoginInInputs}
                initialValues={loginInput}
                enableReinitialize={true}
                onSubmit={(values) => {
                    handleSubmit(values);
                    resetForm();
                }}
            >
                {({ errors, touched, isValid }) => {

                    return (
                        <div className='w-50 mb-5 m-auto p-5'>
                            <h5>Welcome To Medical App </h5>
                            <Form>
                                <Row xs={12}>
                                    <Col xs={6}>
                                        <Label htmlFor="email">
                                            <CustomInput
                                                name="email"
                                                type="email"
                                                autoCorrect="off"
                                                onChange={handleData}
                                                value={loginInput.email}
                                                placeholder="email"
                                                valid={touched.email && !errors.email}
                                                error={touched.email && errors.email}
                                            />
                                        </Label>
                                        {errors.email && touched.email ? <StyledInlineErrorMessage>{errors.email}</StyledInlineErrorMessage> : null}

                                    </Col>
                                    <Col xs={6}>
                                        <Label htmlFor="password">
                                            <CustomInput
                                                name="password"
                                                type="text"
                                                autoCorrect="off"
                                                onChange={handleData}
                                                value={loginInput.password}
                                                placeholder="password"
                                                valid={touched.password && !errors.password}
                                                error={touched.password && errors.password}
                                            />
                                        </Label>
                                        {errors.password && touched.password ? <StyledInlineErrorMessage>{errors.password}</StyledInlineErrorMessage> : null}
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

export default LoginForm;