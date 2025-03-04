import { Button } from 'reactstrap'
import { Link } from 'react-router-dom'

// import '@styles/base/pages/page-misc.scss'
const NoMatch = () => {

    return (
        <div className='misc-wrapper'>

            <div className='misc-inner p-2 p-sm-3'>
                <div className='w-100 text-center'>
                    <h2 className='mb-1'>Page Not Found 🕵🏻‍♀️</h2>
                    <p className='mb-2'>Oops! 😖 The requested URL was not found on this server.</p>
                    <Button tag={Link} to='/' color='primary' className='btn-sm-block mb-2'>
                        Back to home
                    </Button>
                </div>
            </div>
        </div>
    )
};

export default NoMatch;