<template>
  <div id="brewery-page">
  <div class="inner-block-brewery">
    <img class="upload" :src='picture'/>
    <h1 id="brewery-name">{{brewery.name}}</h1>
    <div v-if="loggedOn">
        <!-- <button class="fav-btn" v-bind:class="{'mark-favorited': !FavBrewery}" v-if='!FavBrewery' v-on:click="addFavorite">Favorite</button>
        <button class="fav-btn" v-bind:class="{'mark-unfavorited': FavBrewery}" v-if='FavBrewery' v-on:click="deleteFavorite">Unfavorite</button> -->
        <span v-bind:class="{'mark-favorited': !FavBrewery}" v-if='!FavBrewery' v-on:click="addFavorite">Favorite<font-awesome-icon :icon="['fas', 'star']"  class= 'favorite' ></font-awesome-icon></span>
        <span v-bind:class="{'mark-unfavorited': FavBrewery}" v-if='FavBrewery' v-on:click="deleteFavorite">Favorite<font-awesome-icon :icon="['fas', 'star']" class="not-favorite" ></font-awesome-icon></span>
        </div>

        <h2>Location</h2>
        <p>{{brewery.streetAddress1}}</p>
        <h2>Brewery Description</h2>
        <p>{{brewery.history}}</p>
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
import FavService from '@/services/FavService.js'

export default {
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
      picture(){ 
        return localStorage.breweryPicture
      },
      brewery(){
        return this.$store.state.currentBrewery
      },
      beers(){
        return this.$store.state.beers.filter(beer =>beer.breweryId === this.brewery.breweryId && beer.isActive ===1 )
    },
     newFav(){
       return {
          UserId: this.$store.state.user.userId,
          BreweryId: this.brewery.breweryId
          }
      },
      FavBrewery(){
        return this.$store.state.userFavorites.includes(this.brewery.breweryId);
      },
      loggedOn(){
       return localStorage.getItem("user")!==null
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
  overflow: auto;
}
.upload{
  width:50%;
  height:300px
}

review-display{
  padding-left: 30px;
}
#brewery-name{
  font-size: 3em;
}

h1, h2, h3, p
{
  text-align: center;
}

.mark-favorited
{
  font-size: 2em;
  font-weight: bold;
  width: 100%;
  border: 2px solid black;
  border-radius: 10px;
  padding: 0px 5px 0px 5px;
  margin-left: 0px;
  margin-right: 0px;
  cursor: pointer;
}
.mark-unfavorited > .not-favorite {
  color: gold;
}

.mark-unfavorited
{ 
  font-size: 2em;
  font-weight: bold;
  width: 100%;
  border: 2px solid black;
  border-radius: 10px;
  padding: 0px 5px 0px 5px;
  margin-left: 0px;
  margin-right: 0px;
  cursor: pointer;
}
.inner-block-brewery {
  display: flex;
  flex-basis: 100%;
  align-items:center;
  flex-direction: column;
  background-color: white;
}

</style>