<template>
  <div class="home">
    <div id="header">
    <img src="../assets/logo1.png">
    </div>
    <span id='main-page'>
    <side-nav class='sidenav'/>
    <content-page id='content' />
    </span>
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
.home {
  display: grid;
  grid-gap: 50px;
  justify-items: center;
  align-items: center;
}

#header {
  display: grid;
}

#content{
    color: black;
    margin-left: 25px;
}


</style>
