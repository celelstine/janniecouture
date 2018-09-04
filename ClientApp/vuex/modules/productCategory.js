import axios from 'axios';
import {
    ADDING_PRODUCT_CATEGORY,
    ADDING_PRODUCT,
    ADDED_PRODUCT,
    ADDED_PRODUCT_CATEGORY,
    MESSAGE,
    FETCH_PRODUCT_CATEGORIES,
    FETCHING_PRODUCT_CATEGORIES,
    FETCHING_PRODUCT_CATEGORY,
    FETCH_PRODUCT_CATEGORY,
    FETCHING_PRODUCTS,
    FETCH_PRODUCTS,
    DONE,
    LOADING,
    EDITING_PRODUCT_CATEGORY,
    EDITED,
    DELETED_PRODUCT_CATEGORY
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
  messageForProducts: false,
  messageForAdminProducts: false,
  messageForAdminProdCat: false
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
    commit(LOADING, null, { root: true })
    axios.post(`${state.domainUrl}/api/ProductCategory`,
      formData,
      {
        headers: {
          'content-type': 'multipart/form-data',
        },
      },
    )
      .then(response =>  {
          commit(DONE, null, { root: true });
          commit(ADDED_PRODUCT_CATEGORY, response.data);
        })
      .catch((error) => {
        commit(DONE, null, { root: true })
        let message = 'An internal error occurred, please try again';
        if (error.response && error.response.status && error.response.status !== 500) {
          message = error.response.data;
        }
        return commit(MESSAGE, { message, recipient: 'adminProdCat'});
      });
  },
  edit({ commit, state }, { prodCatIndex, productCatID, formData } ) {
    commit(EDITING_PRODUCT_CATEGORY, {});
    commit(LOADING, null, { root: true })
    axios.put(`${state.domainUrl}/api/ProductCategory/Edit/${productCatID}`,
      formData,
      {
        headers: {
          'content-type': 'multipart/form-data',
        },
      },
    )
      .then(response =>  {
          commit(DONE, null, { root: true });
          commit(EDITED, { prodCatIndex, productCategory: response.data});
        })
      .catch((error) => {
        commit(DONE, null, { root: true })
        let message = 'An internal error occurred, please try again';
        if (error.response && error.response.status && error.response.status !== 500) {
          message = error.response.data;
        }
        return commit(MESSAGE, { message, recipient: 'adminProdCat'});
      });
  },
  get({ commit, state }, lastIndex ) {
    commit(FETCHING_PRODUCT_CATEGORIES);
    commit(LOADING, null, { root: true })
    axios.get(`${state.domainUrl}/api/ProductCategory?lastIndex=${lastIndex}&size=10`)
    .then(response => {
        commit(DONE, null, { root: true })
        return commit(FETCH_PRODUCT_CATEGORIES, response.data);
    })
    .catch(error => {
        commit(DONE, null, { root: true })
        let message = 'An internal error occurred, please try again';
        if (error.response && error.response.status && error.response.status !== 500) {
            message = error.response.data;
        }
        return commit(MESSAGE, { message, recipient: 'adminProdCat'});
    });
  },
  deleteProdCat({ commit, state }, {productCategoryID, index} ) {
    commit(MESSAGE, { message: `Deleting ${productCategoryID}`, recipient: 'productCategory'});
    commit(LOADING, null, { root: true })
    axios.delete(`${state.domainUrl}/api/ProductCategory/${productCategoryID}`)
    .then(response => {
        commit(DONE, null, { root: true })
        return commit(DELETED_PRODUCT_CATEGORY, index);
    })
    .catch(error => {
        commit(DONE, null, { root: true })
        let message = 'An internal error occurred, please try again';
        if (error.response && error.response.status && error.response.status !== 500) {
            message = error.response.data;
        }
        return commit(MESSAGE, { message, recipient: 'productCategory'});
    });
  },
  getCatByName({ commit, state }, {name} ) {
    commit(FETCHING_PRODUCT_CATEGORY);
    commit(LOADING, null, { root: true })
    axios.get(`${state.domainUrl}/api/ProductCategory/${name}`)
    .then(response => {
        commit(DONE, null, { root: true })
        commit(FETCH_PRODUCT_CATEGORY, response.data)
    })
    .catch(error => {
        commit(DONE, null, { root: true })
        let message = 'An internal error occurred, please try again';
        if (error.response && error.response.status && error.response.status !== 500) {
            message = error.response.data;
        }
        return commit(MESSAGE, { message, recipient: 'productCategory' });
    });
  },
  getProductsByCatName({ commit, state }, { name, lastIndex } ) {
    commit(FETCHING_PRODUCTS);
    commit(LOADING, null, { root: true })
    axios.get(`${state.domainUrl}/api/ProductCategory/${name}/products?lastIndex=${lastIndex}&size=10`)
    .then(response => {
        commit(DONE, null, { root: true })
        commit(FETCH_PRODUCTS, { lastIndex, payload: response.data})
     })
    .catch(error => {
        commit(DONE, null, { root: true })
        let message = 'An internal error occurred, please try again';
        if (error.response && error.response.status && error.response.status !== 500) {
            message = error.response.data;
        }
        return commit(MESSAGE, { message, recipient: 'products' });
    });
  },
  addProduct({ commit, state }, { formData } ) {
    commit(ADDING_PRODUCT, {});
    axios.post(`${state.domainUrl}/api/Product`,
      formData,
      {
        headers: {
          'content-type': 'multipart/form-data',
        },
      },
    )
      .then(response =>  commit(ADDED_PRODUCT, response.data))
      .catch((error) => {
        console.log('error', error);
        let message = 'An internal error occurred, please try again';
        if (error.response && error.response.status && error.response.status !== 500) {
          message = error.response.data;
        }
        return commit(MESSAGE, { message, recipient: 'adminProd'});
      });
  },
};

// mutations
const mutations = {
  [ADDED_PRODUCT_CATEGORY](state, newProductCategory) {
    state.productCategories.unshift(newProductCategory);
    state.message = `${newProductCategory.name} has been added successfully`;
    state.messageForProducts = false;
    state.messageForAdminProdCat = false;
    state.messageForProductCategory = true;
  },
  [ADDED_PRODUCT](state, newProduct) {
    state.products.unshift(newProduct);
    state.message = `${newProduct.name} has been added successfully`;
    state.messageForProducts = false;
    state.messageForAdminProducts = true;
    state.messageForAdminProdCat = false;
    state.messageForProductCategory = false;
  },
  [MESSAGE](state, { message, recipient }) {
    state.message = message;
    state.hasMoreproductCategories = false;

    // reset every message category indicator
    state.messageForProductCategory = false;
    state.messageForProducts = false;
    state.messageForAdminProdCat = false;
    state.messageForAdminProducts = false;

    switch (recipient) {
      case 'adminProd': 
        state.messageForAdminProducts =  true;
        break;
      case 'products':
        state.messageForProducts = true;
        break;
      case 'productCategory':
        state.messageForProductCategory = true;
        break;
      case 'adminProdCat':
       state.messageForAdminProdCat = true;
       break;
      default:
        break;
    }

  },
  [ADDING_PRODUCT_CATEGORY](state) {
    state.message = 'Registrying new Product Category ......';
    state.messageForProducts = false;
    state.messageForAdminProdCat = false;
    state.messageForProductCategory = true;
    state.messageForProductCategory = false;
  },
  [FETCHING_PRODUCT_CATEGORIES](state) {
    state.message = 'Fetching Product Categories ......';
    state.messageForProducts = false;
    state.messageForAdminProdCat = false;
    state.messageForProductCategory = true;
    state.messageForProductCategory = false;
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
    state.messageForProductCategory = false;
    state.messageForAdminProdCat = false;
    state.messageForProducts = true;
    state.messageForProductCategory = false;
  },
  [FETCHING_PRODUCTS](state) {
    state.messageForProducts = true;
    state.messageForProductCategory = false;
    state.messageForAdminProdCat = false;
    state.messageForProductCategory = false;
    state.message = `Fetching Products ......`;
  },
  [FETCH_PRODUCTS](state, { lastIndex, payload}) {
    state.message = null;
    state.messageForProducts = false;
    if ( payload.length > 0) {
        state.hasMoreproducts = true;
    } else {
        state.hasMoreproducts = false;
    }
    if (lastIndex === 0) {
         state.products = payload;
    } else {
        state.products = [...state.products, ...payload];
    }

  },
  [EDITING_PRODUCT_CATEGORY](state) {
    state.messageForProducts = false; 
    state.messageForProductCategory = false;
    state.messageForAdminProdCat = true;
    state.messageForProductCategory = false;
    state.message = `Editing product Category ......`;
  },
  [EDITED](state, { prodCatIndex, productCategory}) {
    state.messageForProducts = false; 
    state.messageForProductCategory = false;
    state.messageForAdminProdCat = true;
    state.messageForProductCategory = false;
    state.message = `${productCategory.name} has been updated successfully ......`;
    state.productCategories[prodCatIndex] = productCategory;
  },
  [DELETED_PRODUCT_CATEGORY](state, prodCatIndex) {
    state.messageForProducts = false; 
    state.messageForProductCategory = true;
    state.messageForAdminProdCat = false;
    state.message = `${state.productCategories[prodCatIndex].name} has been deleted successfully ......`;
    state.productCategories.splice(prodCatIndex, 1);
  },
  [ADDING_PRODUCT](state) {
    state.message = `Registrying new Product  ......`;
    state.messageForProducts = false;
    state.messageForAdminProducts = true;
    state.messageForAdminProdCat = false;
    state.messageForProductCategory = false;
  },
};

export default {
  namespaced: true,
  state,
  getters,
  actions,
  mutations,
};
