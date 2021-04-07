<template>
  <div id='sidedetails' >
    <span  v-if='$store.state.editingMode===0'>
    <h1 id="name"></h1>
    <h2 id="details"></h2>
    <h2 id="ratings"></h2>
        <button id="add-review">Add Reveiw</button>
    <h2 id="reviews"></h2>
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
export default {
    components: {},
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
flex-grow: 1;
}
</style>