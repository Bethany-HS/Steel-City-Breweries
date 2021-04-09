<template>
  <div class="review">
    <h3>{{ review.title }}</h3>
    <div class="rating">
        <img src="@/images/Full_Beer.png"/>
    </div>
    <h3>{{ review.comment }}</h3>

  </div>
</template>

<script>
export default {
    name: "review-display",
    props: ["review"],
    methods: {}
}
</script>

<style>

</style>