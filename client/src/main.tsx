import React from 'react'
import { createBrowserHistory } from "history";
import ReactDOM from 'react-dom'
import App from './App'
import { Router } from "react-router";

export const history = createBrowserHistory();

ReactDOM.render(
  <Router history={history}>
    <App />
  </Router>,
  document.getElementById('root')
)
