import { UncontrolledDropdown, DropdownToggle, DropdownMenu, DropdownItem } from 'reactstrap'
import { MoreVertical, Edit, Trash } from 'react-feather'
import { Link } from 'react-router-dom'
import moment from 'moment';
import { useState } from 'react';

const Scrolling = () => {

    window.scrollTo({ top: 0, behavior: 'smooth' })
}

export const DepartmentColumns = () => [
    {
        name: '#',
        selector: row => row.index,
    },
    {
        name: 'Dept Name',
        selector: row => row.name,
    },
    {
        name: 'Details',
        selector: row => row.details,
    },
    {
        name: 'Create At',
        selector: row => {
            return new Date(row.creadtedAt).toLocaleString()
        }
    },
    {
        name: 'Doctors',
        cell: row => {
            const doctors = row.doctors
            var x = 0;
            return (
                <div className='d-flex'>
                    <UncontrolledDropdown>
                        <DropdownToggle className='pr-1' tag='span'>
                            <MoreVertical size={30} />
                        </DropdownToggle>
                        <DropdownMenu end>

                            {doctors != 0 ?
                                <p>
                                    {doctors.map((doctor) => (
                                        <DropdownItem className='h-100'>
                                            <span className='align-middle mt-50 text-success' key={x + 1}>{doctor}</span>
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