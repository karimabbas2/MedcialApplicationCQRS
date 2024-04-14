import * as api from "../../../../api/index";
import { DoctorsColumns } from "../../list";
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

export const getAllDoctors = (handleDeleteDoctor) => {
    const DoctColumns = DoctorsColumns(handleDeleteDoctor);
    return async dispatch => {
        dispatch({
            type: 'SET_LOADING'
        })
        await api.GetAllDoctors().then((response) => {

            const data = response.data.result;
            dispatch({
                type: 'Get_All_Doctors',
                data,
                columns: DoctColumns

            })
            dispatch({
                type: 'UNSET_LOADING'
            })
        }).catch((err) => {
            console.log(err);
        });
    }
}

export const addDoctor = (doc) => {
    return async dispatch => {
        await api.PostDoctor(doc).then((res) => {
            if (res.status === 201) {
                MySwal.fire({
                    icon: 'success',
                    title: 'New Item !',
                    text: 'Doctor has benn created Successfully.',
                    customClass: {
                        confirmButton: 'btn btn-success'
                    }
                })
                const data = res.data.result;
                console.log(data)
                dispatch({
                    type: 'Add_New_Doctor',
                    data,
                })
            }
        }).catch((err) => {
            // console.log(err.response.data.title)
            MySwal.fire({
                icon: 'error',
                title: 'Faild!',
                text: `Faild to Create , Bad Request , ${err.response.data.title}`,
                customClass: {
                    confirmButton: 'btn btn-danger'
                }
            })
            return 'error'
        })
    }
}

export const deleteDoctor = (id) => async (dispatch) => {
    await api.DeleteDoctor(id).then(res => {
        if (res.status === 200) {
            if (res.data.statusCode === 200) {
                MySwal.fire({
                    icon: 'success',
                    title: 'Deleted!',
                    text: 'Doctor has been deleted.',
                    customClass: {
                        confirmButton: 'btn btn-success'
                    }
                })
                dispatch({
                    type: 'Delete_Doctor',
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
    }).catch(() => {
        MySwal.fire({
            icon: 'error',
            title: 'Faild!',
            text: 'Faild to delete , Bad Request',
            customClass: {
                confirmButton: 'btn btn-danger'
            }
        })
        return 'error'
    })
}