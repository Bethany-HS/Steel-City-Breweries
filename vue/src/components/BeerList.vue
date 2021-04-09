<template>
  <div id='viewBeers' >
    <div id='beerlist'>
      <div id="beer" v-for='beer in currentBeers' :key='beer.beerId' @click='showSideMenu(beer.beerId)'>
        <h1>{{beer.name}} {{beer.abv}}</h1>
        <h2>{{beer.ingredients}} {{beer.description}}</h2>
      </div>
    </div>
    <side-details :current-brewery='-1' :current-beer='currentBeer[0].beerId' v-if='showSideDetails'/>

  </div>
</template>

<script>
import SideDetails from '@/components/SideDetails.vue'
export default {
    data(){
      return{
        showSideDetails:false,
        currentBeer: {}
      }
    },
    components: {
        SideDetails,
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
#beerlist
{
  flex-direction: column;
  flex-basis: 60%;
  margin-right: 30px;

}

side-details
{
  flex-basis: 30%;
  justify-content: center;
}

#beer
{
  margin-bottom: 10px;
  background-color: rgb(53,53,53);
  border: 2px solid black;
  border-radius: 10px;
  box-shadow: 5px 5px 3px black;
}

#beer:hover
{
  background-color: rgb(85, 85, 85);
}
#beer > h1, h2
{
  margin-left: 10px;
}
</style>
