<template>
  <div>
    <span id="contents">
        <add-beer-form></add-beer-form>
        <span id="beerlist">
            <h1>Select Beer</h1>
            <span v-for="beer in getBeers()" :key="beer.id">
                <button @click='chooseBeer(beer.id)'>{{beer.name}}</button>
            </span>
        </span>
        <side-details v-if='showSide'/>
    </span>
  </div>
</template>

<script>
import SideDetails from '@/components/SideDetails.vue'
import AddBeerForm from '@/components/AddBeerForm.vue'
import BeerService from '../services/BeerService.js'
export default {
    data(){
        return{
    showSide: false,
    currentBeer : -1,
    }
    },
    components: {
        SideDetails,
        AddBeerForm
    },
    methods:{
        getBeers(){
            return [{id:1,name:'Drink 1'}]
        },
        chooseBeer(id){
            this.showSide = true
            this.currentBeer = id
            this.$store.commit('SET_EDITING_MODE',2);
        },
        addBeer(){
            BeerService
            .addBeer(this.beer)
            .then(response => {
                if (response.status === 201) {
                    this.$router.push("/");
                }
            })
            .catch(error => {
                console.error(error);
            });
        },
    cancel() {
      this.$router.push("/");
        }
    }
}
</script>

<style>
#beerManagement{
    display: flex;
    flex-grow:1;
    flex-direction: row;
}
#MainContent{
    display: flex;
    flex-grow:2;
    flex-direction: column;
}

#managebeerlist{
    display: flex;
    flex-grow: 1;
    flex-basis:100%;
}
#managebeerlist >h1{
    display: flex;
    flex-grow: 1;
    flex-basis:100%;
}

</style>
