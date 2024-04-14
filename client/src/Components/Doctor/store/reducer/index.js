const initialState = {
    data: [],
    columns: [],
    loading: false,
    selectedItem: null
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
        case 'SET_LOADING':
            return { ...state, loading: true }
        case 'UNSET_LOADING':
            return { ...state, loading: false }
        default:
            return { ...state };
    }

}
export default DoctorsStore;