import { React, useEffect } from 'react';
import MyNavbar from '../Navbar';
import { useNavigate, useParams } from 'react-router-dom';
import Aboute from '../Aboute/Aboute';
import FrontPage from '../FrontPage/FrontPage';
import Footer from '../Footer';
import RegisterForm from '../Authentication/RegisterForm';
import LoginForm from '../Authentication/LoginForm';

const Layout = () => {

    let { name } = useParams();
    const user = localStorage.getItem("UserToken");

    const handleBody = (name) => {
        if (name === 'aboute')
            return Aboute
        else if (name === 'register')
            return RegisterForm
        else if (name === 'login')
            return LoginForm
        else {
            return FrontPage
        }
    }


    const FormComponent = handleBody(name);
    return (

        <>
            <MyNavbar user={user} />
            <FormComponent />
            <Footer />
        </>
    );
};

export default Layout;