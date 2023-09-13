import { useNavigate } from 'react-router-dom'
import './navbar.scss'
import { useEffect, useState } from 'react'
import { authExist, signout } from '../../../utility/util'

const Navbar = () => {

  const [authTokenExist, setAuthTokenExist] = useState(false)
  const navigate = useNavigate()
  // const [show, setShow] = useState<boolean>(true)
  // const handleShow = () => {
  //   setShow(!show)
  // }

  useEffect(() => {
    if (authExist()) { setAuthTokenExist(true) }
  }, [])

  return (
    <nav className="navbar">
      <div className="navbar-left">
        <div className="icon">
          {/* <i className="fa fa-shopping-cart"></i> */}
        </div>
      </div>

      <div className="navbar-right">
        <ul className="nav-links">
          <li className="nav-link" onClick={() => navigate('/')}>Home</li>
          {!authTokenExist ? <>
            <li className="nav-link" onClick={() => navigate('/login')}>Login</li>
            <li className="nav-link" onClick={() => navigate('/register')}>Register</li>
          </> :
            <>
              <li className="nav-link" onClick={() => signout()}>Logout</li>
              <li className="nav-link">@{localStorage.getItem('userName')}</li>
            </>}

        </ul>
      </div>
    </nav>
  )
}

export default Navbar