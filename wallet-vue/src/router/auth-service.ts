import { UserManager } from 'oidc-client';

const config = {
  authority: 'https://localhost:7050',
  client_id: 'interactive',
  redirect_uri: 'http://localhost:5173/',
  response_type: 'code',
  scope: 'openid profile weatherapi.read',
  post_logout_redirect_uri: 'http://localhost:5173/'
};

export const mgr = new UserManager(config);

function log(arg1: any, arg2?: any) {
  document!.getElementById('results')!.innerText = '';

  Array.prototype.forEach.call(arguments, function (msg) {
    if (msg instanceof Error) {
      msg = 'Error: ' + msg.message;
    } else if (typeof msg !== 'string') {
      msg = JSON.stringify(msg, null, 2);
    }
    document!.getElementById('results')!.innerHTML += msg + '\r\n';
  });
}

mgr.events.addUserSignedOut(function () {
  log('User signed out of IdentityServer');
});

class AuthService {
  public login() {
    mgr.signinRedirect({ state: '/' });
  }

  public async getAccessToken(){
    const user =  await mgr.getUser();
    return user?.access_token;
  }

  public api() {
    mgr.getUser().then(function (user) {
      const url = 'https://localhost:6001/identity';

      const xhr = new XMLHttpRequest();
      xhr.open('GET', url);
      xhr.onload = function () {
        log(xhr.status, JSON.parse(xhr.responseText));
      };
      xhr.setRequestHeader('Authorization', 'Bearer ' + user!.access_token);
      xhr.send();
    });
  }
}

export default new AuthService();
