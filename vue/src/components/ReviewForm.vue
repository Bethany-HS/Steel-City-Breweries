<template>
    <div id='review-form'>
        <button id="display-form" v-if="showForm === false" v-on:click.prevent="showForm = true">
            Make A Review
        </button>
        <form @submit.prevent="addNewReview" v-if="showForm === true">
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
            <input type="submit" value="Submit" />
            <input type="button" value="Cancel" @click.prevent="resetForm" />
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
                rating: 1,
                comment: "",
            },
            newReview: {}
        };
    },
    methods: {
        addNewReview() {
            this.$store.commit("ADD_REVIEW", this.reviewForm)
        },
        resetForm() {
            this.showForm = false;
            this.newReview = {};
        }
    }
};
</script>

<style>
#review-form{
    flex-grow: 1;
}
#display-form{
    width:100%;
    height:100%;
}
div.form-element {
  margin-top: 10px;
}
div.form-element > label {
  display: block;
}
div.form-element > input,
div.form-element > select {
  height: 30px;
  width: 300px;
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