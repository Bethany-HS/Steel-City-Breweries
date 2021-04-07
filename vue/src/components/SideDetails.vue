<template>
  <div >
    <span v-if='$store.state.editingMode===0'>
    <h1 id="name"></h1>
    <h2 id="details"></h2>
    <h2 id="ratings"></h2>
    <h2 id="reviews"></h2>
    <review-display/>
    </span>
    <span v-if='$store.state.editingMode===1'>
      <button>Edit Brewery Info</button>
      <button @click="$store.commit('SET_CURRENT_PAGE',4)">Manage Beers</button>
    </span>
    <span v-if='$store.state.editingMode===2'>
      <button>Edit Beer Info</button>
    </span>

  </div>

</template>

<script>
import ReviewForm from '@/components/ReviewForm.vue'
import ReviewDisplay from '@/components/ReviewDisplay.vue'
export default {
    components: {
        ReviewForm,
        ReviewDisplay
    },
    data() {
      return{
        reviews: [],
        ratings: []
      }
    },
    methods: {}
}
</script>

<style>

</style>