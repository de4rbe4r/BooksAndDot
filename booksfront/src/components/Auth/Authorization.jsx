import React, {useState} from 'react';
import {useNavigate} from "react-router-dom";
import { urlAuth } from "../../urls/urlList";

import '../../styles/component/auth.css'

const Authorization = () => {

    const [user, setUser] = useState({
        email: '',
        password: ''
    })

    const handleAuthUser = (event) => {
        event.preventDefault()
        let authUser = {
            ...user
        }
        auth(authUser)
        console.log('Auth: ', authUser)
    }

    const auth = (user) => {
        const response = fetch(urlAuth, {
            method: 'POST',
            mode: "cors",
            credentials: "omit",
            body: JSON.stringify(user),
            headers: {
                'Content-type': 'application/json',
                //'Authorization': `Bearer ${jwt}`
            }
        })
        return response.json
    }

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
                    <input
                        type="email"
                        className="form-control mb-2"
                        id="floatingInput"
                        placeholder="name@example.com"
                        value={user.email}
                        onChange={event => setUser({...user, email: event.target.value})}
                    />
                        <label htmlFor="floatingInput">Введите электронную почту</label>
                </div>
                <div className="form-floating">
                    <input
                        type="password"
                        className="form-control mb-2"
                        id="floatingPassword"
                        placeholder="Password"
                        value={user.password}
                        onChange={event => setUser({...user, password: event.target.value})}
                    />
                        <label htmlFor="floatingPassword">Введите пароль</label>
                </div>
                <div className='form-btn'>
                    <button className="btn btn-outline-dark py-2 form-btn-inner" type="submit" onClick={handleAuthUser}>Войти</button>
                    <button className="btn btn-outline-danger py-2 form-btn-inner" type="submit" onClick={routeChange}>Отмена</button>
                </div>
            </form>
        </div>
    );
};

export default Authorization;