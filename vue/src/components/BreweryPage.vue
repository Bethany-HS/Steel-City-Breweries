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
        <button v-bind:class="{'mark-favorited': !FavBrewery}" v-if="!FavBrewery" v-on:click="addFavorite">Favorite</button>
        <button v-bind:class="{'mark-unfavorited': FavBrewery}" v-if="FavBrewery" v-on:click="deleteFavorite">UnFavorite</button> 
  </div>
  </div>
</template>

<script>
import ReviewDisplay from '@/components/ReviewDisplay.vue'
import AverageBreweryRating from '@/components/AverageBreweryRating.vue'
import FavService from '@/services/FavService.js'

export default {
  data(){
    return{
      
     
    }

  },
  methods:{
      addFavorite(){
          FavService.addFavorites(this.newFav)
          .then(response =>{
            if(response.status ===201){
              this.$store.commit('ADD_USER_FAVORITE', this.brewery.breweryId);
              
            }
          
          })
      },
      deleteFavorite(){
        FavService.deleteFavorite(this.newFav)
        .then(response =>{
          if (response.status === 204){
            this.$store.commit('DELETE_USER_FAVORITE', this.brewery.breweryId);
            
          }
        })
      }
  },
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
    },
     newFav(){
       return {
          UserId: this.$store.state.user.userId,
          BreweryId: this.brewery.breweryId
          }
      },
      FavBrewery(){
        return this.$store.state.userFavorites.includes(this.brewery.breweryId);
      } 
  }
}
</script>

<style>
#brewery-page
{
  display: flex;
  flex-grow: 1;
    background-color: rgba(53, 53, 53, 0.8);
  border: 2px solid black;
  border-radius: 10px;
  box-shadow: 5px 5px 3px black;
  padding: 1rem;
  justify-content: center;
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
review-display{
  padding-left: 30px;
}

</style>