<template>
  <div id="beer-page">
    <h1>{{beer.name}}</h1>
        <h2>Location</h2>
        <p>{{beer.beerTypeId}}</p>
        <h2>Beer Description</h2>
        <p>{{beer.description}}</p>

        <p></p>
        <h2>Ratings and Reviews</h2>
        <review-display :review-id='beer.beerId' :review-type='true'/>
  </div>
</template>

<script>
import ReviewDisplay from '@/components/ReviewDisplay.vue'
export default {
  components: { 
      ReviewDisplay 
      },
  computed: {
      beer(){
        return this.$store.state.beers.filter(beer =>beer.beerId === this.$store.state.currentBeer.beerId)[0]
      }
  }
}
</script>

<style>
#beer-page
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