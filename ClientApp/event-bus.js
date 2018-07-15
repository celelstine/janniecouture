/*
* This vue instance is used to create connection between the entire vue ecosystem
* Any component irrespective of this position on the tree can publish an event through this instance
* and other components would used the instance
*/
import Vue from 'vue';
export const EventBus = new Vue();