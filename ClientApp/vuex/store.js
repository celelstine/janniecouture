
import Vue from 'vue';
import Vuex from 'vuex';
import createLogger from 'vuex/dist/logger';
import minBy from 'lodash/minBy';
import { fetchAgeRange, fetchProductTag } from './actions'
import auth from './modules/auth.js';
import productCategory from './modules/productCategory.js';
import product from './modules/product.js';
import 
    {
        PROCESSING_REQUEST,
        FETCH_AGERANGE,
        ERROR,
        FETCH_PRODUCT_TAG
    } from './mutation-types';

Vue.use(Vuex)
const debug = process.env.NODE_ENV !== 'production';

const store = new Vuex.Store({
    state: { 
        message: '',
        ageRanges: [],
        isLoading: false,
        domainUrl: 'http://localhost:5001',
        showWelcomeJumbotron: true,
        productTags: [],
     },
    mutations: {
        PROCESSING_REQUEST: (state) => {
            state.message = null;
            state.isLoading = true;
        },
        FETCH_AGERANGE: (state, payload) => {
            state.message = null;
            state.isLoading = false;
            state.ageRanges = payload;
        },
        ERROR: (state, errorMessage) => {
            state.isLoading = false;
            state.message = errorMessage;
        },
        FETCH_PRODUCT_TAG: (state, payload) => {
            state.isLoading = false;
            state.productTags = payload;
            state.message = null;
        }
    },
    actions: {
        fetchAgeRange,
        fetchProductTag
    },
    getters: {
        message: state => state.message,
        ageRanges: state => state.ageRanges,
        domainUrl: state => state.domainUrl,
    },
    modules: {
        auth,
        productCategory,
        product
    },
    plugins: debug ? [createLogger()] : [],
});

export default store;