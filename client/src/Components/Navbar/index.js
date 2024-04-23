import React, { useState, useEffect } from 'react';
import { useDispatch } from 'react-redux';
import { Link, useNavigate } from 'react-router-dom';

import { LOGOUT } from '../Authentication/store/action';

const MyNavbar = (props) => {

    const dispatch = useDispatch();
    const navigate = useNavigate();

    console.log(props.user)

    const Logout = () => {
        dispatch(LOGOUT())
        navigate("/")
    }


    return (
        <nav class="navbar navbar-expand-lg navbar-light bg-light ">
            <Link class="navbar-brand" to="/">Medical App</Link>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNavDropdown" aria-controls="navbarNavDropdown" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarNavDropdown">
                <ul class="navbar-nav">
                    <li class="nav-item active">
                        <Link class="nav-link" to="/admin"><span class="sr-only">Dashboard</span></Link>
                    </li>
                    <li class="nav-item">
                        <Link class="nav-link" to="/aboute">Aboute</Link>
                    </li>
                    <li class="nav-item">
                        <Link class="nav-link" to="/aboute">Contact Us</Link>
                    </li>
                </ul>
            </div>

            <ul className="navbar-nav ">

                {props.user === null ?
                    <>

                        <li class="nav-item">
                            <Link class="btn btn-outline-success " to="/login">Sign In</Link>
                        </li>
                        <li class="nav-item ms-1">
                            <Link class="btn btn-outline-dark" to="/register">Sign Up</Link>
                        </li>
                    </>
                    :
                    <li class="nav-item">
                        <button class="btn btn-outline-danger" onClick={Logout}>LogOut</button>
                    </li>
                }

            </ul>
        </nav>
    );
}

export default MyNavbar;