import axios from 'axios';
import {
  DONE,
  EDITED,
  LOADING,
  MESSAGE,
  ADDED_PRODUCT,
  FETCH_PRODUCTS,
  ADDING_PRODUCT,
  EDITTED_PRODUCT,
  DELETED_PRODUCT,
  FETCHING_PRODUCTS,
  ADDED_PRODUCT_CATEGORY,
  FETCH_PRODUCT_CATEGORY,
  ADDING_PRODUCT_CATEGORY,
  FETCH_PRODUCT_CATEGORIES,
  DELETED_PRODUCT_CATEGORY,
  EDITING_PRODUCT_CATEGORY,
  FETCHING_PRODUCT_CATEGORY,
  FETCHING_PRODUCT_CATEGORIES,
} from '../mutation-types';

/* eslint-disable no-shadow  */

// initial state
const state = {
  productCategories: [],
  products: [],
  message: '',
  messageRecipient: null,
  domainUrl: 'http://localhost:5001',
  hasMoreproductCategories: true,
  hasMoreproducts: true,
  productCategory: {},
};

// getters
const getters = {
  productCategories: state => state.productCategories,
  message: state => state.message,
};

// actions 
const actions = {
  addProductCategory({ commit, state }, { formData } ) {
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
  editProductCategory({ commit, state }, { prodCatIndex, productCatID, formData } ) {
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
  getaddProductCategories({ commit, state }, lastIndex ) {
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
  deleteProductCategory({ commit, state }, {productCategoryID, index} ) {
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
  getproductCategoryByName({ commit, state }, {name} ) {
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
  getProductsByproductCategoryName({ commit, state }, { name, lastIndex } ) {
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
        let message = 'An internal error occurred, please try again';
        if (error.response && error.response.status && error.response.status !== 500) {
          message = error.response.data;
        }
        return commit(MESSAGE, { message, recipient: 'adminProd'});
      });
  },
  editProduct({ commit, state }, { prodIndex, productID, formData } ) {
    commit(MESSAGE, { 
      message: 'Editting product....',
      recipient: 'adminProd'
    });
    commit(LOADING, null, { root: true });

    axios.put(`${state.domainUrl}/api/Product/Edit/${productID}`,
      formData,
      {
        headers: {
          'content-type': 'multipart/form-data',
        },
      },
    )
      .then(response =>  {
          commit(DONE, null, { root: true });
          commit(EDITTED_PRODUCT, { prodIndex, product: response.data});
        })
      .catch((error) => {
        commit(DONE, null, { root: true })
        let message = 'An internal error occurred, please try again';
        if (error.response && error.response.status && error.response.status !== 500) {
          message = error.response.data;
        }
        return commit(MESSAGE, { message, recipient: 'adminProd'});
      });
  },
  deleteProduct({ commit, state }, {productID, index} ) {
    commit(MESSAGE, { 
      message: `Deleting ${productID}`, 
      recipient: 'Products'
    });
    commit(LOADING, null, { root: true })
    axios.delete(`${state.domainUrl}/api/Product/${productID}`)
    .then(response => {
        commit(DONE, null, { root: true })
        return commit(DELETED_PRODUCT, index);
    })
    .catch(error => {
        commit(DONE, null, { root: true })
        let message = 'An internal error occurred, please try again';
        if (error.response && error.response.status && error.response.status !== 500) {
            message = error.response.data;
        }
        return commit(MESSAGE, { message, recipient: 'Products'});
    });
  },
};

// mutations
const mutations = {
  [ADDED_PRODUCT_CATEGORY](state, newProductCategory) {
    state.productCategories.unshift(newProductCategory);
    state.message = `${newProductCategory.name} has been added successfully`;
    state.messageRecipient = 'ProductCategory';
  },
  [ADDED_PRODUCT](state, newProduct) {
    state.products.unshift(newProduct);
    state.message = `${newProduct.name} has been added successfully`;
    state.messageRecipient = 'AdminProducts';
  },
  [MESSAGE](state, { message, recipient }) {
    state.message = message;

    switch (recipient) {
      case 'adminProd': 
        state.messageRecipient = 'AdminProducts';
        break;
      case 'products':
        state.messageRecipient = 'Products';
        break;
      case 'productCategory':
        state.messageRecipient = 'ProductCategory';
        break;
      case 'adminProdCat':
        state.messageRecipient = 'AdminProdCat';
       break;
      default:
        break;
    }

  },
  [ADDING_PRODUCT_CATEGORY](state) {
    state.message = 'Registrying new Product Category ......';
    state.messageRecipient = 'ProductCategory';
  },
  [FETCHING_PRODUCT_CATEGORIES](state) {
    state.message = 'Fetching Product Categories ......';
    state.messageRecipient = 'ProductCategory';
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
    state.messageRecipient = 'Products';
  },
  [FETCHING_PRODUCTS](state) {
    state.messageRecipient = 'Products';
    state.message = `Fetching Products ......`;
  },
  [FETCH_PRODUCTS](state, { lastIndex, payload}) {
    state.message = null;
    state.messageRecipient = null;
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
    state.messageRecipient = 'AdminProdCat';
    state.message = `Editing product Category ......`;
  },
  [EDITED](state, { prodCatIndex, productCategory}) {
    state.messageRecipient = 'AdminProdCat';
    state.message = `${productCategory.name} has been updated successfully ......`;
    state.productCategories[prodCatIndex] = productCategory;
  },
  [EDITTED_PRODUCT](state, { productIndex, product}) {
    state.messageRecipient = 'AdminProducts';
    state.message = `${product.name} has been updated successfully ......`;
    state.products[productIndex] = product;
  },
  [DELETED_PRODUCT_CATEGORY](state, productCategoryIndex) {
    state.messageRecipient = 'ProductCategory';
    state.message = `${state.productCategories[productCategoryIndex].name} has been deleted successfully ......`;
    state.productCategories.splice(productCategoryIndex, 1);
  },
  [DELETED_PRODUCT](state, productIndex) {
    state.messageRecipient = 'Products';
    state.message = `${state.products[productIndex].name} has been deleted successfully ......`;
    state.products.splice(productIndex, 1);
  },
  [ADDING_PRODUCT](state) {
    state.message = `Registrying new Product  ......`;
    state.messageRecipient = 'AdminProducts';
  },
};

export default {
  namespaced: true,
  state,
  getters,
  actions,
  mutations,
};
