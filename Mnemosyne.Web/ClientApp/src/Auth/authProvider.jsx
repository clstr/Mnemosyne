import { MsalAuthProvider, LoginType } from 'react-aad-msal';
import { Logger, LogLevel } from "msal";

// Msal Configurations
export const authProvider = new MsalAuthProvider(
  {
    auth: {
      authority: "https://login.microsoftonline.com/common",
      clientId: "3c9b3456-c821-415c-9f0e-a0c21e68c260",
      postLogoutRedirectUri: window.location.origin,
      redirectUri: window.location.origin,
      validateAuthority: true,

      // After being redirected to the "redirectUri" page, should user
      // be redirected back to the Url where their login originated from?
      navigateToLoginRequestUrl: false
    },
    // Enable logging of MSAL events for easier troubleshooting.
    // This should be disabled in production builds.
    system: {
      logger: new Logger(
        (logLevel, message, containsPii) => {
          console.log("[MSAL]", message);
        },
        {
          level: LogLevel.Verbose,
          piiLoggingEnabled: true
        }
      )
    },
    cache: {
      cacheLocation: "sessionStorage",
      storeAuthStateInCookie: true
    }
  },
  {
    scopes: ["openid"]
  },
  {
    loginType: LoginType.Popup,
    // When a token is refreshed it will be done by loading a page in an iframe.
    // Rather than reloading the same page, we can point to an empty html file which will prevent
    // site resources from being loaded twice.
    tokenRefreshUri: window.location.origin + "/auth.html"
  }
);