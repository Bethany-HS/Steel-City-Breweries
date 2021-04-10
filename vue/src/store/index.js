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
<<<<<<< HEAD

=======
>>>>>>> 64c8c80ffaf88a6cf1d7a2c7661be8f295bc0b41
if(currentToken != null) {
  axios.defaults.headers.common['Authorization'] = `Bearer ${currentToken}`;
}
else{
  localStorage.removeItem('user')
}
<<<<<<< HEAD

=======
>>>>>>> 64c8c80ffaf88a6cf1d7a2c7661be8f295bc0b41
const currentUser = JSON.parse(localStorage.getItem('user'));

export default new Vuex.Store({
  state: {
    token: currentToken || '',
    user: currentUser || {},
    currentDisplay : 1,
    currentBrewery : {},
    currentBeer : {},
    editingMode:0,
    breweries:[],
    beers:[],
    beerReviews:[],
    breweryReviews:[],
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
      state.breweryReviews.unshift(breweryReview);
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
