import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

/*
 * The authorization header is set for axios when you login but what happens when you come back or
 * the page is refreshed. When that happens you need to check for the token in local storage and if it
 * exists you should set the header so that it will be attached to each request
 */
const currentToken = localStorage.getItem('token')
const currentUser = JSON.parse(localStorage.getItem('user'));

if(currentToken != null) {
  axios.defaults.headers.common['Authorization'] = `Bearer ${currentToken}`;
}

export default new Vuex.Store({
  state: {
    token: currentToken || '',
    user: currentUser || {},
    currentDisplay : 1,
    editingMode:0,
    breweries:[],
    beers:[],
    beerReviews:[],
    breweryReviews:[]
  },
  mutations: {
    SET_AUTH_TOKEN(state, token) {
      state.token = token;
      localStorage.setItem('token', token);
      axios.defaults.headers.common['Authorization'] = `Bearer ${token}`
    },
    SET_USER(state, user) {
      state.user = user;
      localStorage.setItem('user',JSON.stringify(user));
    },
    LOGOUT(state) {
      localStorage.removeItem('token');
      localStorage.removeItem('user');
      state.token = '';
      state.user = {};
      axios.defaults.headers.common = {};
    },
    ADD_BREWERY_REVIEW(state, breweryReview) {
      state.beerReviews.unshift(breweryReview);
    },
    ADD_BEER_REVIEW(state, beerReview) {
      state.beerReviews.unshift(beerReview);
    },
    SET_CURRENT_PAGE(state,id){
      state.currentDisplay = id
    },
    SET_EDITING_MODE(state,id){
      state.editingMode = id;
    },
    ADD_BEER(state, beer){
      state.beers.unshift(beer);
    },
    ADD_BREWERY(state, brewery){
      state.breweries.unshift(brewery);
    },
    MAKE_REVIEW_PRIVATE(state, reviewToPrivate) {
      reviewToPrivate.private = ! reviewToPrivate.private;
    }
  }
})
