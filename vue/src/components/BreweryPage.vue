<template>
  <div id="brewery-page">
    <h1>{{brewery.name}}</h1>
        <h2>Location</h2>
        <p>{{brewery.streetAddress1}}</p>
        <h2>Brewery Description</h2>
        <p>{{brewery.description}}</p>
        <h2>View Beer List</h2>
        <p v-for='beer in beers' :key='beer.beerId'>{{beer.name}}</p>
        <h2>Ratings and Reviews</h2>
        <average-brewery-rating :number-of-brewery="brewery.breweryId" />
        <review-display :review-id='brewery.breweryId' :review-type='false'/>
  </div>
</template>

<script>
import ReviewDisplay from '@/components/ReviewDisplay.vue'
import AverageBreweryRating from '@/components/AverageBreweryRating.vue'
export default {
  components: { 
      ReviewDisplay,
      AverageBreweryRating
      },
  computed: {
      brewery(){
        return this.$store.state.currentBrewery
      },
      beers(){
        return this.$store.state.beers.filter(beer =>beer.breweryId === this.brewery.breweryId)
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