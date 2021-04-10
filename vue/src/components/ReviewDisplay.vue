<template>
  <div class="review">
    <div id='reviewpart' v-for="review in reviews" :key='review.beerReviewId'>
    <h3>{{ review.title }}</h3>

    <div id="rating">
        <img src="@/images/Full_Beer.png"
        v-bind:title="review.rating"
        id="ratingBeer" v-for=" i in review.rating" 
        v-bind:key="i"
        />
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
         return this.$store.state.beerReviews.filter(x => x.beerId === this.reviewId)
        }
        else{
         return this.$store.state.breweryReviews.filter(x => x.breweryId === this.reviewId)
        }
      }
    },
    methods: {},
    props:['reviewType','reviewId']
}
</script>

<style>
.review {
    display: flex;
    flex-direction: column;
}

#reviewpart{
  display: flex;
  flex-direction: column;
}
#rating { 
display: flex;  
height:50px;
width:50px;
vertical-align: top;
}

#ratingBeer {
height: 100%;
margin-right: 10px;
}
</style>