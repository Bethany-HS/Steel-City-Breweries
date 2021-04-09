<template>
    <div id='review-form'>
        <button id="display-form" v-if="showForm === false" v-on:click.prevent="showForm = true">
            Make A Beer Review
        </button>
        <form v-if="showForm === true">
            <div class="form-element">
                <label for="title">Title</label>
                <input id="title" type="text" v-model="reviewForm.title"/>
            </div>
            <div class="form-element">
                <label for="rating">Rate Review:</label>
                <select id="rating" v-model.number="reviewForm.rating">
                    <option value="1">1 Beer</option>
                    <option value="2">2 Beers</option>
                    <option value="3">3 Beers</option>
                    <option value="4">4 Beers</option>
                    <option value="5">5 Beers</option>
                </select>
            </div>
            <div class="form-element">
                <textarea id="comment" v-model="reviewForm.comment"></textarea>
            </div>
            <input type="button" value="Submit" @click="addBeerReview"/>
            <input type="button" value="Cancel" @click.prevent="resetForm" />
            <p>
                Make Review Private
                <input type="checkbox" v-bind:checked="reviewForm.private"/>
            </p>
        </form>
    </div>
</template>

<script>
export default {
    name: "add-review",
    data() {
        return {
            showForm: false,
            reviewForm: {
                title: "",
                objectId:this.beer.beerId,
                rating: 1,
                comment: "",
                private: false
            },
        };
    },
    props:['beer'],
    methods: {
        addBeerReview() {
            this.$store.commit("ADD_BEER_REVIEW", this.reviewForm);
            this.resetForm();
        },
        resetForm() {
            this.showForm = false;
            this.reviewForm = {
                title: "",
                objectId:this.beer.beerId,
                rating: 1,
                comment: "",
                private: false
            };
        },
        privateReview() {
            this.$store.commit("MAKE_REVIEW_PRIVATE", this.reviewForm);
        }
    }
};
</script>

<style>
#review-form{
    display:flex;
    justify-content: center;
    margin-bottom: 20px;
}
#display-form{
    width:50%;
}
div.form-element {
  margin-top: 10px;
}
div.form-element > label {
  display: block;
}
div.form-element > input{
  height: 30px;
  width: 300px;
}
div.form-element > select{
  height: 30px;
  width: 307.97px;
}
div.form-element > textarea {
  height: 60px;
  width: 300px;
}
form > input[type="button"] {
  width: 100px;
}
form > input[type="submit"] {
  width: 100px;
  margin-right: 10px;
}
</style>