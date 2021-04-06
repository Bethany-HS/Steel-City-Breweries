<template>
  <div class="home">
    <h1>Home</h1>
    <p>You must be authenticated to see this</p>
    <side-nav />
    
  </div>
</template>

<script>
import SideNav from '@/components/SideNav.vue';
export default {
  name: "home",
  components: {
    SideNav
  }
};
</script>
