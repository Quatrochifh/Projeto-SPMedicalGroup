import React from 'react';
import ReactDOM from 'react-dom';

//css
import './index.css';

import reportWebVitals from './reportWebVitals';
import { Redirect, Route, BrowserRouter as Router, Switch } from 'react-router-dom';


import App from '../src/pages/home/App';
import Administrador from './pages/administrador/Administrador_Consulta'
import NotFound from '../src/pages/notfound/NotFound';
import Login from '../src/pages/login/Login'

const routing = (
  <Router>
    <div>
      <Switch>
        <Route exact path="/home" component={App} />
        <Route path="/adm" component={Administrador} />
        <Route path="/Login" component={Login} />
        <Route path="/notfound" component={NotFound} />
        <Redirect to="/Notfound" />
      </Switch>
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
