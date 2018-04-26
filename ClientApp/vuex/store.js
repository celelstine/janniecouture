
import Vue from 'vue'
import Vuex from 'vuex'
import minBy from 'lodash/minBy';
import { fetchAgeRange } from './actions'
import 
    {
        PROCESSING_REQUEST,
        FECTH_AGERANGE,
        ERROR,
    } from './mutation-types';

Vue.use(Vuex)

const store = new Vuex.Store({
    state: { 
        message: '',
        ageRanges: [],
        isLoading: false,
        domainUrl: 'http://localhost:5001'
     },
    mutations: {
        PROCESSING_REQUEST: (state) => {
            state.message = null;
            state.isLoading = true;
        },
        FECTH_AGERANGE: (state, payload) => {
            state.message = null;
            state.isLoading = false;
            state.ageRanges = payload;
        },
        ERROR: (state, errorMessage) => {
            state.isLoading = false;
            state.message = errorMessage;
        }
    },
    actions: {
        fetchAgeRange,
    },
    getters: {
        message: state => state.message,
        ageRanges: state => state.ageRanges,
        domainUrl: state => state.domainUrl,
    }
});

export default store;