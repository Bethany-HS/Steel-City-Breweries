<template>
  <div class="review">
    <div  v-for="review in reviews" :key='review.title'>
    <h3>{{ review.title }}</h3>

    <div class="rating">
        <img src="@/images/Full_Beer.png"/>
    </div>


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
         return this.$store.state.beerReviews
        }
        else{
         return this.$store.state.breweryReviews
        }
      }
    },
    methods: {},
    props:['reviewType']
}
</script>

<style>

</style>