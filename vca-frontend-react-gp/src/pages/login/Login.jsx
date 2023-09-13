import React, { useState, useEffect } from "react";
import { useNavigate } from 'react-router-dom'
import axios from "axios";
import "./Logins.scss";
import VideoPlayer from "./VideoPlayer";
import { authExist } from "../../utility/util";

function Login() {

  let navigate = useNavigate();

  useEffect(() => {
    if (authExist()) { navigate('/') }
  }, [])

  const [formData, setFormData] = useState({
    username: "",
    email: "",
    password: "",
    role: ["ROLE_USER"]
  });

  const handleInputChange = (event) => {
    const { name, value } = event.target;
    setFormData((prevData) => ({
      ...prevData,
      [name]: value,
    }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
      let res = await axios.post("/auth/signin", formData);
      if (res.data.status == 200) {
        localStorage.setItem('authToken', res.data.data.jwt)
        localStorage.setItem('userId', res.data.data.id)
        localStorage.setItem('userName', res.data.data.username)
        navigate('/')
      } else { alert("login failed!") }
    } catch (e) {
      console.log(e);
      alert("login failed!")
    }
  };

  return (<>
    <div className="login-container">
      <VideoPlayer />
      <form onSubmit={handleSubmit}>
        <div className="input-group">
          <label htmlFor="username">UserName:</label>
          <input
            type="username"
            id="username"
            name="username"
            value={formData.username}
            onChange={handleInputChange}
            required
          />
        </div>
        <div className="input-group">
          <label htmlFor="email">Email:</label>
          <input
            type="email"
            id="email"
            name="email"
            value={formData.email}
            onChange={handleInputChange}
            required
          />
        </div>
        <div className="input-group">
          <label htmlFor="password">Password:</label>
          <input
            type="password"
            id="password"
            name="password"
            value={formData.password}
            onChange={handleInputChange}
            required
          />
        </div>
        <button type="submit" className="login-button">
          Login
        </button>
        <button className="login-button" onClick={() => navigate('/register')}>
          Register
        </button>
      </form>

    </div>
  </>
  );
}

export default Login;
