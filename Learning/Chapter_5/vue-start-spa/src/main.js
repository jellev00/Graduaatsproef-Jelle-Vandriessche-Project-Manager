import {createApp, VueElement} from 'vue';
import App from './App.vue';
import '../node_modules/bootstrap/dist/css/bootstrap.css';
import $bus from './utils/Events.js';

const app = createApp(App)

app.config.globalProperties.$bus = $bus;

app.mount('#app');