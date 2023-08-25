import React from 'react';
import useGetAllBooks from "../../hooks/useGetAllBooks";
import {urlBooks} from "../../urls/urlList";
import BooksList from "./BooksList";

const Books = () => {
    const [books, loading] = useGetAllBooks(urlBooks)

    if (loading) {
        return <h3>Загрузка...</h3>
    }
    if (!books?.length) {
        return <h3>Список книг не загрузился</h3>
    }
    console.log(books);

    return (
        <div>
            <BooksList books={books}/>
        </div>
    );
};

export default Books;
