import { UncontrolledDropdown, DropdownToggle, DropdownMenu, DropdownItem, FormGroup, Input, Label } from 'reactstrap'
import { MoreVertical, Edit, Trash, Check } from 'react-feather'
import { Link } from 'react-router-dom'


const Scrolling = () => {

    window.scrollTo({ top: 0, behavior: 'smooth' })
}

export const AppoinmtnetColumns = () => [
    {
        name: '#',
        selector: row => row.id.slice(1,6),
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
        name: 'Email',
        selector: row => row.patientEmail,
    },
    {
        name: 'Doctor',
        selector: row => row.doctor,
    },
    {
        name: 'Status',
        selector: row => {
            return (
                <>
                    <FormGroup switch>
                        <Input size={4} type="switch" checked role="switch" />
                    </FormGroup>
                </>
            )
        },
    },
    {
        name: 'Resevtion Date',
        selector: row => {
            return new Date(row.resevtionDate).toLocaleString()
        }
    },
    {
        name: 'Notes',
        cell: row => {
            return (
                <div className='d-flex'>
                    <UncontrolledDropdown size='1' className="me-2" direction='start'>
                        <DropdownToggle className='pr-1' tag='span'>
                            <MoreVertical size={30} />
                        </DropdownToggle>
                        <DropdownMenu end>
                            <span className='align-middle mt-50 text-danger'>{row.patientNotes}</span>
                        </DropdownMenu>
                    </UncontrolledDropdown>
                </div>
            )
        }
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

                            <Link to={`/show_department/${row.id}`}>
                                <DropdownItem onClick={Scrolling} className='w-100'>
                                    <Edit size={15} className='text-warning' />
                                    <span className='align-middle ml-50'>Edit</span>
                                </DropdownItem>
                            </Link>

                            <DropdownItem onClick={() => {
                                // handleDelete({id: row.id})
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