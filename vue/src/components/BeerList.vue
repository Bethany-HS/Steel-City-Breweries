<template>
  <div id='viewBeers' >
    <div id='beerlist'>
      <div id="beer" v-for='beer in currentBeers' :key='beer.beerId' @click='showSideMenu(beer.beerId)'>
        <div class="inner-block">
        <h2>
          <span>{{beer.name}}</span>
          <span id="abv">{{beer.abv}}%</span>
        </h2>
        <average-beer-rating :number-of-beer="beer.beerId"/>
        </div>
      </div>
    </div>
    <side-details :current-brewery='{}' :current-beer='currentBeer' v-if='showSideDetails'/>
  </div>
</template>

<script>
import SideDetails from '@/components/SideDetails.vue'
import AverageBeerRating from '@/components/AverageBeerRating.vue'
export default {
    data(){
      return{
        showSideDetails:false,
        currentBeer: {}
      }
    },
    components: {
        SideDetails,
        AverageBeerRating,
    },
    computed:{
      currentBeers(){
        return this.$store.state.beers;
      }
    },
    methods: {
        showSideMenu(id){
        this.currentBeer  = this.currentBeers.filter(x => x.beerId === id)
        this.showSideDetails = true
      }
    }
}
</script>

<style scoped>

#viewBeers
{
  display: flex;
  flex-basis: 100%;
  flex-grow: 1;
}
#abv {
  display: flex;
  margin-right: 10px;
}

#beerlist
{
  flex-direction: column;
  flex-basis: 60%;
  margin-left: 20%;
}

#beer
{
  display: flex;
  margin-bottom: 10px;
  background-color: rgb(53,53,53);
  border: 2px solid black;
  border-radius: 10px;
  box-shadow: 5px 5px 3px black;
  padding: 1rem;
  justify-content: center;
}

#beer:hover
{
  background-color: rgb(85, 85, 85);
}
#beer > h1, h2
{
  display: flex;
  justify-content: space-between;
  margin-left: 10px;
}

</style>
