<template>
    <div id='viewBreweries'>
    <div id='brewerylist'>
      <div id="brewery" v-for='brewery in currentBreweries' :key='brewery.breweryId' @click='showSideMenu(brewery.breweryId)'>
        <div class="inner-block"> 
        <h2>{{brewery.name}} </h2>
        <h2>{{brewery.city}} {{brewery.phone}}</h2>
        </div>
      </div>
    </div>
    <side-details :current-brewery='currentBrewery[0]' :current-beer='{}' v-if='showSideDetails'/>
    </div>
</template>

<script>
import SideDetails from '@/components/SideDetails.vue'
export default {
  data(){
    return{
      showSideDetails:false,
      currentBrewery: {}
    }
  },
    components: {
        SideDetails
    },
    computed:{
      currentBreweries(){
        return this.$store.state.breweries;
      }
    },
    methods: {
      showSideMenu(id){
        this.currentBrewery  = this.currentBreweries.filter(x => x.breweryId === id)
        this.showSideDetails = true
      }
    }
}
</script>

<style>
#viewBreweries
{
   display: flex;
   flex-basis: 100%;
   flex-grow: 1;
}

#brewerylist
{
  display: flex;
  flex-direction: column;
  margin-right: 30px;
  background-color: white;
}

#brewery
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
