<template>
    <div id='viewBreweries'>
    <div id='brewerylist'>
      <div  v-for='brewery in currentBreweries' :key='brewery.breweryId' @click='showSideMenu(brewery.breweryId)'>
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
#viewBreweries{
   display: flex;
   flex-basis: 100%;
   flex-grow:1;
}
#brewerylist{
  flex-grow: 3;
  flex-direction: column;
  background-color: green;
}
side-details{
 flex-grow:1;
 justify-content: center;
}
</style>
