<template>
  <div id="side-nav">
      <button  @click="setPage(0)">Home</button><br>
      <h2>Find Your Beer</h2>
      <button  @click="setPage(1)">Brewery List</button><br>
      <button  @click="setPage(2)">Beer List</button><br>
      <button  @click="setPage(3)">Reviews</button><br>
      <!-- <button>Favorites</button><br> -->
      <span>
        <button  @click="setPage(4)">Manage Brewery</button><br>
        <button  @click="setPage(5)">Manage Beers</button><br>
        <!-- <button>Manage Events</button><br> -->
      </span>
      <span>
        <button @click="setPage(6)">Manage Breweries</button><br>
        <button @click="setPage(7)">Manage Users</button><br>
      </span>

  </div>
</template>

<script>
export default {
  methods:{
    setPage(id){
      this.$store.state.currentDisplay = id
    }
  }

}
</script>

<style>

</style>