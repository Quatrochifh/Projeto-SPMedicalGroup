import React from 'react';
import ReactDOM from 'react-dom';

//css
import './index.css';

import reportWebVitals from './reportWebVitals';
import {  Route, BrowserRouter as Router, Routes } from 'react-router-dom';


import App from '../src/pages/home/App';
import Adm from '../src/pages/administrador/Administrador'
import NotFound from '../src/pages/notFound/NotFound';

const routing = (
  <Router>
    <div>
      <Routes>
        <Route exact path="/app" element={App} />
        <Route path="/adm" element={Adm} />
        <Route path="/notfound" element={NotFound} />
        {/* <Route path="/*" component={NotFound} /> Outra forma */}
        <Redirect to="/notfound" />
      </Routes>
    </div>
  </Router>
)


ReactDOM.render(
  routing,
  document.getElementById('root')
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
