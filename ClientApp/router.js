﻿
import Vue from 'vue';
import VueRouter from 'vue-router';

import AgeRange from './components/AgeRange.vue';
import Messages from './components/Messages.vue';
import Home from './components/Home.vue';
import ConfirmAccount from './components/ConfirmAccount.vue';
import AdminProductCategory from './components/AdminProductCategory.vue';
import ProductCategoryDetail from './components/ProductCategoryDetail.vue';
import ProductDetail from './components/ProductDetail.vue';
Vue.use(VueRouter);

const router = new VueRouter({
  mode: 'history',
  routes: [
    { path: '/', component: Home },
    { path: '/ageRange', component: AgeRange },
    { path: '/messages', component: Messages },
    { path: '/Account/ConfirmEmail', component: ConfirmAccount },
    { path: '/AdminProductCategory', component: AdminProductCategory },
    { path: '/productCategory/:name',  name:'productCategoryDetail', component: ProductCategoryDetail },
    { 
        path: '/product/:name', 
        name:'product',
        component: () => import('./components/ProductDetail.vue') 
    },
    { path: '*', component: Home },
  ]
});

export default router;
