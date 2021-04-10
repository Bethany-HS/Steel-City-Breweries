<template>
  <div id='sidedetails' >
    <span id='brewerydetails' v-if='$store.state.editingMode===0 && Object.keys(currentBeer).length === 0'>
    <h1 id="name">{{currentBrewery.name}}</h1>
    <h2 id="details"></h2>
    <h2 id="ratings"></h2>
    <h2 id="reviews"></h2>
    <button @click="goToBrewery()">View Brewery Details</button>
    <brewery-review-form :brewery='currentBrewery'/>
    <review-display :review-id='currentBrewery.breweryId' :review-type='Object.keys(currentBeer).length !== 0'/>
    </span>
    <span id='beerdetails' v-else-if='$store.state.editingMode===0 '>
    <h1 id="name">{{currentBeer.name}}</h1>
    <h2 id="details"></h2>
    <h2 id="ratings"></h2>
    <h2 id="reviews"></h2>
    <button @click="goToBeer()">View Beer Details</button>
    <beer-review-form :beer='currentBeer'/>
    <review-display :review-id='currentBeer[0].beerId' :review-type='Object.keys(currentBeer).length !== 0'/>
    </span>
    
    <span  id='brewerydetails' v-if='$store.state.editingMode===1'>
      <h1 >{{brewery.name}}</h1>
      <edit-brewery-form :brewery='brewery'/>
      <button @click="navigateToManageBeers()">Manage Beers</button>
    </span>
    <span id='beerdetails' v-if='$store.state.editingMode===2'>
      <h1>{{currentBeer.name}}</h1>
      <edit-beer-form :beer='currentBeer'/>
    </span>

  </div>

</template>

<script>
import ReviewDisplay from '@/components/ReviewDisplay.vue'
import BeerReviewForm from '@/components/BeerReviewForm.vue'
import BreweryReviewForm from '@/components/BreweryReviewForm.vue'
import EditBreweryForm from '@/components/EditBreweryForm.vue'
import EditBeerForm from '@/components/EditBeerForm.vue'
export default {
    components: {
        BeerReviewForm,
        ReviewDisplay,
        BreweryReviewForm,
        EditBreweryForm,
        EditBeerForm
    },
    methods: {
      goToBrewery(){
        this.$store.state.currentBrewery = this.currentBrewery;
        this.$store.commit('SET_CURRENT_PAGE', 5)
      },
      navigateToManageBeers(){
        this.$store.state.currentBrewery = this.currentBrewery;
        this.$store.commit('SET_CURRENT_PAGE',4)
      },
      goToBeer(){
        this.$store.state.currentBeer = this.currentBeer[0];
        this.$store.commit('SET_CURRENT_PAGE', 6)
      }
    },
    props:['currentBrewery','currentBeer'],
    computed:{
      brewery(){
        return this.$store.state.breweries.filter(x=>this.$store.state.currentBrewery ===x.breweryId)[0]
      },
      beer(){
        return this.$store.state.beers.filter(x=>this.$store.state.currentBeer ===x.beerId)[0]
      }
    }
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