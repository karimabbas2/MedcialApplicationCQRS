import * as api from "../../../../api/index";
import { DepartmentColumns } from "../../list";

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

export const getAllDepts = () => {
    const DeptColumns = DepartmentColumns();
    return async dispatch => {

        dispatch({
            type: 'SET_LOADING'
        })

        const response = await api.GetAllDepts();
        const data = response.data.result;
        // console.log(data.result);
        dispatch({
            type: 'Get_All_Deparments',
            data,
            columns: DeptColumns
        })
        dispatch({
            type: 'UNSET_LOADING'
        })
    }
}

