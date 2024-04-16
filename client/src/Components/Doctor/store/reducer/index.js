const initialState = {
    data: [],
    columns: [],
    loading: false,
    selectedItem: {}
};

const DoctorsStore = (state = initialState, action) => {
    switch (action.type) {
        case 'Get_All_Doctors':
            return { ...state, data: action.data, columns: action.columns }
        case 'Add_New_Doctor':
            let allData = state.data
            const item = action.data
            allData.unshift(item)
            return { ...state, data: allData }
        case 'Delete_Doctor':
            let result = state.data.filter((x) => x.id !== action.id)
            return { ...state, data: result }
        case 'Get_Doctor':
            const dept = state.data.filter((x) => x.id === action.id)
            return { ...state, selectedItem: dept[0] }
        case 'Update_Doctor':
            const UpdatedData = state.data.map((dept) => dept.id === action.data.id ? action.data : dept)
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
export default DoctorsStore;