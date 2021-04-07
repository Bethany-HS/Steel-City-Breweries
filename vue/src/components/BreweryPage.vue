<template>
  <div>
    <h1>Brewery 1</h1>
        <h2>Map/location</h2><br>
        <h2>Address</h2><br>
        <h2>Owner: Beatrice Smith</h2><br>
            <h3>Brewery Description</h3><br>
        <h2>Brewery Menu</h2>
        <h2>View Beer List</h2>
        <h2>Ratings and Reviews</h2>
        <review-display/>
  </div>
</template>

<script>
import ReviewDisplay from '@/components/ReviewDisplay.vue'
export default {
  components: { 
      ReviewDisplay 
      },

}
</script>

<style>

</style>