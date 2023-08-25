import React from 'react';

const BooksList = ({books}) => {
    return (
        <div>
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
                            <td>{b.authors.map(a => (`${a.firstName} ${a.lastName}`)) }</td>
                            <td>{b.title}</td>
                            <td>{b.price.toFixed(2)}</td>
                            <td>{b.categories.map(c => (c.title))}</td>
                        </tr>
                    ))
                }
                </tbody>
            </table>
        </div>
    );
};

export default BooksList;