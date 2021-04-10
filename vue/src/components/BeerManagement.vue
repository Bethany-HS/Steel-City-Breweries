<template>
  <div>
    <div id="contents">
        <div>
        <add-beer-form></add-beer-form>
        <div id="beerlist">
            <h1>{{brewery.name}}</h1>
            <h1>Select Beer</h1>
            <div v-for="beer in getBeers" :key="beer.beerId">
                <h1 @click='chooseBeer(beer.beerId)'>{{beer.name}}</h1>
            </div>
        </div>
        </div>
        <side-details  :currentBeer='this.$store.state.beers.filter(x=>x.beerId === currentBeer)[0]' v-if='showSide'/>
    </div>
  </div>
</template>

<script>
import SideDetails from '@/components/SideDetails.vue'
import AddBeerForm from '@/components/AddBeerForm.vue'

export default {
    data(){
        return{
    showSide: false,
    currentBeer : -1,
    brewery: this.$store.state.breweries.filter(x=> x.breweryId === this.$store.state.currentBrewery)[0]
    }
    },
    components: {
        SideDetails,
        AddBeerForm
    },
    methods:{
        chooseBeer(id){
            this.showSide = true
            this.currentBeer = id
            this.$store.commit('SET_EDITING_MODE',2);
        },
    },
    computed:{
        getBeers(){
        return this.$store.state.beers.filter(beer =>beer.breweryId === this.brewery.breweryId)
        }
    }
}
</script>

<style>

#contents{
    display: flex;
    flex-grow:1;
    flex-direction: row;
}

#beerlist{
    display: flex;
    flex-direction: column;
    flex-basis:60%;
}


</style>
