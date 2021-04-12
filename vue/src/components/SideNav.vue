<template>
  <div class="side-nav">
    <div id="nav-inner">
      <button class="nav-button" @click="setPage(0)">Home</button><br>
      <button class="nav-button" @click="setPage(1)">Brewery List</button><br>
      <button class="nav-button" @click="setPage(2)">Beer List</button><br>
      <!-- <button>Favorites</button><br> -->
      <span>
        <button class="nav-button" @click="setPage(3)">Manage Breweries</button><br>
        <!-- <button>Manage Events</button><br> -->
      </span>
      <span>
        <button class="nav-button" @click="setPage(7)">Admin Manage Breweries</button><br>
        <button class="nav-button" @click="setPage(8)">Manage Users</button><br>
      </span>
  </div>
  </div>
</template>

<script>
export default {
  methods:{
    setPage(id){
      this.$store.commit('SET_EDITING_MODE',0);
      this.$store.commit('SET_CURRENT_PAGE',id);
    }
  }

}
</script>

<style>
.side-nav
{
  display: flex;
  background-color: rgb(53, 53, 53);
  padding: 1.3rem;
  border-radius: 10px;
  box-shadow: 5px 5px 3px black;
  flex-direction: column;
  justify-content: space-around;
}

#nav-inner {
  display: flex;
  background-color: white;
  padding: 1rem;
  border-radius: 10px;
  flex-direction: column;
  justify-content: space-around;
}
</style>