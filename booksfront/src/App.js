import React from "react";
import Books from "./components/Books/Books";
import {Routes, Route} from "react-router-dom";

function App() {
    return (
        <div className="container">
            <Routes>
                <Route path='/books' element={<Books />} />
            </Routes>
        </div>
  );
}

export default App;
