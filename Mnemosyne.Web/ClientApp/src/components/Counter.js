import React, { Fragment } from 'react';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';
import { actionCreators } from '../store/Counter';
import { Button } from 'reactstrap';

const Counter = props => (
  <Fragment>
    <h1>Counter</h1>
    <p>This is a simple example of a React component.</p>
    <p aria-live="polite">Current count: <strong>{props.count}</strong></p>
    
    <Button color="primary" onClick={props.increment}>Increment</Button>
  </Fragment>
);

export default connect(
  state => state.counter,
  dispatch => bindActionCreators(actionCreators, dispatch)
)(Counter);
