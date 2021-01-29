import React from 'react';
import Layout from './components/Layout';
import Routes from "./routes"
import { AzureAD, LoginType, AuthenticationState } from 'react-aad-msal';
import { authProvider } from "./Auth/authProvider"
import { Container } from "reactstrap"

export default class App extends React.Component {
  constructor(props) {
    super(props);

    // Change the login type to execute in a Redirect
    const options = authProvider.getProviderOptions();
    options.loginType = LoginType.Popup;
    authProvider.setProviderOptions(options);
  }


  render() {
      return (
          <Layout>
              <Routes />
          </Layout>
      //<AzureAD provider={authProvider} reduxStore={this.props.store}>
      //  {({ login, logout, accountInfo, authenticationState, error }) => {
      //    const isInProgress = authenticationState === AuthenticationState.InProgress;
      //    const isAuthenticated = authenticationState === AuthenticationState.Authenticated;
      //    const isUnauthenticated = authenticationState === AuthenticationState.Unauthenticated;

      //    if (isUnauthenticated || isInProgress) {
      //      return (
      //        <Container>
      //          <button className="btn btn-primary" onClick={login} disabled={isInProgress}>
      //            Login
      //          </button>
      //        </Container>
      //      )
      //    }

      //    if (isAuthenticated) {
      //      return (
      //        <Layout accountInfo={accountInfo}>
      //          <Routes />
      //        </Layout>
      //      )
      //    }

      //    if (error) {
      //      return (
      //        <div style={{ wordWrap: 'break-word' }}>
      //          <p>
      //            <span style={{ fontWeight: 'bold' }}>errorCode:</span> {error.errorCode}
      //          </p>
      //          <p>
      //            <span style={{ fontWeight: 'bold' }}>errorMessage:</span> {error.errorMessage}
      //          </p>
      //        </div>
      //      )
      //    }
      //  }}
      //</AzureAD>
    )
  }
}

