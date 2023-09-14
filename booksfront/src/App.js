import React from "react";
import Books from "./components/Books/Books";
import {Routes, Route} from "react-router-dom";
import Cart from "./components/Cart/Cart";
import Registration from "./components/Reg/Registration";
import Authorization from "./components/Auth/Authorization";
import Shops from "./components/Shops/Shops";
import NotFound from "./components/NotFound/NotFound";

function App() {
    return (
        <div className="container">
            <Routes>
                <Route path='/books' element={<Books />} />
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
