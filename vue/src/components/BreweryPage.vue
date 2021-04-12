<template>
  <div id="brewery-page">
  <div class="inner-block">
    <h1 id="brewery-name">{{brewery.name}}</h1>
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
  display: flex;
  background-color: rgb(53,53,53);
  border: 2px solid black;
  border-radius: 10px;
  box-shadow: 5px 5px 3px black;
  padding: 1rem;
  justify-content: center;
}

.inner-block {
  display: flex;
  background-color: white;
  border-radius: 10px;
  padding: 1rem;
  flex-direction: column;
  width: 100%;
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