import { Menu, Mail } from 'react-feather'
import { NavItem, NavLink} from 'reactstrap'

const Navbar = () => {
    return (
        <>
            <ul className='nav navbar-nav align-items-center'>
                <NavItem className='mobile-menu mr-auto d-xl-none'>
                    <Menu className='ficon' />
                </NavItem>
                <NavItem className='d-block'>
                    {/* <NavLink tag={Link} to={'/apps/email'} id={'email'}> */}
                    <Mail className='ficon' />
                    {/* <UncontrolledTooltip target={'email'}>{'Email'}</UncontrolledTooltip> */}
                    {/* </NavLink> */}
                </NavItem>
            </ul>
            <div className='bookmark-wrapper d-flex align-items-center ml-auto'>
                <ul className='nav navbar-nav align-items-center'>
                    
          {/* <CustomNavbarSearch /> */}
                    <NavItem className='d-none d-lg-block'>
                        <NavLink className='nav-link-style'>
                            {/* <ThemeToggler /> */}
                        </NavLink>
                    </NavItem>
                </ul>
                {/* <NavbarBookmarks setMenuVisibility={setMenuVisibility} /> */}
            </div>
        </>
    );
};

export default Navbar;