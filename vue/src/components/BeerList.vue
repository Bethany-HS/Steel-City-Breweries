<template>
  <div >
     <h1>Name of Beer</h1><br> 
        <img src=""/>
     <h2>Brewery</h2><br>
     <h2>Type of Beer</h2><br>
     <h2>Rating/Reviews</h2><br>
     <side-details/>
  </div>
</template>

<script>
import SideDetails from '@/components/SideDetails.vue'
export default {
    components: {
        SideDetails
    },
    methods: {
        loadInfo() {}
    }
}
</script>

<style>

</style>
