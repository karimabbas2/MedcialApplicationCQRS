import { UncontrolledDropdown, DropdownToggle, DropdownMenu, DropdownItem, FormGroup, Input, Label } from 'reactstrap'
import { MoreVertical, Edit, Trash, Check } from 'react-feather'
import { Link } from 'react-router-dom'


const Scrolling = () => {

    window.scrollTo({ top: 0, behavior: 'smooth' })
}

export const AppoinmtnetColumns = (handleDelete) => [
    {
        name: '#',
        width: '80px',
        selector: row => row.id.slice(1, 6),
    },
    {
        name: 'Patient',
        selector: row => row.patientName,
    },
    {
        name: 'Phone',
        selector: row => row.patientPhone,
    },
    {
        name: 'Doctor',
        selector: row => row.doctorName,
    },
    {
        name: 'Resevtion Date',
        width: '190px',
        selector: row => {
            return new Date(row.resevtionDate).toLocaleString()
        }
    },
    {
        name: 'Status',
        selector: row => {
            const status = row.appointmentStatus
            return (
                <>
                    {status === 0 ? <span className=' text-danger'>Waiting</span> :
                        <span className=' text-success'>Ended</span>
                    }
                </>
            )
        },
    },

    {
        name: 'Actions',
        cell: row => {
            return (
                <div className='d-flex'>
                    <UncontrolledDropdown>
                        <DropdownToggle className='pr-1' tag='span'>
                            <MoreVertical size={30} />
                        </DropdownToggle>
                        <DropdownMenu end>

                            <Link to={`/admin/Dashboard/Appointment/${row.id}`}>
                                <DropdownItem onClick={Scrolling} className='w-100'>
                                    <Edit size={15} className='text-warning' />
                                    <span className='align-middle ml-50'>Edit</span>
                                </DropdownItem>
                            </Link>

                            <DropdownItem onClick={() => {
                                handleDelete(row.id)
                            }} className='w-100'>
                                <Trash size={15} className=' text-danger' />
                                <span className='align-middle ml-50'>Delete</span>
                            </DropdownItem>
                        </DropdownMenu>
                    </UncontrolledDropdown>
                </div>
            )
        }
    }
]