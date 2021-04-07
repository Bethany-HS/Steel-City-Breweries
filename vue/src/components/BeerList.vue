<template>
  <div id='viewBeers' >
    <span id='beerlist'>
      <span v-for='beer in currentBeers' :key='beer.beerId' :id=beer.beerId>
        <h1>{{beer.name}} {{beer.abv}}</h1>
      </span>
    </span>
    <side-details/>
  </div>
</template>

<script>
import SideDetails from '@/components/SideDetails.vue'
export default {
    components: {
        SideDetails
    },
    computed:{
      currentBeers(){
        return this.$store.state.beers;
      },
    methods: {
        loadInfo() {}
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
