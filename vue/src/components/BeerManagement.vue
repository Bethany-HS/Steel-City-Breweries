<template>
  <div>
    <span id="contents">
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
export default {
    data(){
        return{
    showSide: false,
    currentBeer : -1,
    }
    },
    components: {
        SideDetails
    },
    methods:{
        getBeers(){
            return [{id:1,name:'Drink 1'}]
        },
        chooseBeer(id){
            this.showSide = true
            this.currentBeer = id
            this.$store.commit('SET_EDITING_MODE',2);
        }
    }
}
</script>

<style>
#contents{
    display:flex;
    width :100%;
}
#beerlist{
    flex-grow:3;
    background-color: green;
   
}
side-details{
    flex-grow:1
}
</style>
