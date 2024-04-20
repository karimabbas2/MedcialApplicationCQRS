import React from 'react';

import {
    PageWrapper,
    Title,
} from "./styles";

import { DepartmentForm } from './DepartmentForm/DepartmentForm';
import DoctorForm from './DoctorForm/DoctorForm';
import AppointmentForm from './AppointmentForm/AppointmentForm';

const MyForm = (props) => {

    const handleForm = (name) => {
        if (name === 'Doctor')
            return DoctorForm
        else if (name === 'Department')
            return DepartmentForm
        else if (name === 'Appointment')
            return AppointmentForm

    }
    const FormComponent = handleForm(props.name);

    return (
        <>
            <PageWrapper className='mb-5' >
                <Title >{props.formName}</Title>
                <hr />
                <FormComponent selectedItem={props.selectedItem} refresh={props.refresh} />
            </PageWrapper>

        </>
    );
};

export default MyForm;