import React from 'react';
import { useNavigate } from "react-router-dom";
import * as api from "../../../../api/index";
import Swal from 'sweetalert2'
import withReactContent from 'sweetalert2-react-content'
const MySwal = withReactContent(Swal)


export const register = (data) => {
    return async dispatch => {
        await api.Register(data).then((res) => {
            console.log(res)
            if (res.status === 200) {
                const data = res.data.result;
                console.log(data)
                MySwal.fire({
                    icon: 'success',
                    title: 'Welcome , please Sign In !',
                    text: 'Registerd Successfully.',
                    customClass: {
                        confirmButton: 'btn btn-success'
                    }
                })
                dispatch({
                    type: 'Register',
                    data,
                })
            }
        }).catch((err) => {
            console.log(err)
            MySwal.fire({
                icon: 'error',
                title: 'Faild!',
                text: `Faild to Register, ${err.response?.data?._Message}`,
                customClass: {
                    confirmButton: 'btn btn-danger'
                }
            })
            return 'error'
        })
    }
}

export const login = (data) => {
    return async dispatch => {
        await api.LogIn(data).then((res) => {
            if (res.status === 200) {
                const token = res.data.accsessToken;
                const user = res.data.user;
                const refreshToken = res.data.refreshToken;

                MySwal.fire({
                    icon: 'success',
                    title: 'Welcome',
                    customClass: {
                        confirmButton: 'btn btn-success'
                    }
                })
                dispatch({
                    type: 'Login',
                    token,
                    user,
                    refreshToken
                })
            }
        }).catch((err) => {
            console.log(err)
            MySwal.fire({
                icon: 'error',
                title: 'Faild!',
                text: `Faild to Login, ${err.response?.data?._Message}`,
                customClass: {
                    confirmButton: 'btn btn-danger'
                }
            })
            return 'error'
        })
    }
}

export const LOGOUT = () => {
    return async dispatch => {
        dispatch({
            type: "Logout",
        });
    }
}