import Vue from 'vue';
import store from './vuex/store.js';
import App from './components/App.vue';
import router from './router';

const app = new Vue({
    el: '#app',
    router,
    store,
    ...App
});

app.$mount('#app');
//export { app, router, store };
