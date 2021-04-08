<template>
  <div id='breweryManagement'>
    <div id="MainContent">
        <h1>Select Brewery</h1>
        <div id='managebrewerylist' v-for="brewery in getBreweries()" :key="brewery.breweryId">
            <h1 @click='chooseBrewery(brewery.breweryId)'>{{brewery.name}}</h1>
        </div>
    </div>
    <side-details :current-brewery='currentBrewery' v-if='showSide'/>
  </div>
</template>

<script>
import SideDetails from '@/components/SideDetails.vue'
export default {
    data(){
        return{
    showSide: false,
    currentBrewery : -1,
    breweries: [],
    user:{},
    }
    },
    components: {
        SideDetails
    },
    methods:{
        getBreweries(){
            this.breweries=this.$store.state.breweries
            this.user = this.$store.state.user
            return this.$store.state.breweries.filter(brew => brew.brewerId===this.$store.state.user.userId && brew.isActive)
        },
        chooseBrewery(id){
            this.currentBrewery = id
            this.showSide = true
            this.$store.commit('SET_EDITING_MODE',1);
        }
    }
}
</script>

<style >
#breweryManagement{
    display: flex;
    flex-grow:1;
    flex-direction: row;
    background-color: green;
}
#MainContent{
    display: flex;
    flex-grow:2;
    flex-direction: column;
}

#managebrewerylist{
    display: flex;
    flex-grow: 1;
    flex-basis:100%;
}
#managebrewerylist >h1{
    display: flex;
    flex-grow: 1;
    flex-basis:100%;
}


</style>
