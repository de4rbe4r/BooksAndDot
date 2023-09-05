import React from 'react';
import useGetAll from "../../hooks/useGetAll";
import { urlAuthors } from "../../urls/urlList";
import AuthorsList from "./AuthorsList";
/*import AuthorForm from "./AuthorForm";*/

const Authors = () => {
    const [authors, loading] = useGetAll(urlAuthors)

    if (loading) {
        return <h3>Загрузка...</h3>
    }
    if (!authors?.length) {
        return <h3>Список авторов пуст</h3>
    }

    return (
        <div>
            {/* <AuthorForm books={authors} /> */}
            <AuthorsList books={authors} />
        </div>
    );
};

export default Authors;
