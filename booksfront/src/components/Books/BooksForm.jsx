import React, {useState} from 'react';
import useGetAll from "../../hooks/useGetAll";
import {urlAuthors, urlBooks, urlCategories} from "../../urls/urlList";
// import MySelect from "../../UI/MySelect";

const BooksForm = ({books}) => {

    const [authors, loadingAuthors] = useGetAll(urlAuthors)
    const [categories, loadingCategories] = useGetAll(urlCategories)

    //console.log('books: ', books)
    //console.log('authors: ', authors)
    //console.log('categories: ', categories)

    const [book, setBook] = useState({
        title: '',
        authors: {
            id: 0,
            firstName: '',
            lastName: ''
        },
        yearPublish: '',
        categories: {
            id: 0,
            title: ''
        },
        price: ''
    })

    const handleSaveAuthor = (event) => {
        let event_id = parseInt(event.target.value)
        const result = authors.find(a => a.id === event_id)
        setBook({
            ...book,
            authors: [{
//                ...book.authors,
                id: result.id,
                firstName: result.firstName,
                lastName: result.lastName
            }]
        })
    }

    const handleSaveCategory = (event) => {
        let event_id = parseInt(event.target.value)
        const result = categories.find(с => с.id === event_id)
        setBook({
            ...book,
            categories: [{
               // ...book.category,
                id: result.id,
                title: result.title
            }]
        })
    }

    const AddedNewBook = (event) => {
        event.preventDefault()
        const newBook = {
            ...book
        }
        create(newBook)
        alert('Запись отправлена на сервер')
        console.log('Новая книга', newBook)
        // setBook({
        //     title: '',
        //     authors: {
        //         id: 0,
        //         firstName: '',
        //         lastName: ''
        //     },
        //     yearPublish: '',
        //     category: {
        //         id: 0,
        //         title: ''
        //     },
        //     price: ''
        // })
    }

    const create = (newBook) => {
        try {
            const response = fetch(urlBooks, {
                method: "POST",
                mode: 'cors',
                body: JSON.stringify(newBook),
                headers: {
                    "Content-Type": "application/json",
                },
            });
            let json = response.json();
            console.log("Успех:", JSON.stringify(json));
        } catch (error) {
            console.error("Ошибка:", error);
        }
    }

    const optionsAuthors = authors.map((a) => {
        return (
            <option value={a.id} key={a.id}>{`${a.firstName} ${a.lastName}`}</option>
        )
    })
    const optionsCategories = categories.map((c) => {
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
                        // props={authors}
                        className='form-select'
                        value={book.authors.id}
                        key={book.authors.id}
                        onChange={handleSaveAuthor}
                    >
                        <option defaultValue selecte disabled>Выберите автора</option>
                        {optionsAuthors}
                    </select>
                </div>
                <div className='col-md-2'>
                    <select
                        className='form-select'
                        value={book.yearPublish}
                        key={book.yearPublish}
                        onChange={event => setBook({...book, yearPublish: event.target.value})}
                    >
                        <option defaultValue selected disabled>Выберите год</option>
                        {(() => {
                            const options = [];
                            const currentYear = new Date().getFullYear()
                            for (let i = currentYear; i >= 1900; i--) {
                                options.push(<option value={i}>{i}</option>);
                            }
                            return options;
                        })()}
                    </select>
                </div>
                <div className='col-md-2'>
                    <select
                        // props={authors}
                        className='form-select'
                        value={book.categories.id}
                        key={book.categories.id}
                        onChange={handleSaveCategory}
                    >
                        <option defaultValue selected disabled>Выберите категорию</option>
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
            </div>
        </div>
    );
};

export default BooksForm;