<template>
  <div on-click:loadInfo()>
     <h1>Name of Brewery</h1><br> 
        <img/>
     <h2>Contact Info</h2><br>
     <h2>Hours/Days of Operation</h2><br>
     <h2>Address</h2><br>
     <side-details/>
  </div>
</template>

<script>
import SideDetails from '@/SideDetails.vue'
export default {
    components: {
        SideDetails
    }
}
</script>
