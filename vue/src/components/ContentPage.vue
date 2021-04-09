<template>
  <div class="content">
    <component :is='display'/>
  </div>
</template>

<script>
import BreweryList from '@/components/BreweryList.vue';
import BeerList from '@/components/BeerList.vue';
import UserProfile from '@/components/UserProfile.vue';
import BreweryManagement from '@/components/BreweryManagement.vue';
import BeerManagement from '@/components/BeerManagement.vue';

export default {
  data(){
    return{
    }
  },
  components: {
    BeerList,
    BreweryList,
    UserProfile,
    BreweryManagement,
    BeerManagement
  },
  computed:{
    display(){
      switch(this.$store.state.currentDisplay){
        case 1:
          return "BreweryList"
        case 2:
          return "BeerList"
        case 3:
          return "BreweryManagement"
        case 4:
          return "BeerManagement"
        default:
          return "UserProfile"
      }
    }
  }
};
</script>

<style scoped>
.content{
  display: flex;
  flex-direction: row;
  justify-content:stretch
}
</style>