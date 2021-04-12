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
        </div>
        <h3>{{ review.review }}</h3>
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
        <h3>{{ review.review }}</h3>
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
         return this.$store.state.beerReviews.filter(x => (x.beerId === this.reviewId && x.isPrivate===0))
        }
        else{
         return this.$store.state.breweryReviews.filter(x => (x.breweryId === this.reviewId&& x.isPrivate===0))
        }
      }
    },
    methods: {},
    props:['reviewType','reviewId']
}
</script>

<style>


#reviewpart{
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