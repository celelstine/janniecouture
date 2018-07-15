
import axios from 'axios';
import {
    SIGN_IN,
    MESSAGE,
    LOGOUT,
    DONE,
    LOADING
    } from '../mutation-types';
import router from '../../router';
/* eslint-disable no-shadow  */
// initial state
const state = {
  userName: null,
  domainUrl: 'http://localhost:5001',
  jwt: null,
  message: '',
  messageForLogin: null,
  messageForSignup: null,
  userCategory: null,
  messageForConfirmPassword: null,
  roles: null,
};

// getters
const getters = {
  userName: state => state.userName,
  jwt: state => state.jwt,
  message: state => state.message,
};

// actions
const actions = {
  confirmAccount({ commit, state }, credentials ) {
    commit(LOADING, null, { root: true })
        axios
        .get(`${state.domainUrl}/Account/ConfirmEmailAPI?userId=${credentials.userId}&code=${credentials.userCode}`)
        .then(response => {
            commit(DONE, null, { root: true });
            commit(SIGN_IN, { ...response.data });
         })
        .catch((error) => {
            localStorage.removeItem('32snksnsknskn');
            let message = 'An internal error occurred, please try again';
            if (error.response && error.response.status && error.response.status !== 500) {
              message = error.response.data;
            }
            return commit(MESSAGE, { recipient: 'confirmPassword', message });
        });
  },
  login({ commit, state }, credentials) {
    commit(LOADING, null, { root: true })
    commit(MESSAGE, { recipient: 'login', message: 'Processing your request....' });
    axios.post(`${state.domainUrl}/Account/Login`, credentials)
      .then(response => {
        commit(DONE, null, { root: true });
        commit(SIGN_IN, { ...response.data });
      })
      .catch((error) => {
        localStorage.removeItem('32snksnsknskn');
        let message = 'An internal error occurred, please try again';
        if (error.response && error.response.status && error.response.status !== 500) {
          message = error.response.data;
        }
        return commit(MESSAGE, { recipient: 'login', message });
      });
  },
  signup({ commit, state }, credentials) {
    commit(LOADING, null, { root: true })
    commit(MESSAGE, { recipient: 'signup', message: 'Registrying your Account....' });
    axios.post(`${state.domainUrl}/Account/Register`, credentials)
      .then(response => {
        commit(DONE, null, { root: true });
        commit(MESSAGE, {
            messagefor: 'signup',
            message: 'You have successfully signup, please check your mail and verifiy your account' 
        })
      })
      .catch((error) => {
        localStorage.removeItem('32snksnsknskn');
        let message = 'An internal error occurred, please try again';
        if (error.response && error.response.status && error.response.status !== 500) {
          message = error.response.data;
        }
        return commit(MESSAGE, { recipient: 'signup', message });
      });
  },
  // remeberMeLogin({ commit }, credentials, fromHome = false) {
    // commit(SIGN_IN, { ...credentials, fromHome });
  // },
  logout({ commit }) {
    commit(LOGOUT, { });
  },
};

// mutations
const mutations = {
  [SIGN_IN](state, {
    jwt,
    userName,
    roles
  }) {
    state.userName = userName;
    state.jwt = jwt;
    // state.userCategory = userCategory;
    // clear former message
    state.message = '';
    state.messageForLogin = null;
    state.fromSignup = null;
    state.roles = roles;
    // router.push({ path: '/' });
    // if (!fromHome) {
      // router.push({ path: '/sellCard' });
    // }
    // add the jwt to all http request
    axios.defaults.headers.common.Authorization = jwt;
  },
  [MESSAGE](state, { recipient , message }) {
    state.messageForLogin = false;
    state.fromSignup = false;
    state.messageForConfirmPassword = false;
    state.message = message;
    if (recipient === 'login') {
      state.messageForLogin = true;
    } else if (recipient === 'signup') {
      state.messageForSignup = true;
    }
    else if (recipient === 'confirmPassword') {
        state.messageForConfirmPassword = true;
    }
  },
  [LOGOUT](state) {
    state.userFullname = null;
    state.email = null;
    state.jwtToken = null;
    localStorage.removeItem('32snksnsknskn');
    router.push({ path: '/' });
  },
};

export default {
  namespaced: true,
  state,
  getters,
  actions,
  mutations,
};