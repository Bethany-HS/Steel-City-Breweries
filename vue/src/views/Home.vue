<template>
  <div class="home">
    <div id="header">
      <img src="../assets/logo1.png">
    </div>
    <div id='main-page'>
      <side-nav class='sidenav'/>
      <content-page id='content' />
    </div>
  </div>
</template>

<script>
import breweryService from "@/services/BreweryService.js";
import beerService from "@/services/BeerService.js";
import reviewService from "@/services/ReviewService.js";

import SideNav from '@/components/SideNav.vue';
import ContentPage from '@/components/ContentPage.vue';

export default {
  name: "home",
  components: {
    SideNav,
    ContentPage
  },
  created(){
    breweryService.getBreweries().then(response => {
      this.$store.state.breweries =  response.data;
    })
    beerService.getBeers().then(response => {
      this.$store.state.beers = response.data;
    })
    reviewService.getBeerReviews().then(response => {
      this.$store.state.beerReviews = response.data;
    })
    reviewService.getBreweryReviews().then(response => {
      this.$store.state.breweryReviews = response.data;
    })
  },
  methods:{
    
  }
}
</script>

<style>
.home{
  height:100%;
}
#main-page{
  display: flex;
  justify-content: stretch;
  align-items: stretch;
  height:77%

}

#content{
    flex-basis: 100%;
    display: flex;
    color: black;
    margin-left: 25px;
}


</style>
