<template>
  <div class="home">
    <div class="header">
    <img src="../assets/logo1.png">
    </div>
    <span id='main-page'>
    <side-nav id='sidenav'/>
    <content-page id='content' />
    </span>
  </div>
</template>

<script>
import breweryService from "@/services/BreweryService.js";
import beerService from "@/services/BeerService.js";

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
  },
  methods:{
    
  }
}
</script>

<style>
#main-page{
  display: flex;
  justify-content: stretch;
  align-items: stretch;
}
#sidenav{
  flex-grow:1;
}
#content{
  flex-grow: 5;
    display: block;
    background: rgb(53, 53, 53);
    color: white;
    text-shadow: 3px 3px black;
}
</style>
