import React from 'react';
import {useParams} from "react-router-dom";
import useGetAll from "../../hooks/useGetAll";
import _ from 'lodash'
import {urlBooksById} from "../../urls/urlList";

const Book = () => {

    const params = useParams()

    const [book, loading] = useGetAll(urlBooksById + params.id)

    const categoryTitle = _.get(book, ['categories', '0', 'title'])
    const authorFirstName = _.get(book, ['authors', '0', 'firstName'])
    const authorLastName = _.get(book, ['authors', '0', 'lastName'])
    const picturePath = _.get(book, ['covers', '0', 'path'])

    return (
        <div>
            <div className="row g-0 border rounded overflow-hidden flex-md-row mb-4 shadow-sm h-md-250 position-relative">
                <div className="col p-4 d-flex flex-column position-static">
                    <strong className="d-inline-block mb-2 text-primary-emphasis">{categoryTitle}</strong>
                    <h3 className="mb-0">{book.title}</h3>
                    <div className="mb-1 text-body-secondary">Автор: {authorFirstName} {authorLastName}</div>
                    <p className="card-text mb-auto">Описание: {book.description}</p>
                    <p className="card-text mb-auto">Год издания: {book.yearPublish}</p>
                    <p className="card-text mb-auto">Цена: {book.price} руб.</p>
                </div>
                <div className="col-auto d-none d-lg-block">
                    <img className='bd-placeholder-img books-img' src={'http://localhost:5000/' + picturePath} />
                </div>
            </div>
        </div>
    );
};

export default Book;