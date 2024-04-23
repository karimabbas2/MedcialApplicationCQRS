import React from 'react';
import MyNavbar from '../Navbar';
import Cards from '../Cards';

const Header = () => {

    const user = localStorage.getItem("UserToken");

    return (
        <>
            <MyNavbar user={user} />
            <Cards />
        </>
    );
};

export default Header;