import React from 'react';
import { useNavigate } from 'react-router-dom';

const Appointment = () => {

    const user = localStorage.getItem("UserToken");
    const navigate = useNavigate();

    return (
        <>
            {user !== null ?
                <p>hello</p>
                :
                <h5>Please</h5>
            }
        </>
    );
};

export default Appointment;