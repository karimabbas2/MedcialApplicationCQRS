import { UncontrolledDropdown, DropdownToggle, DropdownMenu, DropdownItem } from 'reactstrap'
import { MoreVertical, Edit, Trash, User, Mail, Phone, Cpu, HelpCircle, Compass, AlertCircle } from 'react-feather'
import { Link } from 'react-router-dom'

const Scrolling = () => {

    window.scrollTo({ top: 0, behavior: 'smooth' })
}

export const DoctorsColumns = (handleDeleteDoctor) => [
    {
        name: "#",
        width: '80px',
        selector: row => row.id.slice(1, 6)
    },
    {
        name: <span><User />Name</span>,
        selector: row => row.name,
    },
    {
        name: <span><Mail />Email</span>,
        selector: row => row.email,
    },
    {
        name: <span><Phone />Phone</span>,
        selector: row => row.phone,
    },
    // {
    //     name: <span><Cpu />Title</span>,
    //     selector: row => row.title,
    // },
    {
        name: <span><HelpCircle />Experience</span>,
        width: '135px',
        selector: row => row.experience,
    },
    {
        name: <span><Compass />Depts</span>,
        width: '100px',
        cell: row => {
            const columnsOfDepts = row.department
            // console.log(columnsOfDepts)
            var y = 0;
            return (
                <div className='d-flex'>
                    <UncontrolledDropdown size='1' className="me-2" direction='start'>
                        <DropdownToggle className='pr-1' tag='span'>
                            <MoreVertical size={30} />
                        </DropdownToggle>
                        <DropdownMenu end>

                            {columnsOfDepts !== null ?
                                <p>
                                    <DropdownItem className='h-100'>
                                        <span className='align-middle mt-50 text-success' key={y + 1}>{columnsOfDepts}</span>
                                    </DropdownItem>
                                </p>
                                :
                                <span className='align-middle mt-50 text-danger'>No departments</span>
                            }

                        </DropdownMenu>
                    </UncontrolledDropdown>
                </div>
            )
        }
    },
    {
        name: <span> <AlertCircle />Actions</span>,
        cell: row => {
            return (
                <div className='d-flex'>
                    <UncontrolledDropdown>
                        <DropdownToggle className='pr-1' tag='span'>
                            <MoreVertical size={30} />
                        </DropdownToggle>
                        <DropdownMenu end>

                            <Link to={`/admin/Dashboard/Doctor/${row.id}`}>
                                <DropdownItem onClick={Scrolling} className='w-100'>
                                    <Edit size={15} className='text-warning' />
                                    <span className='align-middle ml-50'>Edit</span>
                                </DropdownItem>
                            </Link>

                            <DropdownItem onClick={() => {
                                handleDeleteDoctor(row.id)
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