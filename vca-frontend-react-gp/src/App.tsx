import { Routes, Route, BrowserRouter } from 'react-router-dom'
import Home from './pages/home/Home'
import Login from './pages/login/Login'
import Register from './pages/register/Register'
import CarDetails from './pages/carDetails/CarDetails'
import CarConfigure from './pages/carConfigure/CarConfigure'
import Invoice from './pages/invoice/Invoice'
import Protected from './utility/Protected'

function App() {

  return (
    <>
      <BrowserRouter>
        <Routes>
          <Route>
            <Route path="/" element={<Home/>} />
            <Route path="/login" element={<Login/>} />
            <Route path="/register" element={<Register/>} />
            <Route path="/car-details/:id" element= { <CarDetails/>} />
            <Route path="/car-configure/:id" element= { <CarConfigure />} />
            <Route
            path="/invoice/:modelId"
            element={
              <Protected>
                <Invoice />
              </Protected>
            }
          />
          </Route>
        </Routes>
      </BrowserRouter>
    </>
  )
}

export default App
