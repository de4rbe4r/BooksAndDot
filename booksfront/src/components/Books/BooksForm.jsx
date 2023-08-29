import React, {useState} from 'react';
import useGetAll from "../../hooks/useGetAll";
import {urlAuthors, urlBooks, urlCategories} from "../../urls/urlList";

const BooksForm = ({books}) => {

    const [authors, loadingAuthors] = useGetAll(urlAuthors)
    const [categories, loadingCategories] = useGetAll(urlCategories)

    const [book, setBook] = useState({
        title: '',
        authorId: '',
        year: '',
        categoryId: '',
        price: ''
    })

    const AddedNewBook = (event) => {
        event.preventDefault()
        const newBook = {
            id: Date.now(),
            ...book
        }
        create(newBook)
        console.log('Новая книга', newBook)
        setBook({
            title: '',
            authorId: '',
            year: '',
            categoryId: '',
            price: ''
        })
    }

    // const create = (newBook) => {
    //     try {
    //         const response = fetch(urlBooks, {
    //             method: "POST",
    //             mode: 'cors',
    //             body: JSON.stringify(newBook),
    //             headers: {
    //                 "Content-Type": "application/json",
    //             },
    //         });
    //         // const json = response.json();
    //         // console.log("Успех:", JSON.stringify(json));
    //     } catch (error) {
    //         console.error("Ошибка:", error);
    //     }
    // }

    const optionsAuthors = authors.map((a, index) => {
        return (
            <option value={a.id} key={a.id}>{`${a.firstName} ${a.lastName}`}</option>
        )
    })
    const optionsCategories = categories.map((c, index) => {
        return (
            <option value={c.id} key={c.id}>{c.title}</option>
        )
    })

    return (
        <div>
            <h3>Добавить книгу</h3>
            <div className='row'>
                <div className='col-md-3'>
                    <input
                        className='form-control'
                        type="text"
                        placeholder='Введите название'
                        value={book.title}
                        onChange={event => setBook({...book, title: event.target.value})}
                    />
                </div>
                <div className='col-md-3'>
                    <select
                        className='form-select'
                        defaultValue='Выберите автора'
                        value={book.authorId}
                        onChange={event => setBook({...book, authorId: event.target.value})}
                    >
                        <option disabled>Выберите автора</option>
                        {optionsAuthors}
                    </select>
                </div>
                <div className='col-md-2'>
                    <input
                        className='form-control'
                        type="number"
                        placeholder='Введите год издания'
                        value={book.year}
                        onChange={event => setBook({...book, year: event.target.value})}
                    />
                </div>
                <div className='col-md-2'>
                    <select
                        className='form-select'
                        defaultValue='Выберите категорию'
                        value={book.categoryId}
                        onChange={event => setBook({...book, categoryId: event.target.value})}
                    >
                        <option disabled>Выберите категорию</option>
                        {optionsCategories}
                    </select>
                </div>
                <div className='col-md-2'>
                    <input
                        className='form-control'
                        type="number"
                        placeholder='Введите цену'
                        value={book.price}
                        onChange={event => setBook({...book, price: event.target.value})}
                    />
                </div>
                <div>
                    <button
                        type='submit'
                        title='Сохранить книгу'
                        className='btn btn-primary'
                        onClick={AddedNewBook}
                    >
                        <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor"
                             className="bi bi-plus-square" viewBox="0 0 16 16">
                            <path d="M14 1a1 1 0 0 1 1 1v12a1 1 0 0 1-1 1H2a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1h12zM2 0a2 2 0 0 0-2 2v12a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2H2z"/>
                            <path d="M8 4a.5.5 0 0 1 .5.5v3h3a.5.5 0 0 1 0 1h-3v3a.5.5 0 0 1-1 0v-3h-3a.5.5 0 0 1 0-1h3v-3A.5.5 0 0 1 8 4z"/>
                        </svg>
                        &nbsp;
                        Добавить
                    </button>
                </div>
                <div className='col-md-2'>
                    <button type='submit'
                        className='btn btn-success'
                        title='Сохранить книгу'
                        onClick=''>+
                    </button>
                </div>
            </div>
        </div>
    );
};

export default BooksForm;