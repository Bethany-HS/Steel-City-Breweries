<template>
  <div id="main">
      <img id="beer-image-bckgrnd" src="@/images/beer-glass-in-brewery.jpg"/>
      <h1 id="intro-txt">
        Find the right brew for you!
      </h1>
      <h3 id="search-our-list-txt">
        -Search our list of breweries in the Pittsburgh area
      </h3>
        <img id="google-map-image" src="@/images/PGHBreweries_GoogleMaps.png"/>
      <beer-list/>
  </div>
</template>

<script>
import BeerList from '@/components/BeerList.vue'
export default {
    name: "anonymous-user-page",
  components: { 
      BeerList 
      },
}
</script>

<style>
#main {
    display: flex;
    display: grid;
}
#beer-image-bckgrnd {
    background-image: "@/images/beer-glass-in-brewery.jpg";
    height: 100%;
    width: 100%;
}

#main-page > h1, h3 {

}

#google-map-image {

}
</style>