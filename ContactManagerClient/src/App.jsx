import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Home from './Pages/Home';
import Contacts from './Pages/Contacts';
import Error from './Pages/Error';
import './App.css'
import Navbar from './Components/Navbar';

function App() {

  return (
    <>
      <Router>
        <Navbar/>
          <Routes>
            <Route path='/' element={ <Home/> }/>
            <Route path='/api/Contact/listar-contatos' element={<Contacts />} />
            <Route path='/api/Contact/*' element={<Error />}/>
          </Routes>
      </Router>
    </>
  )
}

export default App
