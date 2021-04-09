<template>
  <div class="review">
    <div  v-for="review in reviews" :key='review.title'>
    <h3>{{ review.title }}</h3>
    <h3>{{ review.comment }}</h3>
    </div>
  </div>
</template>

<script>
export default {
    name: "review-display",
    data(){
      return{
      }
    },
    computed:{
      reviews(){
        if(this.reviewType === true){
         return this.$store.state.beerReviews.filter(x => x.objectId === this.reviewId)
        }
        else{
         return this.$store.state.breweryReviews.filter(x => x.objectId === this.reviewId)
        }
      }
    },
    methods: {},
    props:['reviewType','reviewId']
}
</script>

<style>

</style>