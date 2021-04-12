<template>
  <div class="review">
    <div v-if='reviewType' id='beerReviewDisplay'>
      <div  id='reviewpart'  v-for="review in reviews" :key='review.beerReviewId'>
        <h3>{{review.title}} </h3>
        <div id="rating">
          <img src="@/images/Full_Beer.png"
          v-bind:title="review.beerRating"
          id="ratingBeer" v-for=" i in review.beerRating" 
          v-bind:key="i"
          />
          <h3 class="review-review">{{ review.review }}</h3>
        </div>
      </div>
    </div>
    <div v-else id='breweryReviewDisplay'>
      <div id='reviewpart'  v-for="review in reviews" :key='review.breweryReviewId'>
        <h3>{{ review.title }}</h3>
        <div id="rating">
          <img src="@/images/Full_Beer.png"
          v-bind:title="review.breweryRating"
          id="ratingBeer" v-for=" i in review.breweryRating" 
          v-bind:key="i"
          />
        </div>
        <h3 class="review-review">{{ review.review }}</h3>
      </div>
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
    justify-content: space-around;
    overflow: scroll;
}

#reviewpart{
  display: flex;
  flex-direction: column;
  
}

#rating { 
display: flex;  
height:50px;
width:50px;
}

#ratingBeer {
height: 100%;
margin-right: 10px;
}


</style>

