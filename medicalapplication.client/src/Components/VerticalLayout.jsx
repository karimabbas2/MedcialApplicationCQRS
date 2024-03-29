import { useState, useEffect } from 'react'

// ** Third Party Components
import classnames from 'classnames'
import { Navbar } from 'reactstrap'

const VerticalLayout = () => {
    // ** Props

    // ** States
    const [isMounted, setIsMounted] = useState(false)
    const [menuVisibility, setMenuVisibility] = useState(false)
    const [windowWidth, setWindowWidth] = useState(window.innerWidth)


    const handleWindowWidth = () => {
        setWindowWidth(window.innerWidth)
    }

    // ** Vars


    //** This function will detect the Route Change and will hide the menu on menu item click
    useEffect(() => {
        if (menuVisibility && windowWidth < 1200) {
            setMenuVisibility(false)
        }
    }, [location])

    //** Sets Window Size & Layout Props
    useEffect(() => {
        if (window !== undefined) {
            window.addEventListener('resize', handleWindowWidth)
        }
    }, [windowWidth])

    //** ComponentDidMount
    useEffect(() => {
        setIsMounted(true)
        return () => setIsMounted(false)
    }, [])


    if (!isMounted) {
        return null
    }
    return (
        <div
        >
            {/* {!isHidden ? (
          <SidebarComponent
            skin={skin}
            menu={menu}
            menuCollapsed={menuCollapsed}
            menuVisibility={menuVisibility}
            setMenuCollapsed={setMenuCollapsed}
            setMenuVisibility={setMenuVisibility}
            routerProps={routerProps}
            currentActiveItem={currentActiveItem}
          />
        ) : null} */}
            <Navbar
                expand='lg'
                className={classnames(
                    `header-navbar navbar align-items-center 'floating-nav' navbar-shadow`
                )}
            >
                <div className='navbar-container d-flex content'>
                </div>
            </Navbar>

            <div
                className={classnames('sidenav-overlay', {
                    show: menuVisibility
                })}
                onClick={() => setMenuVisibility(false)}
            ></div>

            <footer
                className={classnames('footer footer-light footer-static')}>

            </footer>


        </div>
    )
}

export default VerticalLayout
