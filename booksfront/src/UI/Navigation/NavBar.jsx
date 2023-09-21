import React from 'react';
import {NavLink} from "react-router-dom";

const NavBar = () => {
    return (
        <nav className="nav nav-underline justify-content-between mb-2">
            <NavLink className='nav-item nav-link link-body-emphasis' to="/">
                Главная
            </NavLink>
            <NavLink className='nav-item nav-link link-body-emphasis' to="/books">
                Каталог книг
            </NavLink>
            <NavLink className='nav-item nav-link link-body-emphasis' to="/shops">
                Магазины
            </NavLink>
            <NavLink className='nav-item nav-link link-body-emphasis' to="/cart">
                Корзина
            </NavLink>
            <NavLink className='nav-item nav-link link-body-emphasis' to="/auth">
                Авторизация
            </NavLink>
        </nav>
    );
};

export default NavBar;