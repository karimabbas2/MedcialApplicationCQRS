import * as api from "../../../../api/index";

export const getDoctorsByDept = (id) => {

    return async dispatch => {

        dispatch({
            type: 'SET_LOADING'
        })
        await api.GetDept(id).then((response) => {
            const data = response.data.result;
            dispatch({
                type: 'Get_Doctors_By_DEPT',
                data,
            })
            dispatch({
                type: 'UNSET_LOADING'
            })
        }).catch((err) => {
            console.log(err);
        });

    }
}