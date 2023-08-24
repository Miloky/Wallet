import { mgr } from '@/router/auth-service';
import { onBeforeMount, reactive } from 'vue';

interface State {
  authenticated: boolean;
  loading: boolean;
}

const defaultState: State = {
  authenticated: false,
  loading: true
};

export default function useAuthGuard() {
  const state = reactive<State>({ ...defaultState });

  const isCallback = () => {
    const search = new URLSearchParams(window.location.search);
    const code = search.get('code');
    const scope = search.get('scope');
    const queryState = search.get('state');
    const issuer = search.get('iss');
    return !!(code && scope && queryState && issuer);
  };

  onBeforeMount(async () => {
    const isCallbackRoute = isCallback();

    if (isCallbackRoute) {
      await mgr.signinRedirectCallback();
      window.location.replace(window.location.origin);
    }

    const user = await mgr.getUser();

    if (user === null && !isCallbackRoute) {
      mgr.clearStaleState();
      await mgr.signinRedirect({ state: '/' });
    } else {
      state.authenticated = true;
      state.loading = false;
    }
  });

  return {
    state
  };
}
