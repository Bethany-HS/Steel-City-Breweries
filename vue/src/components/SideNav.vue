<template>
  <div class="side-nav">
    <div id="nav-inner">
      <button class="nav-button" @click="setPage(0)">Home</button><br>
      <button class="nav-button" @click="setPage(1)">Brewery List</button><br>
      <button class="nav-button" @click="setPage(2)">Beer List</button><br>
      <!-- <button>Favorites</button><br> -->
        <button class="nav-button" @click="setPage(3)" v-if="$store.state.user.role !== 'user'">Manage Breweries</button><br>
        <!-- <button>Manage Events</button><br> -->
        <button class="nav-button" @click="setPage(7)" v-if="$store.state.user.role  === 'admin'">Admin Manage Breweries</button><br>
        <button class="nav-button" @click="setPage(8)" v-if="$store.state.user.role === 'admin'">Manage Users</button><br>
  </div>
  </div>
</template>

<script>
export default {
  data(){
    return{
      user : this.$store.state.user,
    }
  },
  
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
  justify-content: space-around;
  flex-basis: 30%;
  align-items: flex-start;
  margin-right: 20px;
}

#nav-inner {
  display: flex;
  background-color: white;
  padding: 1rem;
  border-radius: 10px;
  flex-direction: column;
  justify-content: space-around;
  align-items: flex-start;
}
</style>