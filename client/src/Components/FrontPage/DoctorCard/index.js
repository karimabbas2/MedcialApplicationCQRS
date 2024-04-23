import React, { useState } from 'react';
import img3 from '../../../assets/images/avatars/12-small.png';
import { CardTitle } from 'reactstrap';
import { HardDrive, Home, Mail, Paperclip, Phone } from 'react-feather';
import { Button, Modal, ModalHeader, ModalBody, ModalFooter } from 'reactstrap';
import AppointmentForm from '../../Form/AppointmentForm/AppointmentForm';

const DoctorCard = (props) => {

    const [modal, setModal] = useState(false);
    const toggle = () => setModal(!modal);
    console.log(props.id)

    return (
        <>
            <div class="card mb-4 box-shadow">

                <img src={img3} className="rounded-circle" width={90} />
                <div class="card-body">
                    <CardTitle><Paperclip /> Name : {props.name}</CardTitle>
                    <CardTitle><Phone /> phone : {props.phone}</CardTitle>
                    <CardTitle><Mail /> Email : {props.email}</CardTitle>
                    <CardTitle><HardDrive /> Experience : {props.experience}</CardTitle>
                    <CardTitle><Home />Education : {props.education}</CardTitle>
                    <pre />
                    <div class="d-flex justify-content-between align-items-center">
                        <div class="btn-group">
                            <button type="button" class="btn btn-sm btn-outline-secondary">Details</button>
                            <button type="button" class="btn btn-sm btn-outline-secondary ms-2" onClick={toggle}>Appointment</button>

                        </div>
                        <small class="text-muted">Fee : <span className='badge bg-danger'>{props.fee} EGP</span> </small>
                    </div>
                </div>
            </div>

            <Modal isOpen={modal} toggle={toggle}>
                <ModalHeader toggle={toggle}>Modal title</ModalHeader>
                <ModalBody>
                    <h5>Your Appointment with <span className=' badge bg-success'>{props.name}</span> need to Fullup Form</h5>
                    <AppointmentForm doctorId={props.id} />
                </ModalBody>
            </Modal>
        </>
    );
};

export default DoctorCard;