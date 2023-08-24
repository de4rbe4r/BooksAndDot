import React from "react";
import useGetAllBooks from "./hooks/useGetAllBooks";
import { urlBooks } from "./urls/urlList";

function App() {

    const [books, loading] = useGetAllBooks(urlBooks)

    if (loading) {
        return <h3>Загрузка...</h3>
    }
    if (!books?.length) {
        return <h3>Список книг не загрузился</h3>
    }

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
