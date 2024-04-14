const initialState = {
    data: [],
    columns: [],
    loading: false,
    sellectedDept: {},
};

const AppointmentStore = (state = initialState, action) => {
    switch (action.type) {
        case 'Get_All_Appointments':
            return { ...state, data: action.data, columns: action.columns}
        case 'SET_LOADING':
            return { ...state, loading: false }
        case 'UNSET_LOADING':
            return { ...state, loading: false }
        default:
            return { ...state };
    }

}
export default AppointmentStore;