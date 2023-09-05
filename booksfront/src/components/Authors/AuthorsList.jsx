import React from 'react';

const AuthorsList = ({ authors }) => {
    return (
        <div>
            <h3>Список авторов</h3>
            <table className="table">
                <thead>
                    <tr>
                        <th>#</th>
                        <th>Имя</th>
                        <th>Фамилия</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        authors.map((a, index) => (
                            <tr key={a.id}>
                                <td>{index + 1}</td>
                                <td>{a.firstname}</td>
                                <td>{a.lastname}</td>
                            </tr>
                        ))
                    }
                </tbody>
            </table>
        </div>
    );
};

export default BooksList;