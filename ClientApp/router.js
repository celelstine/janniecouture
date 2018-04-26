
import Vue from 'vue';
import VueRouter from 'vue-router';

import AgeRange from './components/AgeRange.vue';
import Messages from './components/Messages.vue';
import Home from './components/Home.vue';
Vue.use(VueRouter);

const router = new VueRouter({
  mode: 'history',
  routes: [
    { path: '/', component: Home },
    { path: '/ageRange', component: AgeRange },
    { path: '/messages', component: Messages },
    { path: '*', component: Home },
  ]
});

export default router;
