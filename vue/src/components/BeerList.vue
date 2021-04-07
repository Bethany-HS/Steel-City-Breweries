<template>
  <div id='viewBeers' >
    <span id='beerlist'>
      <span v-for='beer in currentBeers' :key='beer.beerId' :id='beer.beerId' @click='showSideMenu()'>
        <h1>{{beer.name}} {{beer.abv}}</h1>
      </span>
    </span>
    <side-details v-if='showSideDetails'/>

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
      showSideMenu(){
        this.showSideDetails = true
      }
    }
}
</script>

<style scoped>
#viewBeers{
  display: flex;

}
#beerlist{
  flex-grow:1;
  flex-direction: row;
  background-color: green;
}
#beerlist > span{
  flex-grow:1;
}

</style>
