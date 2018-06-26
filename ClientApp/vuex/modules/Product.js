import axios from 'axios';
import {
    ADDING_PRODUCT,
    PRODUCT_ADDED,
    MESSAGE,
    FETCH_PRODUCT_DETAILS,
    FETCHING_PRODUCT_DETAILS,
    FETCHING_PRODUCT,
    FETCH_PRODUCT
    } from '../mutation-types';
/* eslint-disable no-shadow  */
// initial state
const state = {
  productDetails: [],
  product: null,
  message: '',
  domainUrl: 'http://localhost:5001',
  hasMoreproductDetails: true,
  messageForProduct: false
};

// getters
const getters = {
  productDetails: state => state.productDetails,
  message: state => state.message,
};

// actions
const actions = {
  add({ commit, state }, { formData } ) {
        commit(ADDING_PRODUCT, {});
          axios.post(`${state.domainUrl}/api/ProductCategory`,
            formData,
            {
              headers: {
                'content-type': 'multipart/form-data',
              },
            },
          )
            .then(response =>  commit(PRODUCT_ADDED, response.data))
            .catch((error) => {
              let message = 'An internal error occurred, please try again';
              if (error.response && error.response.status && error.response.status !== 500) {
                message = error.response.data;
              }
              return commit(MESSAGE, { message});
            });
  },
  getProductByName({ commit, state }, name ) {
    commit(FETCHING_PRODUCT);
    axios.get(`${state.domainUrl}/api/Product/${name}`)
    .then(response => commit(FETCH_PRODUCT, response.data))
    .catch(error => {
        let message = 'An internal error occurred, please try again';
        if (error.response && error.response.status && error.response.status !== 500) {
            message = error.response.data;
        }
        return commit(MESSAGE, { message, recipient: 'product' });
    });
  },
};

// mutations
const mutations = {
  [PRODUCT_ADDED](state, newProductCategory) {
    state.productCategories = [...state.productCategories , newProductCategory];
    state.message = `${newProductCategory.name} has been added successfully`;
  },
  [MESSAGE](state, { message, recipient }) {
    state.message = message;
    if (recipient === 'product'){
        state.messageForProduct = true;
    }
  },
  [ADDING_PRODUCT](state) {
    state.message = `Registrying new Product Category ......`;
  },
  [FETCHING_PRODUCT](state) {
    state.message = `Fetching Product Details ......`;
  },
  [FETCH_PRODUCT](state, payload) {
    state.message = null;
    state.product = payload;
  },
  [FETCHING_PRODUCT_DETAILS](state) {
    state.message = `Fetching Product Category ......`;
    state.messageForProductCategory = true;
  },
  [FETCH_PRODUCT_DETAILS](state, payload) {
    state.message = null;
    if ( payload.length > 0) {
        state.hasMoreproductCategories = true;
    } else {
        state.hasMoreproductCategories = false;
    }
    state.productCategories = [...state.productCategories, ...payload];
  }
};

export default {
  namespaced: true,
  state,
  getters,
  actions,
  mutations,
};