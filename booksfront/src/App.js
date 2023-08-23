import logo from './logo.svg';
import './App.css';
import React, {useEffect, useState} from "react";
import { getAllBooks } from './data'

function App() {

    const [books, setBooks] = useState([])

    useEffect(() => {
        setBooks(getAllBooks)
    }, [])

    //console.log('books: ', books)

    return (
        <div className="container">
            <div className="display-3">Список книг</div>
            <table className="table">
                <thead>
                    <tr>
                        <th>#</th>
                        <th>Автор</th>
                        <th>Книга</th>
                        <th>Цена</th>
                        <th>Жанр</th>
                    </tr>
                </thead>
            </table>
      </div>
  );
}

export default App;
