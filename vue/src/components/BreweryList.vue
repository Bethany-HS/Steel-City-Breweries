<template>
    <div id='viewBreweries'>
    <div id='brewerylist'>
      <div id="brewery" v-for='brewery in currentBreweries' :key='brewery.breweryId' @click='showSideMenu(brewery.breweryId)'>
        <h1>{{brewery.name}} </h1>
      </div>
    </div>
    <side-details :current-brewery='currentBrewery[0].breweryId' :current-beer='-1' v-if='showSideDetails'/>
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

<style >
#viewBreweries
{
   display: flex;
   flex-basis: 100%;
   flex-grow: 1;
}
#brewerylist
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

#brewery
{
  margin-bottom: 10px;
  background-color: rgb(53,53,53);
  border: 2px solid black;
  border-radius: 10px;
  box-shadow: 5px 5px 3px black;
}

#brewery > h1
{
  margin-left: 10px;
}
</style>
