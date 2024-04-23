import * as api from "../../../../api/index";
import { DepartmentColumns } from "../../list";
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

export const getAllDepts = (handleDeleteDept) => {
    const DeptColumns = DepartmentColumns(handleDeleteDept);

    return async dispatch => {

        dispatch({
            type: 'SET_LOADING'
        })
        await api.GetAllDepts().then((response) => {
            const data = response.data.result;
            dispatch({
                type: 'Get_All_Deparments',
                data,
                columns: DeptColumns
            })
            dispatch({
                type: 'UNSET_LOADING'
            })
        }).catch((err) => {
            console.log(err);
        });

    }
}


export const deleteDept = (id) => async (dispatch) => {
    await api.DeleteDept(id).then(res => {
        if (res.status === 200) {
            if (res.data.statusCode === 200) {
                MySwal.fire({
                    icon: 'success',
                    title: 'Deleted!',
                    text: 'Your department has been deleted.',
                    customClass: {
                        confirmButton: 'btn btn-success'
                    }
                })
                dispatch({
                    type: 'Delete_Dept',
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
        MySwal.fire({
            icon: 'error',
            title: 'Faild!',
            text: `Faild to delete , Bad Request , ${err.response.data.title}`,
            customClass: {
                confirmButton: 'btn btn-danger'
            }
        })
        return 'error'
    })
}

export const addDept = (dept) => {
    return async dispatch => {
        await api.PostDept(dept).then((res) => {
            if (res.status === 201) {
                MySwal.fire({
                    icon: 'success',
                    title: 'New Item !',
                    text: 'department has benn created Successfully.',
                    customClass: {
                        confirmButton: 'btn btn-success'
                    }
                })
                const data = res.data.result;
                console.log(data)
                dispatch({
                    type: 'Add_New_Dept',
                    data,
                })
            }
        }).catch((err) => {
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


export const updateDept = (dept) => {
    return async dispatch => {
        await api.UpdateDept(dept).then((res) => {
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
                    type: 'Update_Dept',
                    data,
                })
            }
        }).catch((err) => {
            MySwal.fire({
                icon: 'error',
                title: 'Faild!',
                text: `Faild to Modifay , Bad Request , ${err.response.data.title}`,
                customClass: {
                    confirmButton: 'btn btn-danger'
                }
            })
            return 'error'
        })
    }
}

