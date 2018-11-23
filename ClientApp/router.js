
import Vue from 'vue';
import VueRouter from 'vue-router';

import AgeRange from './components/AgeRange/index.vue.html';
import Messages from './components/Messages/index.vue.html';
import Home from './components/Home/index.vue.html';
import ConfirmAccount from './components/ConfirmAccount/index.vue.html';
import AdminProductCategory from './components/AdminProductCategory/index.vue.html';
import ProductCategoryDetail from './components/ProductCategoryDetail/index.vue.html';
import ProductDetail from './components/ProductDetail/index.vue.html';

Vue.use(VueRouter);

const router = new VueRouter({
  mode: 'history',
  routes: [
    { path: '/', component: Home },
    { path: '/ageRange', component: AgeRange },
    { path: '/messages', component: Messages },
    { path: '/Account/ConfirmEmail', component: ConfirmAccount },
    { path: '/AdminProductCategory', component: AdminProductCategory },
    {
      path: '/productCategory/:name',
      name:'productCategoryDetail',
      component: ProductCategoryDetail
    },
    { 
        path: '/product/:name', 
        name:'product',
        component: () => import('./components/ProductDetail/index.vue.html') 
    },
    { path: '*', component: Home },
  ]
});

export default router;
