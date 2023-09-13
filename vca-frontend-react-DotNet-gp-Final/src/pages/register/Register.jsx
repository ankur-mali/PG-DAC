import React, { useState } from "react";
import axios from "axios";
import "./Register.css";
import { useNavigate } from "react-router-dom";

function Register() {
  let navigate = useNavigate()

  const [formData, setFormData] = useState({
    companyName: "",
    addressLine1: "",
    addressLine2: "",
    city: "",
    state: "",
    pinCode: "",
    telephone: "",
    username: "",
    gstNumber: "",
    email: "",
    password: "",
    role: ["ROLE_USER"]

  });

  const handleInputChange = (event) => {
    const { name, value } = event.target;
    setFormData((prevData) => ({
      ...prevData,
      [name]: value
    }));
  };

  const handleSubmit = async (e) => {
    e.preventDefault();
    console.warn(formData);
    try {
      let res = await axios.post("/auth/signup", formData);
      if (res.data.status == 200) {
        alert(res.data.message)
        navigate('/')
      }
      console.log("done", res)
    } catch (e) {
      console.warn(e);
      if (e.response.status==400) {
        alert(e.response.data.data.error)
      }
    }
  };

  return (
    <div className="container mt-4">
      <div className="card">
        <h1>Registration</h1>
        <form onSubmit={handleSubmit}>
          <div className="form-group">
            <label>Email *</label>
            <input
              type="email"
              className="form-control"
              name="email"
              value={formData.email}
              onChange={handleInputChange}
              required
            />
          </div>

          <div className="form-group">
            <label>Password *</label>
            <input
              type="password"
              className="form-control"
              name="password"
              value={formData.password}
              onChange={handleInputChange}
              required
            />
          </div>

          <div className="form-group">
            <label>Authorized Person Name *</label>
            <input
              type="text"
              name="username"
              value={formData.username}
              onChange={handleInputChange}
              required
            />
          </div>

          <div className="form-group">
            <label>Company Name</label>
            <input
              type="text"
              className="form-control"
              name="companyName"
              value={formData.companyName}
              onChange={handleInputChange}
            />
          </div>

          <div className="form-group">
            <label>Address Line 1</label>
            <input
              type="text"
              className="form-control"
              name="addressLine1"
              value={formData.addressLine1}
              onChange={handleInputChange}
            />
          </div>
          <div className="form-group">
            <label>Address Line 2</label>
            <input
              type="text"
              name="addressLine2"
              value={formData.addressLine2}
              onChange={handleInputChange}
            />
          </div>

          <div className="form-group">
            <label>City</label>
            <input
              type="text"
              name="city"
              value={formData.city}
              onChange={handleInputChange}
            />
          </div>
          <div className="form-group">
            <label>State</label>
            <input
              type="text"
              name="state"
              value={formData.state}
              onChange={handleInputChange}
            />
          </div>
          <div className="form-group">
            <label>Pincode</label>
            <input
              type="text"
              name="pinCode"
              value={formData.pincode}
              onChange={handleInputChange}
            />
          </div>
          <div className="form-group">
            <label>Telephone</label>
            <input
              type="text"
              name="telephone"
              value={formData.telephone}
              onChange={handleInputChange}
            />
          </div>

          <div className="form-group">
            <label>GST Number</label>
            <input
              type="text"
              name="gstNumber"
              value={formData.gstNumber}
              onChange={handleInputChange}
            />
          </div>
          <button type="submit" className="submit-button">
            Submit
          </button>

        </form>
      </div>
    </div>
  );
}

export default Register;
