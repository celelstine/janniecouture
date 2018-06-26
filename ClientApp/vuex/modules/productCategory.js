

import axios from 'axios';
import {
    ADDING_PRODUCT_CATEGORY,
    ADDED,
    MESSAGE,
    FETCH_PRODUCT_CATEGORIES,
    FETCHING_PRODUCT_CATEGORIES,
    FETCHING_PRODUCT_CATEGORY,
    FETCH_PRODUCT_CATEGORY,
    FETCHING_PRODUCTS,
    FETCH_PRODUCTS
    } from '../mutation-types';
/* eslint-disable no-shadow  */
// initial state
const state = {
  productCategories: [],
  products: [],
  message: '',
  domainUrl: 'http://localhost:5001',
  hasMoreproductCategories: true,
  hasMoreproducts: true,
  productCategory: {},
  messageForProductCategory: false,
  messageForProducts: false
};

// getters
const getters = {
  productCategories: state => state.productCategories,
  message: state => state.message,
};

// actions
const actions = {
  add({ commit, state }, { formData } ) {
        commit(ADDING_PRODUCT_CATEGORY, {});
          axios.post(`${state.domainUrl}/api/ProductCategory`,
            formData,
            {
              headers: {
                'content-type': 'multipart/form-data',
              },
            },
          )
            .then(response =>  commit(ADDED, response.data))
            .catch((error) => {
              let message = 'An internal error occurred, please try again';
              if (error.response && error.response.status && error.response.status !== 500) {
                message = error.response.data;
              }
              return commit(MESSAGE, { message});
            });
  },
  get({ commit, state }, lastIndex ) {
    commit(FETCHING_PRODUCT_CATEGORIES);
    axios.get(`${state.domainUrl}/api/ProductCategory?lastIndex=${lastIndex}&size=10`)
    .then(response => commit(FETCH_PRODUCT_CATEGORIES, response.data))
    .catch(error => {
        let message = 'An internal error occurred, please try again';
        if (error.response && error.response.status && error.response.status !== 500) {
            message = error.response.data;
        }
        return commit(MESSAGE, { message});
    });
  },
  getCatByName({ commit, state }, name ) {
    commit(FETCHING_PRODUCT_CATEGORY);
    axios.get(`${state.domainUrl}/api/ProductCategory/${name}`)
    .then(response => commit(FETCH_PRODUCT_CATEGORY, response.data))
    .catch(error => {
        let message = 'An internal error occurred, please try again';
        if (error.response && error.response.status && error.response.status !== 500) {
            message = error.response.data;
        }
        return commit(MESSAGE, { message, recipient: 'productCategory' });
    });
  },
  getProductsByCatName({ commit, state }, { name, lastIndex } ) {
    commit(FETCHING_PRODUCTS);
    axios.get(`${state.domainUrl}/api/ProductCategory/${name}/products?lastIndex=${lastIndex}&size=10`)
    .then(response => commit(FETCH_PRODUCTS, response.data))
    .catch(error => {
        console.log("see error", error);
        let message = 'An internal error occurred, please try again';
        if (error.response && error.response.status && error.response.status !== 500) {
            message = error.response.data;
        }
        return commit(MESSAGE, { message, recipient: 'products' });
    });
  },
};

// mutations
const mutations = {
  [ADDED](state, newProductCategory) {
    state.productCategories = [...state.productCategories , newProductCategory];
    state.message = `${newProductCategory.name} has been added successfully`;
  },
  [MESSAGE](state, { message, recipient }) {
    state.message = message;
    state.hasMoreproductCategories = false;
    if (recipient === 'productCategory'){
        state.messageForProductCategory = true;
    }else if (recipient === 'products'){
        state.messageForProducts = true;
    }
  },
  [ADDING_PRODUCT_CATEGORY](state) {
    state.message = `Registrying new Product Category ......`;
  },
  [FETCHING_PRODUCT_CATEGORIES](state) {
    state.message = `Fetching Product Categories ......`;
  },
  [FETCH_PRODUCT_CATEGORIES](state, payload) {
    state.message = null;
    if ( payload.length > 0) {
        state.hasMoreproductCategories = true;
    } else {
        state.hasMoreproductCategories = false;
    }
    state.productCategories = [...state.productCategories, ...payload];
  },
  [FETCH_PRODUCT_CATEGORY](state, payload) {
    state.message = null;
    state.productCategory = payload;
  },
  [FETCHING_PRODUCT_CATEGORY](state) {
    state.message = `Fetching Product Category ......`;
    state.messageForProductCategory = true;
  },
  [FETCHING_PRODUCTS](state) {
    state.messageForProducts = true; 
    state.message = `Fetching new Products ......`;
  },
  [FETCH_PRODUCTS](state, payload) {
    state.message = null;
    state.messageForProducts = false;
    if ( payload.length > 0) {
        state.hasMoreproducts = true;
    } else {
        state.hasMoreproducts = false;
    }
    state.products = [...state.products, ...payload];
  },
};

export default {
  namespaced: true,
  state,
  getters,
  actions,
  mutations,
};