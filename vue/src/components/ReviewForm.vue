<template>
    <div>
        <button id="display-form" v-if="showForm === false" v-on:click.prevent="showForm = true">
            Make A Review
        </button>
  <form class="review-form">
      <div>Title</div>
      <div>Star Rating</div>
      <div>Comment</div>
      <button>Submit</button>
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
                starRating: 1,
                comment: "",
            },
            newReview: {}
        };
    },
    methods: {
        addNewReview() {
            this.$store.commit("ADD_REVIEW", this.newReview)
        },
        resetForm() {
            this.showForm = false;
            this.newReview = {};
        }
    }
};
</script>

<style>

</style>