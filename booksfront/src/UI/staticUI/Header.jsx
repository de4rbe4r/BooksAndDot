import React from 'react';

import '../../styles/UI/header.css'
import {NavLink} from "react-router-dom";

const Header = () => {
    return (
        <header className='container'>
            <div className='row'>
                <div className='col-md-11'>
                    <h1 className='header-title'>Books and Dots</h1>
                </div>
                <div className='col-md-auto pt-2'>
                    <NavLink className='btn btn-outline-dark' to="/auth">
                        Войти
                    </NavLink>
                </div>
            </div>
            <hr/>
        </header>
    );
};

export default Header;