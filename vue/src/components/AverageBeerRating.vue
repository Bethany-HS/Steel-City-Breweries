<template>
  <div id="average-beer-rating">
    <div id="rating">
        <img src="@/images/Full_Beer.png"
        v-bind:title="review.rating"
        id="ratingBeer" v-for=" i in review.rating" 
        v-bind:key="i"
        />
    </div>
    <div id="rating-amount">{{ averageRating }}</div>
    Average Rating
  </div>
</template>

<script>
export default {
    name: "average-rating",
    computed: {
        averageRating() {
            let sum = this.$store.state.beerReviews.reduce((currentSum, currentReview) => {
                return currentSum + currentReview.rating;
            }, 0);

            return (sum / this.$store.state.beerReviews.length).toFixed(1);
        },
        numberOfBeer
    }
};
</script>

<style>

</style>