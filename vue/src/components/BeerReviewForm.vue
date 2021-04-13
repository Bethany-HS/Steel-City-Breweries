<template>
    <div id='review-form' >
<<<<<<< HEAD
        <button id="display-form" v-if="showForm === false" @click.prevent="showForm = true">Make A Beer Review</button>
=======
        <button id="display-form" v-if="!showForm" @click.prevent="spawnForm">Make A Beer Review</button>
>>>>>>> 56970acc02166da059b59911cc79187439c646d0
        <form v-if="showForm === true">
            <div class="form-element">
                <label for="title">Title</label>
                <input id="title" type="text" v-model="reviewForm.Title"/>
            </div>
            <div class="form-element">
                <label for="rating">Rate Review:</label>
                <select id="rating" v-model.number="reviewForm.BeerRating">
                    <option value="1">1 Beer</option>
                    <option value="2">2 Beers</option>
                    <option value="3">3 Beers</option>
                    <option value="4">4 Beers</option>
                    <option value="5">5 Beers</option>
                </select>
            </div>
            <div class="form-element">
                <textarea id="comment" v-model="reviewForm.Review"></textarea>
            </div>
            <input type="button" value="Submit" @click="addBeerReview"/>
            <input type="button" value="Cancel" @click.prevent="resetForm" />
            <p>
                Make Review Private
                <input type="checkbox" v-model="isPrivate"/>
            </p>
        </form>
    </div>
</template>

<script>
import ReviewService from '@/services/ReviewService.js'
export default {
    name: "add-review",
    data() {
        return {
            isPrivate:false,
            reviewForm: {
                UserId: this.$store.state.user.userId,
                BeerId: this.beer[0].beerId,
                BeerRating: 1,
                Title: "",
                Review: "",
                isPrivate: 0
            },
        };
    },
    props:['beer'],
    computed:{
        checkPrivate(){
            return this.isPrivate ? 1:0
        },
        showForm(){
            return this.$store.state.showReviewForm
        }
    },
    methods: {
        addBeerReview() {
            this.reviewForm.isPrivate = this.isPrivate ? 1:0
            ReviewService
            .addBeerReview(this.reviewForm)
            .then(response => {
                if (response.status === 201) {
                    this.$store.state.showReviewForm = false;
                    this.resetForm();
                    ReviewService.getBeerReviews().then(response => {
                    this.$store.state.beerReviews =  response.data;})
                }
            })
            .catch(error => {
                console.log(error);
            });
            
        },
        resetForm() {
            this.$store.state.showReviewForm = false
            this.reviewForm = {
                UserId: this.$store.state.user.userId,
                BeerId: this.beer[0].beerId,
                BeerRating: 0,
                Title: "",
                Review: "",
                isPrivate: 1
            };
<<<<<<< HEAD
=======
        },
        spawnForm(){
            this.resetForm(); 
            this.$store.state.showReviewForm = true;
>>>>>>> 56970acc02166da059b59911cc79187439c646d0
        }
    }
};
</script>

<style>
#rating {
  width: 80%;
}

div.form-element {
  margin-top: 10px;
  width: 80%;
}
div.form-element > label {
  display: block;
}
div.form-element > input{
  height: 30px;
}
div.form-element > select{
  height: 30px;
}
#comment {
height: 60px;
}
form > input[type="button"] {
  width: 100px;
}
form > input[type="submit"] {
  width: 100px;
}
</style>