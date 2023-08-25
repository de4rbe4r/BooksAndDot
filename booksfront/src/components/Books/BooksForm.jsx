import React from 'react';
import useGetAllBooks from "../../hooks/useGetAllBooks";
import { urlAuthors } from "../../urls/urlList";

const BooksForm = ({books}) => {

    const [authors, loading] = useGetAllBooks(urlAuthors)
    
    // const options = authors.map((author, index) => {
    //     return <option value={author.value} key={author.id}>{author.firstName}</option>
    // })

    return (
        <div>
            <h3>Добавить книгу</h3>
            <div className='row'>
                <div className='col-md-3'>
                    <input className='form-control' type="text" placeholder='Введите название'/>
                </div>
                <div className='col-md-3'>
                    <input className='form-control' type='text' placeholder='Введите ФИО автора'/>
                </div>
                <div className='col-md-2'>
                    <input className='form-control' type="number" placeholder='Введите год издания'/>
                </div>
                <div className='col-md-2'>
                    <input className='form-control' type="text" placeholder='Введите категорию'/>
                </div>
                <div className='col-md-2'>
                    <input className='form-control' type="number" placeholder='Введите цену'/>
                </div>
            </div>
        </div>
    );
};

export default BooksForm;