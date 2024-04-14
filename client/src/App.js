import './App.css';
import { BrowserRouter, Route, Routes } from "react-router-dom";
import NoMatch from './Components/NoMatch';
import Home from './Components/Home';
import Header from './Components/Header';

function App() {
  
  return (
    <>
      <BrowserRouter>
        <Routes>

          <Route path='/:name' element={<Home />} />
          <Route path='/:name/:id' element={<Home />} />
          <Route path="/" element={<Header />} />
          <Route path="*" element={<NoMatch />} />

        </Routes>

      </BrowserRouter>

    </>
  );
}

export default App;
