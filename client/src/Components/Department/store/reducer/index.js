const initialState = {
    data: [],
    columns: [],
    loading: false,
    sellectedDept: {},
};

const DepartmentsStore = (state = initialState, action) => {
    switch (action.type) {
        case 'Get_All_Deparments':
            return { ...state, data: action.data, columns: action.columns}
        case 'SET_LOADING':
            return { ...state, loading: true }
        case 'UNSET_LOADING':
            return { ...state, loading: false }
        default:
            return { ...state };
    }

}
export default DepartmentsStore;