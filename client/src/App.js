import './App.css';
import Footer from './Components/Footer';
import { BrowserRouter, Route, Routes } from "react-router-dom";

import Doctor from './Components/Doctor';
import Department from './Components/Department';
import Appointment from './Components/Appointment';
import NoMatch from './Components/NoMatch';
import Home from './Components/Home';

function App() {
  return (
    <>
      <BrowserRouter>
        <Home />
        <Routes>

          <Route path='/Doctor' index element={<Doctor />} />

          <Route path='/Department' element={<Department />} />

          <Route path='/Appointment' element={<Appointment />} />

          <Route path="*" element={<NoMatch />} />

        </Routes>
        <Footer />
      </BrowserRouter>

    </>
  );
}

export default App;
