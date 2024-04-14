import * as api from "../../../../api/index";
import { AppoinmtnetColumns } from "../../list";

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

export const getAllAppoint = () => {
    const AppointmentColumns = AppoinmtnetColumns();
    return async dispatch => {

        dispatch({
            type: 'SET_LOADING'
        })

        await api.GetAllAppointments().then((response) => {
            
            dispatch({
                type: 'UNSET_LOADING'
            })
            const data = response.data.result;
            console.log(data)
            dispatch({
                type: 'Get_All_Appointments',
                data,
                columns: AppointmentColumns
            })

        }).catch((err) => {
            console.log(err);
        });

    }
}

