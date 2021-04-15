<template>
  <div class="home">
    <div id="header" >
      <img v-if='!hover' src="../assets/logo1.png" @click='hover = true'>
      <img v-if='hover' src="../assets/logo2.png" @click='hover = false'>
    </div>
    <div class='main-page'>
      <side-nav class='sidenav'/>
      <content-page class='content'/>
    </div>
  </div>
</template>

<script>
import breweryService from "@/services/BreweryService.js";
import beerService from "@/services/BeerService.js";
import reviewService from "@/services/ReviewService.js";
import FavService from '@/services/FavService.js';

import SideNav from '@/components/SideNav.vue';
import ContentPage from '@/components/ContentPage.vue';

export default {
  name: "home",
  data() {
  return {
    hover: false,
  }
  },
  
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
    if(this.loggedOn){
    FavService.getFavorites(this.$store.state.user.userId)
    .then(response =>{
      let array = [];
      response.data.forEach((favorite)=>{
        array.push(favorite.breweryID)
      })
      this.$store.state.userFavorites= array;
    })
    }
  },
  methods:{
    
  },
  computed:{
    loggedOn(){
      return localStorage.getItem("user")!==null
    },
    logo(){
      if(this.hover){
        return "../assets/logo2.png";
      }
        return "../assets/logo1.png";
    }
  }
}
</script>

<style>
.home{
  height:100%;
}
.main-page{
  display: flex;
  justify-content: stretch;
  align-items: stretch;
  height: 77%;
}

.content{
    flex-basis: 100%;
    display: flex;
    color: black;
    height: 100%;
    overflow: auto;
}

@media only screen and (max-width: 800px) {
  .main-page {
    flex: 100%;
    flex-direction: column;
    box-sizing: border-box;
    font-size: 75%;
  }
}
</style>
