import { React } from 'react';
import { Link } from 'react-router-dom';
import {
    Nav,
    NavItem,
    NavLink,
    UncontrolledDropdown,
    DropdownToggle,
    DropdownMenu,
    DropdownItem,
} from 'reactstrap';


const MyNavbar = () => {


    return (
        <>
            <Nav justified pills tabs>
                <NavItem>
                    <Link to="/Doctor">Doctor</Link>
                </NavItem>

                <NavItem>
                    <Link to="/Department">Department</Link>
                </NavItem>

                <NavItem>
                    <Link to="/Appointment"> Appointment </Link>
                </NavItem>

                <NavItem>
                    <UncontrolledDropdown nav inNavbar>
                        <DropdownToggle nav caret>
                            Options
                        </DropdownToggle>
                        <DropdownMenu end>
                            <DropdownItem>Option 1</DropdownItem>
                            <DropdownItem>Option 2</DropdownItem>
                            <DropdownItem divider />
                            <DropdownItem>Reset</DropdownItem>
                        </DropdownMenu>
                    </UncontrolledDropdown>
                </NavItem>
            </Nav>
        </>
    );
};

export default MyNavbar;