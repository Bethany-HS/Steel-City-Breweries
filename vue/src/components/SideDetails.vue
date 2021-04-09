<template>
  <div id='sidedetails' >
    <span id='generaldetails' v-if='$store.state.editingMode===0'>
    <h1 id="name"></h1>
    <h2 id="details"></h2>
    <h2 id="ratings"></h2>
    <h2 id="reviews"></h2>
    <beer-review-form v-if='currentBeer>=0'/>
    <brewery-review-form v-if='currentBrewery>=0'/>
    <review-display :review-type='currentBeer>=0'/>
    <button @click="goToBrewery()">View Brewery Details</button>
    <button @click="goToBeer()">View Beer Details</button>
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
    methods: {
      goToBrewery(){
        this.$store.state.currentBrewery = this.currentBrewery;
        this.$store.commit('SET_CURRENT_PAGE', 5)
      },
      goToBeer(){
        this.$store.state.currentBeer = this.currentBeer;
        this.$store.commit('SET_CURRENT_PAGE', 6)
      }
    },
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