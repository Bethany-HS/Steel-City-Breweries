<template>
  <div class="home">
    <h1>Home</h1>
    <p>You must be authenticated to see this</p>
    <side-nav />
    <content-page />
  </div>
</template>

<script>
import SideNav from '@/components/SideNav.vue';
import ContentPage from '@/components/ContentPage.vue';

export default {
  name: "home",
  components: {
    SideNav,
    ContentPage
  }
};
</script>
