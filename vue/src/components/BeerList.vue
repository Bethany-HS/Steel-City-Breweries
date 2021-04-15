<template>
  <div id='viewBeers' >
    <div id='beerlist'>
      <div id="beer" v-for='beer in currentBeers' :key='beer.beerId' @click='showSideMenu(beer.beerId)'>
        <div class="inner-block">
        <h2>
          <span>{{beer.name}}</span>
          <span>{{$store.state.beerTypeIdList[beer.beerTypeId]}}</span>
          <span id="abv">{{beer.abv}}%</span>
        </h2>
        <average-beer-rating class="avgRating" :number-of-beer="beer.beerId"/>
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
        currentBeer: {},
        test:''
      }
    },
    components: {
        SideDetails,
        AverageBeerRating,
    },
    computed:{
      currentBeers(){
        return this.$store.state.beers.filter(x=>x.isActive === 1);
      }
    },
    methods: {
        showSideMenu(id){
        this.$store.state.showReviewForm = false;
        this.currentBeer  = this.currentBeers.filter(x => x.beerId === id)
        this.showSideDetails = true
        this.test = document.getElementsByTagName("side-details")[0]
      }
    }
}
</script>

<style >

#viewBeers
{
  display: flex;
  flex-basis: 100%;
  height :100%;

}
#abv {
  display: flex;
  margin-right: 10px;
}

#beerlist
{
  display: flex;
  flex-direction: column;
    flex-basis: 60%;
  margin-right: 30px;
    overflow:auto;
}

#beer
{
  display: flex;

  margin-bottom: 10px;
  margin-right:10px;
    background-color: rgba(53, 53, 53, 0.8);
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

.inner-block {
  display: flex;
  background-color: white;
  border-radius: 10px;
  padding: 1rem;
  flex-direction: column;
  justify-content: stretch;
  flex-basis:100%
}

side-details{
  display: flex;
  flex-basis: 60%;
  margin-right: 30px;
}
</style>
