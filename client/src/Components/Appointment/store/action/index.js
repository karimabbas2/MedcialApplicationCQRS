import * as api from "../../../../api/index";
import { AppoinmtnetColumns } from "../../list";
import Swal from 'sweetalert2'
import withReactContent from 'sweetalert2-react-content'

const MySwal = withReactContent(Swal)


export const setLoading = () => {
    return async dispatch => {
        dispatch({
            type: 'SET_LOADING'
        })
    }
}

export const unSetLoading = () => {
    return async dispatch => {
        dispatch({
            type: 'UNSET_LOADING'
        })
    }
}

export const getAllAppoint = (handleDeleteAppintment) => {
    const AppointmentColumns = AppoinmtnetColumns(handleDeleteAppintment);
    return async dispatch => {

        dispatch({
            type: 'SET_LOADING'
        })

        await api.GetAllAppointments().then((response) => {

            const data = response.data.result;
            console.log(data)
            dispatch({
                type: 'Get_All_Appointments',
                data,
                columns: AppointmentColumns
            })
            dispatch({
                type: 'UNSET_LOADING'
            })

        }).catch((err) => {
            console.log(err);
        });

    }
}

export const addAppointment = (appointment) => {
    return async dispatch => {
        await api.PostAppointment(appointment).then((res) => {
            if (res.status === 201) {
                MySwal.fire({
                    icon: 'success',
                    title: 'New Item !',
                    text: 'appointment has benn created Successfully.',
                    customClass: {
                        confirmButton: 'btn btn-success'
                    }
                })
                const data = res.data.result;
                console.log(data)
                dispatch({
                    type: 'Add_New_Appointment',
                    data,
                })
            }
        }).catch((err) => {
            const Error = err.response.data.result
            MySwal.fire({
                icon: 'error',
                title: 'Faild!',
                text: `Faild to Create , Bad Request :${Error}`,
                customClass: {
                    confirmButton: 'btn btn-danger'
                }
            })
            return 'error'
        })
    }
}

export const deleteAppointment = (id) => async (dispatch) => {
    await api.DeleteAppointment(id).then(res => {
        if (res.status === 200) {
            if (res.data.statusCode === 200) {
                MySwal.fire({
                    icon: 'success',
                    title: 'Deleted!',
                    text: 'Appointment has been deleted.',
                    customClass: {
                        confirmButton: 'btn btn-success'
                    }
                })
                dispatch({
                    type: 'Delete_Appointment',
                    id
                })
            } else {
                console.log(res)
                MySwal.fire({
                    icon: 'error',
                    title: 'Faild!',
                    text: 'Faild to delete.',
                    customClass: {
                        confirmButton: 'btn btn-danger'
                    }
                })
            }
        }
    }).catch((err) => {
        const Error = err.response.data.result
        MySwal.fire({
            icon: 'error',
            title: 'Faild!',
            text: `Faild to delete , Bad Request: ${Error}`,
            customClass: {
                confirmButton: 'btn btn-danger'
            }
        })
        return 'error'
    })
}

export const updateAppointment = (dept) => {
    return async dispatch => {
        await api.UpdateAppointment(dept).then((res) => {
            if (res.status === 200) {
                MySwal.fire({
                    icon: 'success',
                    title: 'Item Modified !',
                    text: 'Item has benn Modified Successfully.',
                    customClass: {
                        confirmButton: 'btn btn-success'
                    }
                })
                const data = res.data.result
                dispatch({
                    type: 'Update_Appointment',
                    data,
                })
            }
        }).catch(() => {
            MySwal.fire({
                icon: 'error',
                title: 'Faild!',
                text: 'Faild to Modify , Bad Request',
                customClass: {
                    confirmButton: 'btn btn-danger'
                }
            })
            return 'error'
        })
    }
}
