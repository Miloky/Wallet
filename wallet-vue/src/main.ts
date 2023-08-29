import '@quasar/extras/material-icons/material-icons.css';
import 'quasar/src/css/index.sass';
import './common.scss';

import { createApp } from 'vue';
import { createPinia } from 'pinia';
import { Quasar } from 'quasar';

// Import icon libraries

// Import Quasar css

import App from './App.vue';
import router from './router';

const app = createApp(App);

app.use(createPinia());
app.use(router);
app.use(Quasar, {
  plugins: {} // import Quasar plugins and add here
});

app.mount('#app');
