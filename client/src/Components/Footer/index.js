import React from 'react';
import { Heart } from 'react-feather'
import { Card, CardImg, CardImgOverlay, CardTitle, CardText } from 'reactstrap'

const Footer = () => {
    return (
        <div className='mt-5 bg-secondary'>
            <p className='clearfix mb-0'>
                <span className='float-md-left d-block d-md-inline-block mt-25'>
                    COPYRIGHT © {new Date().getFullYear()}{' '}

                    <span className='d-none d-sm-inline-block'>, All rights Reserved</span>
                </span>
                <span className='float-md-right d-none d-md-block'>
                    Hand-crafted & Made with
                    <Heart size={14} />
                </span>
            </p>

        </div>
    );
};

export default Footer;