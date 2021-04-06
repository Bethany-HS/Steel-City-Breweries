<template>
  <div class="home">
    <h1>Home</h1>
    <p>You must be authenticated to see this</p><br>
    <span id='main-page'>
    <side-nav />
    <content-page />
    </span>
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

<style>
#main-page{
  display: flex;

}
side-nav{
  flex-grow:1;
}
content-page{
  flex-grow: 5;
}
</style>
