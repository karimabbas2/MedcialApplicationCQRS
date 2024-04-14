import React from 'react';
import { Link } from 'react-router-dom';
import { Card, CardGroup, CardBody, CardTitle, CardSubtitle, CardText, Button } from 'reactstrap'
const Cards = () => {

    return (
        <>
            <CardGroup className=' mt-4'>
                <Card outline>
                    <CardBody>
                        <CardTitle tag="h5">
                            Card title
                        </CardTitle>
                        <CardSubtitle
                            className="mb-2 text-muted"
                            tag="h6"
                        >
                            Card subtitle
                        </CardSubtitle>
                        <CardText>
                            This is a wider card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.
                        </CardText>
                        <Link to="/Doctor">
                            <Button className='btn btn-success'>Doctors</Button>
                        </Link>

                    </CardBody>
                </Card>
                <Card>
                    <CardBody>
                        <CardTitle tag="h5">
                            Card title
                        </CardTitle>
                        <CardSubtitle
                            className="mb-2 text-muted"
                            tag="h6"
                        >
                            Card subtitle
                        </CardSubtitle>
                        <CardText>
                            This card has supporting text below as a natural lead-in to additional content.
                        </CardText>
                        <Link to="/Department">
                            <Button className='btn btn-danger'>Departments</Button>
                        </Link>
                    </CardBody>
                </Card>
                <Card>
                    <CardBody>
                        <CardTitle tag="h5">
                            Card title
                        </CardTitle>
                        <CardSubtitle
                            className="mb-2 text-muted"
                            tag="h6"
                        >
                            Card subtitle
                        </CardSubtitle>
                        <CardText>
                            This is a wider card with supporting text below as a natural lead-in to additional content. This card has even longer content than the first to show that equal height action.
                        </CardText>
                        <Link to="/Appointment">
                            <Button className=' btn btn-warning'>Appointments</Button>
                        </Link>
                    </CardBody>
                </Card>
            </CardGroup>
        </>
    );
};

export default Cards;