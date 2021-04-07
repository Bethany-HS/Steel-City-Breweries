<template>
  <div id='sidedetails' >
    <span id='generaldetails' v-if='$store.state.editingMode===0'>
    <h1 id="name"></h1>
    <h2 id="details"></h2>
    <h2 id="ratings"></h2>
    <review-form />
    <h2 id="reviews"></h2>
    </span>
    <span  id='brewerydetails' v-if='$store.state.editingMode===1'>
      <button>Edit Brewery Info</button>
      <button @click="$store.commit('SET_CURRENT_PAGE',4)">Manage Beers</button>
    </span>
    <span id='beerdetails' v-if='$store.state.editingMode===2'>
      <button>Edit Beer Info</button>
    </span>

  </div>

</template>

<script>
import ReviewForm from '@/components/ReviewForm.vue'
export default {
    components: {
        ReviewForm
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
#sidedetails{

background-color: royalblue;
flex-direction:row;

}

</style>