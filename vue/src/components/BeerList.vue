<template>
  <div >
     <h1>Name of Beer</h1><br> 
        <img src=""/>
     <h2>Brewery</h2><br>
     <h2>Type of Beer</h2><br>
     <h2>Rating/Reviews</h2><br>
     <review-form/>
     <review-display/>
     <side-details/>
  </div>
</template>

<script>
import SideDetails from '@/components/SideDetails.vue'
import ReviewDisplay from '@/components/ReviewDisplay.vue'
import ReviewForm from '@/components/ReviewForm.vue'
export default {
    components: {
        SideDetails,
        ReviewDisplay,
        ReviewForm
    },
    methods: {
        loadInfo() {}
    }
}
</script>

<style>

</style>
