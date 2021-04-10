<template>
  <div id='sidedetails' >
    <span id='brewerydetails' v-if='$store.state.editingMode===0 && Object.keys(currentBeer).length === 0'>
    <h1 id="name">{{currentBrewery.name}}</h1>
    <h2 id="details"></h2>
    <h2 id="ratings"></h2>
    <h2 id="reviews"></h2>
    <brewery-review-form :brewery='currentBrewery'/>
    <review-display :review-id='currentBrewery.breweryId' :review-type='Object.keys(currentBeer).length !== 0'/>
    </span>
    <span id='beerdetails' v-else-if='$store.state.editingMode===0 '>
    <h1 id="name">{{currentBeer.name}}</h1>
    <h2 id="details"></h2>
    <h2 id="ratings"></h2>
    <h2 id="reviews"></h2>
    <beer-review-form :beer='currentBeer'/>
    <review-display :review-id='currentBeer[0].beerId' :review-type='Object.keys(currentBeer).length !== 0'/>
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
import BeerReviewForm from '@/components/BeerReviewForm.vue'
import BreweryReviewForm from '@/components/BreweryReviewForm.vue'
export default {
    components: {
        BeerReviewForm,
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
    props:['currentBrewery','currentBeer']
}
</script>

<style>
#sidedetails{
flex-grow: 1;
flex-direction:row;
background-color: rgb(53,53,53);
  border: 2px solid black;
  border-radius: 10px;
  box-shadow: 5px 5px 3px black;
}

</style>