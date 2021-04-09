<template>
  <div id='sidedetails' >
    <span id='generaldetails' v-if='$store.state.editingMode===0'>
    <h1 id="name"></h1>
    <h2 id="details"></h2>
    <h2 id="ratings"></h2>
    <h2 id="reviews"></h2>
    <!-- <beer-review-form/> -->
    <brewery-review-form/>
    <review-display/>
    </span>
    <span  id='brewerydetails' v-if='$store.state.editingMode===1'>
      <h1 >{{this.currentBrewery}}</h1>
      <button>Edit Brewery Info</button>
      <button @click="$store.commit('SET_CURRENT_PAGE',4)">Manage Beers</button>
    </span>
    <span id='beerdetails' v-if='$store.state.editingMode===2'>
      <button>Edit Beer Info</button>
    </span>

  </div>

</template>

<script>
import ReviewDisplay from '@/components/ReviewDisplay.vue'
// import BeerReviewForm from '@/components/BeerReviewForm.vue'
import BreweryReviewForm from '@/components/BreweryReviewForm.vue'
export default {
    components: {
        // BeerReviewForm,
        ReviewDisplay,
        BreweryReviewForm
    },
    data() {  
      return{
        reviews: [],
        ratings: [],
        
      }
    },
    methods: {},
    props:['currentBrewery']
}
</script>

<style>
#sidedetails{
flex-grow: 1;
background-color: royalblue;
flex-direction:row;

}

</style>