import { applyMiddleware, compose, createStore } from 'redux';
import middleware from "./middleware"
import createRootReducer from './reducers'

export default function configureStore(history, initialState) {

  // In development, use the browser's Redux dev tools extension if installed
  const enhancers = [];
  const isDevelopment = process.env.NODE_ENV === 'development';
  if (isDevelopment && typeof window !== 'undefined' && window.devToolsExtension) {
    enhancers.push(window.devToolsExtension());
  }

  return createStore(
    // root reducer with router state
    createRootReducer(history),
    initialState,
    compose(
      applyMiddleware(...middleware(history)), 
      ...enhancers
    )
  );
}
