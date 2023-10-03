import React, {useEffect, useState} from 'react';
import {NavLink} from "react-router-dom";

import '../../styles/UI/header.css'

const Header = () => {

    const [login, setLogin] = useState(false)
    const [userName, setUserName] = useState('')

    // не корректно работает обновление данных на странице - ИСПРАВИТЬ
    useEffect(() => {
        if (sessionStorage.length !== 0) {
            setLogin(true)
            setUserName(sessionStorage.getItem('userName').toString())
        }
    },[])

    const logout = () => {
        sessionStorage.clear()
    }

    return (
        <header className='container'>
            <div className='row'>
                <div className='col-md-10'>
                    <h1 className='header-title'>Books and Dots</h1>
                </div>
                <div className='col-md-auto pt-2'>
                    {
                        (login === true)
                            ? <><p>{userName}</p><button className='btn btn-outline-dark' onClick={logout}>Выйти</button></>
                            : <NavLink className='btn btn-outline-dark' to="/auth">Войти</NavLink>
                    }
                </div>
            </div>
            <hr/>
        </header>
    );
};

export default Header;