import React from 'react';

const BooksCardList = () => {
    return (
        <div className="col-md-6">
            <div
                className="row g-0 border rounded overflow-hidden flex-md-row mb-4 shadow-sm h-md-250 position-relative">
                <div className="col p-4 d-flex flex-column position-static">
                    <strong className="d-inline-block mb-2 text-primary-emphasis">Роман</strong>
                    <h3 className="mb-0">Война и мир</h3>
                    <div className="mb-1 text-body-secondary">31 авг</div>
                    <p className="card-text mb-auto">Знаментый роман великого русского писателя Льва Толстого.</p>
                    <a href="#" className="icon-link gap-1 icon-link-hover stretched-link">
                        Читать далее
                        <svg className="bi">
                            <use xlink:href="#chevron-right"></use>
                        </svg>
                    </a>
                </div>
                <div className="col-auto d-none d-lg-block">
                    <svg className="bd-placeholder-img" width="200" height="250" xmlns="http://www.w3.org/2000/svg"
                         role="img" aria-label="Placeholder: Thumbnail" preserveAspectRatio="xMidYMid slice"
                         focusable="false"><title>Placeholder</title>
                        <rect width="100%" height="100%" fill="#55595c"></rect>
                        <text x="50%" y="50%" fill="#eceeef" dy=".3em">Thumbnail</text>
                    </svg>
                </div>
            </div>
        </div>
    );
};

export default BooksCardList;