import React from 'react';
import ReactDOM from 'react-dom/client';
import './styles/_index.scss';
import App from './App';
import reportWebVitals from './reportWebVitals';
import { BASE_URL } from './utility/apiConfig';
import swDev from './serviceWorkerRegistration';
import axios from 'axios'

const setupAxios = () => {
  // localStorage.setItem('authToken', 'eyJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJhbXJlc2giLCJpYXQiOjE2OTM0NzMyNzEsImV4cCI6MTY5MzU1OTY3MX0.HX_8tc-UIuGGvewc6JriBOH544wd1_rj97Gm5qhkpwg')

  const authToken = localStorage.getItem("authToken");
  if (authToken) {
    axios.defaults.headers.common['Authorization'] = `Bearer ${authToken}`;
  }
  axios.defaults.baseURL = BASE_URL;
};
setupAxios();

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);

root.render(
  // <React.StrictMode>
    <App />
  // </React.StrictMode> 
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
swDev();

