<template>
    <div id='viewBeers' >
    <span id='beerlist'>
      <span v-for='beer in currentBeers' :key='beer.beerId' :id=beer.beerId>
        <h1>{{beer.name}} {{beer.abv}}</h1>
      </span>
    </span>
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
