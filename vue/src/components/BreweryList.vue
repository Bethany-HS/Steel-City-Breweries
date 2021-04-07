<template>
  <div id='viewBreweries' >
    <span id='brewerylist' v-for='brewery in currentBreweries' :key='brewery.breweryId'>
      <h1>{{brewery.name}} </h1>
    </span>
    <side-details/>
  </div>
</template>

<script>
import SideDetails from '@/components/SideDetails.vue'
export default {
  data(){
    return{
    }
  },
    components: {
        SideDetails
    },
    computed:{
      currentBreweries(){
        return this.$store.state.breweries;
      },
    methods: {
        loadInfo() {}
    }
}
</script>

<style scoped>
#viewBreweries{
  display: flex;
}
#brewerylist{
  flex-grow:1;
  background-color: green;
}
</style>
