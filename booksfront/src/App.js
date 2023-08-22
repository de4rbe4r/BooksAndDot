import logo from './logo.svg';
import './App.css';

function App() {
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
