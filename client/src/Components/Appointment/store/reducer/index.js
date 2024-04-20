const initialState = {
    data: [],
    columns: [],
    loading: false,
    sellectedDept: {},
};

const AppointmentStore = (state = initialState, action) => {
    switch (action.type) {
        case 'Get_All_Appointments':
            return { ...state, data: action.data, columns: action.columns }

        case 'Add_New_Appointment':
            let allData = state.data
            const item = action.data
            allData.unshift(item)
            return { ...state, data: allData }

        case 'Delete_Appointment':
            let result = state.data.filter((x) => x.id !== action.id)
            return { ...state, data: result }

        case 'Get_Appointment':
            const getappointment = state.data.filter((x) => x.id === action.id)
            return { ...state, selectedItem: getappointment[0] }

        case 'Update_Appointment':
            const UpdatedData = state.data.map((appointment) => appointment.id === action.data.id ? action.data : appointment)
            console.log(UpdatedData)
            return { ...state, data: UpdatedData }

        case 'SET_LOADING':
            return { ...state, loading: true }

        case 'UNSET_LOADING':
            return { ...state, loading: false }

        default:
            return { ...state };
    }

}
export default AppointmentStore;