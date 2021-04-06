<template>
  <div class="content">
    <component :is='display'/>
  </div>
</template>

<script>
import BreweryList from '@/components/BreweryList.vue';
import BeerList from '@/components/BeerList.vue';
export default {
  data(){
    return{
    }
  },
  components: {
    BeerList,
    BreweryList
  },
  computed:{
    display(){
      switch(this.$store.state.currentDisplay){
        case 1:
          return "BreweryList"
        case 2:
          return "BeerList"
        default:
          return "Temp"
      }
    }
  }
};
</script>