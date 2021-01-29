import React, {Fragment} from 'react';
import { Container } from "reactstrap"
import NavMenu from './NavMenu';

export default props => (
  <Fragment>
    <NavMenu accountInfo={props.accountInfo}/>
    <Container>
      {props.children}
    </Container>
  </Fragment>
);
