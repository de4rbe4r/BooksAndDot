import React from "react";
import Books from "./components/Books/Books";
import {Routes, Route} from "react-router-dom";

function App() {
    return (
        <div className="container">
            <Routes>
                <Route path='/books' element={<Books />} />
                <Route path='/cart' element={<Cart />} />
                <Route path='/reg' element={<Registration />} />
                <Route path='/auth' element={<Authorization />} />
                <Route path='/shops' element={<Shops />} />
            </Routes>
        </div>
  );
}

export default App;
