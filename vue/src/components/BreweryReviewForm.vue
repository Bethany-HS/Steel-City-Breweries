<template>
    <div id='review-form'>
        <button id="display-form-btn" v-if="showForm === false" v-on:click.prevent="showForm = true">Make a Brewery Review</button>
        <form v-if="showForm === true">
            <div class="form-element">
                <label for="title">Title</label>
                <input id="title" type="text" v-model="reviewForm.Title"/>
            </div>
            <div class="form-element">
                <label for="rating">Rate Review:</label>
                <select id="rating" v-model.number="reviewForm.BreweryRating">
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
            <input type="button" value="Submit" @click="addBreweryReview()"/>
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
            showForm: false,
            isPrivate:false,
            reviewForm: {
                UserId: this.$store.state.user.userId,
                BreweryId: this.brewery.breweryId,
                BreweryRating: 0,
                Title: "",
                Review: "",
                isPrivate: 0
            }
        };
    },
    props:['brewery'],
    computed:{
        checkPrivate(){
            return this.isPrivate ? 1:0
        }
    },
    methods: {
        addBreweryReview() {
            this.reviewForm.isPrivate = this.isPrivate ? 1:0
            ReviewService
            .addBreweryReview(this.reviewForm)
            .then(response => {
                if (response.status === 201) {
                    this.showForm = false;
                    this.resetForm();
                    ReviewService.getBreweryReviews().then(response => {
                    this.$store.state.breweryReviews =  response.data;})
                }
            })
            .catch(error => {
                console.log(error);
            });
        },
         resetForm() {
            this.showForm = false;
            this.reviewForm = {
                UserId:this.$store.state.user.userId,
                BreweryId: this.brewery.breweryId,
                BreweryRating: 0,
                Title: "",
                Review: "",
                isPrivate: 1    
            };
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