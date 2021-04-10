<template>
  <div id='breweryManagement'>
    <div id="MainContent">
        <add-brewery-form></add-brewery-form>
        <h1>Select Brewery</h1>
        <div id='managebrewerylist' v-for="brewery in breweries" :key="brewery.breweryId">
            <h1 @click='chooseBrewery(brewery.breweryId)'>{{brewery.name}}</h1>
        </div>
    </div>
    <side-details :current-brewery='currentBrewery' v-if='showSide'/>
  </div>
</template>

<script>
import SideDetails from '@/components/SideDetails.vue'
import AddBreweryForm from '@/components/AddBreweryForm.vue'
export default {
    data(){
        return{
    showSide: false,
    currentBrewery : -1,
    user:{}
    }
    },
    components: {
        SideDetails,
        AddBreweryForm
    },
    methods:{
        chooseBrewery(id){
            this.currentBrewery = id
            this.showSide = true
            this.$store.state.currentBrewery=id
            this.$store.commit('SET_EDITING_MODE',1);
        }
    },
    computed:{
        breweries(){
            return this.$store.state.breweries.filter(brew => (brew.brewerId===this.$store.state.user.userId))
        }
    },
    created(){
        
        this.user = this.$store.state.user
        }
    
}
</script>

<style >
#breweryManagement{
    display: flex;
    flex-direction: column;
    border-radius: 15px;
}
#MainContent{
    display: flex;
    flex-direction: column;
    flex-basis: 60%;
    background-color: rgb(53,53,53);
    border-radius: 15px;
    padding: 1rem;
}

#managebrewerylist{
    display: flex;
    flex-basis: 60%;
    margin-right: 30px;
}
#managebrewerylist >h1{
    display: flex;
    flex-basis:60%;
}

</style>
