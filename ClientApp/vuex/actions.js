﻿
import axios from 'axios'
import {
    PROCESSING_REQUEST,
    FETCH_AGERANGE,
    ERROR,
    FECTH_PRODUCT_TAG
    } from './mutation-types';

export const fetchAgeRange = ({ commit, state }) => {
    commit(PROCESSING_REQUEST);
    axios.get(`${state.domainUrl}/api/AgeRange`).then(response => {
        console.log('--->', response.data);
        commit(FETCH_AGERANGE, response.data);
    }).catch(err => {
        console.log('--->>', err);
        commit(ERROR, err.response.data);
    });
}

export const fetchProductTag = ({ commit, state }) => {
    commit(PROCESSING_REQUEST);
    axios.get(`${state.domainUrl}/api/productTag`).then(response => {
        commit(FECTH_PRODUCT_TAG, response.data);
    }).catch(err => {
        commit(ERROR, err.response.data);
    });
}