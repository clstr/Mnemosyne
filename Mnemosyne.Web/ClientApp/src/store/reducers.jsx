import { combineReducers } from 'redux'
import { connectRouter } from 'connected-react-router'

import * as Counter from './Counter';
import * as WeatherForecasts from './WeatherForecasts';
import {reducer as toastrReducer} from 'react-redux-toastr'
import * as Authentication from './Auth';

const reducers = {
    counter: Counter.reducer,
    weatherForecasts: WeatherForecasts.reducer,
    toastr: toastrReducer,
    auth: Authentication.reducer
  };

const createRootReducer = (history) => combineReducers({
  router: connectRouter(history),
  ...reducers
})

export default createRootReducer