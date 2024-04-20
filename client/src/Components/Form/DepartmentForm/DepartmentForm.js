import React, { useState, useEffect } from 'react';
import * as yup from 'yup';
import { Formik, Form } from "formik"
import { useDispatch } from 'react-redux';
import { Button, Input } from 'reactstrap'
import {
    Label,
    CustomInput,
    StyledInlineErrorMessage,
    Submit,
} from "../styles";
import { addDept, updateDept } from '../../Department/store/action';

export const DepartmentForm = (props) => {

    const [deptInputs, setDeptInputs] = useState({
        name: '',
        details: ''
    })

    const dispatch = useDispatch();


    const deptInputsSchema = yup.object().shape({
        name: yup.string().required().min(3)
    })


    const resetForm = () => {
        setDeptInputs({
            name: '',
            details: ''
        });
        props.refresh()

    }

    useEffect(() => {
        if (props.selectedItem) {
            setDeptInputs({ name: props.selectedItem.name, details: props.selectedItem.details, id: props.selectedItem.id })
        }

    }, [props.selectedItem]);

    const handleData = (e) => {
        setDeptInputs({ ...deptInputs, [e.target.name]: e.target.value })
    }

    const handleSubmit = (values) => {
        if (props.selectedItem) {
            console.log(values)
            dispatch(updateDept(deptInputs))
            resetForm()

        } else {
            dispatch(addDept(deptInputs))
            resetForm()
        }

    }

    return (
        <>
            <Formik
                validationSchema={deptInputsSchema}
                initialValues={deptInputs}
                enableReinitialize={true}
                onSubmit={(values) => {
                    console.log(values)
                    handleSubmit(values);
                    resetForm();
                }}
            >
                {({ errors, touched, isValid }) => {

                    return (
                        <Form>
                            <Label htmlFor="Department Name">
                                <CustomInput
                                    name="name"
                                    type="text"
                                    onChange={handleData}
                                    value={deptInputs.name}
                                    autoCorrect="off"
                                    placeholder="Department Name"
                                    valid={touched.name && !errors.name}
                                    error={touched.name && errors.name}
                                />
                            </Label>

                            {errors.name && touched.name ? <StyledInlineErrorMessage>{errors.name}</StyledInlineErrorMessage> : null}

                            <Label htmlFor="Department Details">
                                <CustomInput
                                    name="details"
                                    type="text"
                                    autoCorrect="off"
                                    onChange={handleData}
                                    value={deptInputs.details}
                                    placeholder="Department Details"
                                    valid={touched.details && !errors.details}
                                    error={touched.details && errors.details}
                                />
                            </Label>
                            {errors.details && touched.details ? <StyledInlineErrorMessage>{errors.details}</StyledInlineErrorMessage> : null}

                            <Submit type="submit" className='btn btn-success' disabled={!isValid}>
                                save
                            </Submit>

                            <Button type="reset" className='btn btn-warning w-100 mt-2' onClick={() => { resetForm() }}>
                                Reset
                            </Button>

                        </Form>
                    )
                }
                }


            </Formik>
        </>
    )
}

