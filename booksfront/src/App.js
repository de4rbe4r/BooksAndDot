import logo from './logo.svg';
import './App.css';
import React, {useEffect, useState} from "react";

function App() {

    let baseUrl = 'http://localhost:5000/api/Books';

    const [books, setBooks] = useState([])

    useEffect(() => {
        (async () => {
            const data = await fetch(baseUrl)
                .then(res => res.json())
            setBooks(data)
        })()
    }, [])

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
                <tbody>
                {
                    books.map((b, index) => (
                        <tr key={b.id}>
                            <td>{index + 1}</td>
                            <td>{b.author}</td>
                            <td>{b.title}</td>
                            <td>{b.price}</td>
                            <td>{b.categories}</td>
                        </tr>
                    ))
                }
                </tbody>
            </table>
      </div>
  );
}

export default App;
