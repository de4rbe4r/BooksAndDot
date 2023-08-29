import React from 'react';
import useGetAll from "../../hooks/useGetAll";
import { urlAuthors, urlCategories } from "../../urls/urlList";

const BooksForm = ({books}) => {

    const [authors, loadingAuthors] = useGetAll(urlAuthors)
    const [categories, loadingCategories] = useGetAll(urlCategories)

    const optionsAuthors = authors.map((a, index) => {
        return (
            <option value={`${a.firstName} ${a.lastName}`} key={a.id}>{`${a.firstName} ${a.lastName}`}</option>
        )
    })
    const optionsCategories = categories.map((c, index) => {
        return (
            <option value={c.title} key={c.id}>{c.title}</option>
        )
    })

    return (
        <div>
            <h3>Добавить книгу</h3>
            <div className='row'>
                <div className='col-md-3'>
                    <input className='form-control' type="text" placeholder='Введите название'/>
                </div>
                <div className='col-md-3'>
                    <select className='form-select' defaultValue='Выберите автора'>
                        <option disabled>Выберите автора</option>
                        {optionsAuthors}
                    </select>
                </div>
                <div className='col-md-2'>
                    <input className='form-control' type="number" placeholder='Введите год издания'/>
                </div>
                <div className='col-md-2'>
                    <select className='form-select' defaultValue='Выберите категорию'>
                        <option disabled>Выберите категорию</option>
                        {optionsCategories}
                    </select>
                </div>
                <div className='col-md-2'>
                    <input className='form-control' type="number" placeholder='Введите цену'/>
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