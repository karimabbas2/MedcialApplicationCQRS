import { UncontrolledDropdown, DropdownToggle, DropdownMenu, DropdownItem } from 'reactstrap'
import { MoreVertical, Edit, Trash, pic, User, Paperclip, Clock, Users, AlertCircle } from 'react-feather'
import { Link } from 'react-router-dom'

const Scrolling = () => {

    window.scrollTo({ top: 0, behavior: 'smooth' })
}

export const DepartmentColumns = (handleDelete) => [
    {
        name: '#',
        selector: row => row.id.slice(1, 6),
    },
    {
        name: <span><User />Name</span>,
        selector: row => row.name,
    },
    {
        name: <span><Paperclip />Details</span>,
        selector: row => row.details,
    },
    {
        name: <span><Clock />Created At</span>,
        selector: row => {
            return new Date(row.creadtedAt).toLocaleString()
        }
    },
    {
        name: <span><Users />Doctors</span>,
        cell: row => {
            const columnsOfDoctors = row.doctors
            // console.log(columnsOfDoctors)

            var x = 0;
            return (
                <div className='d-flex'>
                    <UncontrolledDropdown size='1' className="me-2" direction='start'>
                        <DropdownToggle className='pr-1' tag='span'>
                            <MoreVertical size={30} />
                        </DropdownToggle>
                        <DropdownMenu end>

                            {columnsOfDoctors != 0 || null ?
                                <p>
                                    {columnsOfDoctors.map((doc) => (
                                        <DropdownItem className='h-100'>
                                            <span className='align-middle mt-50 text-success' key={x + 1}>{doc}</span>
                                        </DropdownItem>
                                    ))}
                                </p>
                                :
                                <span className='align-middle mt-50 text-danger'>No Doctors</span>
                            }

                        </DropdownMenu>
                    </UncontrolledDropdown>
                </div>
            )
        }
    },
    {
        name: <span> <AlertCircle/>Actions</span>,
        cell: row => {
            return (
                <div className='d-flex'>
                    <UncontrolledDropdown>
                        <DropdownToggle className='pr-1' tag='span'>
                            <MoreVertical size={30} />
                        </DropdownToggle>
                        <DropdownMenu end>

                            <Link to={`/admin/Dashboard/Department/${row.id}`}>
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