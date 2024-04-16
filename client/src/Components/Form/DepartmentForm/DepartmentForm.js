import React, { useState, useEffect } from 'react';
import * as yup from 'yup';
import { Formik, Form, ErrorMessage } from "formik"
import { useDispatch } from 'react-redux';
import { Button } from 'reactstrap'
import {
    PageWrapper,
    Title,
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


    const deptInputsSchema = yup.object({
        name: yup.string().required("Department Name is requierd").min(3)
    })

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


    return (
        <>
            <Formik
                initialValues={deptInputs}
                validationSchema={deptInputsSchema}
                onSubmit={(values, resetForm) => {
                    handleSubmit(values);
                    resetForm();
                }} >

                {({ errors, touched, isValid }) => (

                    <Form >
                        <Label htmlFor="Department Name">
                            <CustomInput
                                name="name"
                                type="text"
                                value={deptInputs.name}
                                onInput={handleData}
                                // onChange={ handleData}
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
                                value={deptInputs.details}
                                autoCorrect="off"
                                onChange={handleData}
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
                )}

            </Formik>
        </>
    )
}

