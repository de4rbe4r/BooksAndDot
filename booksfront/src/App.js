import React from "react";
import Books from "./components/Books/Books";
import {Routes, Route} from "react-router-dom";
import Cart from "./components/Cart/Cart";
import Registration from "./components/Reg/Registration";
import Authorization from "./components/Auth/Authorization";
import Shops from "./components/Shops/Shops";
import NotFound from "./components/NotFound/NotFound";
import NavBar from "./UI/Navigation/NavBar";
import Home from "./components/Home/Home";
import Book from "./components/Books/Book";

function App() {
    return (
        <div className="container">
            <NavBar />
            <Routes>
                <Route path='/' element={<Home />} />
                <Route path='/books' element={<Books />} />
<<<<<<< HEAD
                <Route index path="/books/:id" element={<Book />} />
=======
                {/* <Route path='/book/5' element={<Book />} /> */}
>>>>>>> 666f91f103a2139550ccb346d602e72686bf4f3a
                <Route path='/cart' element={<Cart />} />
                <Route path='/reg' element={<Registration />} />
                <Route path='/auth' element={<Authorization />} />
                <Route path='/shops' element={<Shops />} />
                <Route path='*' element={<NotFound />}/>
            </Routes>
        </div>
  );
}

export default App;
