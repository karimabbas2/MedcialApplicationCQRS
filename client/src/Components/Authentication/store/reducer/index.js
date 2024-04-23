const initialState = {
    data: [],
    loading: false,
};

const AuthStore = (state = initialState, action) => {
    switch (action.type) {
        case 'Register':
            return { ...state, data: action.data }

        case 'Login':
            localStorage.setItem('UserToken', action?.token)
            localStorage.setItem('RefreshToken', action?.refreshToken)
            localStorage.setItem('UserProfile', JSON.stringify({ ...action?.user }))

            return { ...state, data: action.user }

        case 'Logout':
            localStorage.clear();
            return { ...state, data: null }

        case 'SET_LOADING':
            return { ...state, loading: true }

        case 'UNSET_LOADING':
            return { ...state, loading: false }

        default:
            return { ...state };
    }

}
export default AuthStore;