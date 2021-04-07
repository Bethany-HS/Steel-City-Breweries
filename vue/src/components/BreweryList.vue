<template>
  <div id='viewBreweries' >
    <div id='brewerylist'>
      <div  v-for='brewery in currentBreweries' :key='brewery.breweryId' @click='showSideMenu()'>
        <h1>{{brewery.name}} </h1>
      </div>
    </div>
    <side-details v-if='showSideDetails'/>
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
      showSideMenu(){
        this.showSideDetails = true
      }
    }
}
</script>

<style >
#viewBreweries{
  display: flex;
  flex-direction: row;
  align-items: stretch;
}
#brewerylist{
  flex-grow: 1;
  flex-direction: column;
  background-color: green;
}
side-details{
 flex-grow:1;
}
</style>
