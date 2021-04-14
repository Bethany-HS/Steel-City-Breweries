<template>
    <div id='viewBreweries'>
      <div id='brewerylist'>
        <div id="brewery" v-for='brewery in currentBreweries' :key='brewery.breweryId' @click='showSideMenu(brewery.breweryId)'>
          <div class="inner-block"> 
            <h2>{{brewery.name}} </h2>
            <h2>{{brewery.city}} {{brewery.phone}}</h2>
            <average-brewery-rating class="avgRating" :number-of-brewery="brewery.breweryId"/>
          </div>
        </div>
      </div>
      <side-details :current-brewery='currentBrewery[0]' :current-beer='{}' v-if='showSideDetails'/>
    </div>
</template>

<script>
import SideDetails from '@/components/SideDetails.vue'
import AverageBreweryRating from '@/components/AverageBreweryRating.vue'
export default {
  data(){
    return{
      showSideDetails:false,
      currentBrewery: {}
    }
  },
    components: {
        SideDetails,
        AverageBreweryRating
    },
    computed:{
      currentBreweries(){
        return this.$store.state.breweries;
      }
    },
    methods: {
      showSideMenu(id){
        this.$store.state.showReviewForm = false;
        this.currentBrewery  = this.currentBreweries.filter(x => x.breweryId === id)
        this.showSideDetails = true
      }
    }
}
</script>

<style >
#viewBreweries
{
   display: flex;
   flex-basis: 100%;

}
#brewerylist
{
  display: flex;
  flex-direction: column;
  flex-basis: 60%;
  margin-right: 30px;
}

#brewery
{
  display: flex;
  margin-bottom: 10px;
    background-color: rgba(53, 53, 53, 0.8);
  border: 2px solid black;
  border-radius: 10px;
  box-shadow: 5px 5px 3px black;
  padding: 1rem;
  justify-content: center;
}

#brewery:hover
{
  background-color: rgb(85, 85, 85);
}

#brewery > h1, h2
{
  display: flex;
  margin-left: 10px;
}
</style>
