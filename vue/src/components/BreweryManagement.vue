<template>
  <div id='breweryManagement'>
    <span id='managebrewerylist'>
        <h1>Select Brewery</h1>
        <span v-for="brewery in getBreweries()" :key="brewery.id">
            <button @click='chooseBrewery(brewery.id)'>{{brewery.name}}</button>
        </span>
    </span>
    <side-details v-if='showSide'/>
  </div>
</template>

<script>
import SideDetails from '@/components/SideDetails.vue'
export default {
    data(){
        return{
    showSide: false,
    currentBrewery : -1,
    }
    },
    components: {
        SideDetails
    },
    methods:{
        getBreweries(){
            return [{id:1,name:'Drinks on me'}]
        },
        chooseBrewery(id){
            this.showSide = true
            this.currentBrewery = id
            this.$store.commit('SET_EDITING_MODE',1);
        }
    }
}
</script>

<style>
#breweryManagement{
    display:flex;
    flex-grow:1;
}

#managebrewerylist{
    flex-grow:3;
    
}

</style>
