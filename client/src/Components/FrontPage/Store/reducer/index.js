const initialState = {
    data: [],
    loading: false,
};

const FrontPageStore = (state = initialState, action) => {
    switch (action.type) {
        case 'Get_Doctors_By_DEPT':
            return { ...state, data: action.data }

        case 'SET_LOADING':
            return { ...state, loading: true }

        case 'UNSET_LOADING':
            return { ...state, loading: false }

        default:
            return { ...state };

    }
}
export default FrontPageStore