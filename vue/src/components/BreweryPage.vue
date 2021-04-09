<template>
  <div id="brewery-page">
    <h1>{{brewery.name}}</h1>
        <h2>Location</h2>
        <p>{{brewery.streetAddress1}}</p>
        <h2>Brewery Description</h2>
        <p>{{brewery.description}}</p>
        <h2>View Beer List</h2>
        <p>{{beers}}</p>
        <h2>Ratings and Reviews</h2>
        <review-display/>
  </div>
</template>

<script>
import ReviewDisplay from '@/components/ReviewDisplay.vue'
export default {
  components: { 
      ReviewDisplay 
      },
  computed: {
      brewery(){
        return this.$store.state.breweries.filter(brewery =>
        brewery.breweryId === this.$store.state.currentBrewery)[0]
      },
      beers(){
        return this.$store.state.beers.filter(beer =>{
        beer.breweryId === this.brewery.breweryId})
    }
  }
}
</script>

<style>
#brewery-page
{
  background-color: rgb(53,53,53);
  border: 2px solid black;
  border-radius: 10px;
  box-shadow: 5px 5px 3px black;
}

p
{
  padding-left: 30px;
}

h1
{
margin-left: 10px;
}

h2
{
  margin-left: 20px;
}

</style>