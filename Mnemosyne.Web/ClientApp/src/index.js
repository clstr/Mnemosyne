import "bootstrap/dist/css/bootstrap.min.css"
import 'react-redux-toastr/lib/css/react-redux-toastr.min.css'

import React from 'react';
import ReactDOM from 'react-dom';
import { Router } from 'react-router-dom'
import { Provider } from 'react-redux';
import { ConnectedRouter } from 'connected-react-router';
import { createBrowserHistory } from 'history';
import ReduxToastr from 'react-redux-toastr'
import configureStore from './store/configureStore';
import App from './App';
//import registerServiceWorker from './registerServiceWorker';

// Create browser history to use in the Redux store
const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
const history = createBrowserHistory({ basename: baseUrl });

// Get the application-wide store instance, prepopulating with state from the server where available.
const initialState = window.initialReduxState;
const store = configureStore(history, initialState);
const rootElement = document.getElementById('root');

ReactDOM.render(
  <React.StrictMode>
    <Provider store={store}>
      <ConnectedRouter history={history}>
        <Router history={history}>
          <ReduxToastr
            timeOut={2000}
            newestOnTop={true}
            position={"top-right"}
            transitionIn="fadeIn"
            transitionOut="fadeOut"
            progressBar
            closeOnToastrClick />
          <App store={store}/>
        </Router>
      </ConnectedRouter>
    </Provider>
  </React.StrictMode>,
  rootElement);

//registerServiceWorker();