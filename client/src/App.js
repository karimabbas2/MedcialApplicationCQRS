import './App.css';
import { BrowserRouter, Route, Routes } from "react-router-dom";
import NoMatch from './Components/NoMatch';
import Home from './Components/Home';
import Header from './Components/Header';
import Layout from './Components/Layout/Layout';

function App() {

  return (
    <>
      <BrowserRouter>
        <Routes>

          <Route path="/admin" element={<Header />} />
          <Route path='/admin/Dashboard/:name' element={<Home />} />
          <Route path='/admin/Dashboard/:name/:id' element={<Home />} />
          <Route path='/' element={<Layout />} />
          <Route path='/:name' element={<Layout />} />
          <Route path="*" element={<NoMatch />} />

        </Routes>

      </BrowserRouter>

    </>
  );
}

export default App;
