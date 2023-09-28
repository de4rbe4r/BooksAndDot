import React from 'react';
import useGetAll from "../../hooks/useGetAll";
import {urlBooks} from "../../urls/urlList";
import '../../styles/component/booksImg.css'

const BooksCardList = () => {

    const [books, loading] = useGetAll(urlBooks)
    console.log('books ', books)

    if (loading) {
        return <h3>Загрузка...</h3>
    }
    if (!books?.length) {
        return <h3>Список книг пуст</h3>
    }

    return (
        <div className="row mb-2">
            {
                books.map(b => (
                    <div className="col-md-6">
                        <div className="row g-0 border rounded overflow-hidden flex-md-row mb-4 shadow-sm h-md-250 position-relative">
                            <div className="col p-4 d-flex flex-column position-static">
                                <strong className="d-inline-block mb-2 text-primary-emphasis">{b.categories.map(c => (c.title))}</strong>
                                <h3 className="mb-0">{b.title}</h3>
                                <div className="mb-1 text-body-secondary">Автор: {b.authors.map(a => (`${a.firstName} ${a.lastName}`)) }</div>
                                <p className="card-text mb-auto">Описание: {b.description}</p>
                                <p className="card-text mb-auto">Год издания: {b.yearPublish}</p>
                                <a href="#" className="icon-link gap-1 icon-link-hover stretched-link">
                                    Читать далее
                                </a>
                            </div>
                            <div className="col-auto d-none d-lg-block">
                                <img className='bd-placeholder-img books-img' src={'http://localhost:5000/' + b.covers.map(cov => (cov.path))} />
                            </div>
                        </div>
                    </div>
                ))
            }
        </div>
    );
};

export default BooksCardList;