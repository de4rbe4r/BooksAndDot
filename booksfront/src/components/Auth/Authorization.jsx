import React from 'react';

import '../../styles/component/auth.css'
import {useNavigate} from "react-router-dom";

const Authorization = () => {

    // отмена авторизации - редирект на главную страницу
    let navigate = useNavigate()
    const routeChange = () => {
        let path = '/'
        navigate(path)
    }

    return (
        <div className='w-50 m-auto'>
            <form>
                <h1 className="h3 mb-3 fw-normal text-center">Авторизуйтесь</h1>
                <div className="form-floating">
                    <input type="email" className="form-control mb-2" id="floatingInput" placeholder="name@example.com" />
                        <label htmlFor="floatingInput">Введите электронную почту</label>
                </div>
                <div className="form-floating">
                    <input type="password" className="form-control mb-2" id="floatingPassword" placeholder="Password" />
                        <label htmlFor="floatingPassword">Введите пароль</label>
                </div>
                <div className='form-btn'>
                    <button className="btn btn-outline-dark py-2 form-btn-inner" type="submit">Войти</button>
                    <button className="btn btn-outline-danger py-2 form-btn-inner" type="submit" onClick={routeChange}>Отмена</button>
                </div>
            </form>
        </div>
    );
};

export default Authorization;