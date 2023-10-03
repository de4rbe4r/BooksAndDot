import React from 'react';

const Shops = () => {
    return (
        <div>
            {/*
                 <iframe id="mapsShops"
                srс="https://yandex.ru/maps/?ll=50.139988%2C53.209271&z=16"
                 height="900" / >
                */}
                <h1>"Почитайка"</h1>
                <h2>Самара, пр. Ленина, 3</h2>
            <div style={{ position: 'relative', overflow: 'hidden' }} >
                <a href='https://yandex.ru/maps/51/samara/?utm_medium=mapframe&utm_source=maps'
                    style={{ color: 'green', fontSize: 12, position: 'absolute', top: 0 }}>Самара</a>
                <a href="https://yandex.ru/maps/51/samara/house/prospekt_lenina_3/YUkYdwRpQE0OQFtpfX5xeH5kZQ==/?ll=50.139988%2C53.209271&utm_medium=mapframe&utm_source=maps&z=16.54"
                    style={{ color: '#eee', fontSize: 12, position: 'absolute', top: 14 }}>Проспект Ленина, 3 — Яндекс Карты</a>
                <iframe src="https://yandex.ru/map-widget/v1/?ll=50.139988%2C53.209271&mode=search&ol=geo&ouri=ymapsbm1%3A%2F%2Fgeo%3Fdata%3DCgg1NzM3MTAyNhI80KDQvtGB0YHQuNGPLCDQodCw0LzQsNGA0LAsINC_0YDQvtGB0L_QtdC60YIg0JvQtdC90LjQvdCwLCAzIgoNWY9IQhVK1lRC&z=16.54" width="560" height="400" frameborder="1" allowfullscreen="true"
                    style={{ position: 'relative' }} >
                </iframe>
            </div>
        </div>
    );
};

export default Shops;