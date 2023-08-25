import React from 'react';
import useGetAll from "../../hooks/useGetAll";
import {urlBooks} from "../../urls/urlList";
import BooksList from "./BooksList";
import BooksForm from "./BooksForm";

const Books = () => {
    const [books, loading] = useGetAll(urlBooks)

    if (loading) {
        return <h3>Загрузка...</h3>
    }
    if (!books?.length) {
        return <h3>Список книг пуст</h3>
    }

    return (
        <div>
            <BooksForm books={books}/>
            <BooksList books={books}/>
        </div>
    );
};

export default Books;
