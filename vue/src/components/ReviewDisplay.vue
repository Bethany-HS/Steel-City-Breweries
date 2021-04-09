<template>
  <div class="review">
    <div id='reviewpart' v-for="review in reviews" :key='review.title'>
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
.review {
    display: flex;
    
}

#reviewpart{
  display: flex;
  
}
#rating { 
display: flex;  
height: 3rem;
vertical-align: top;
margin: 0 0.5rem;
}

#ratingBeer {
display: flex;
height: 100%;
justify-content: flex-start;
flex-direction: row;
flex-grow: 5;
}
</style>