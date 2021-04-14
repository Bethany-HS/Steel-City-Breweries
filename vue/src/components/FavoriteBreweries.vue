<template>
<div>
  <div id="fav-breweries" v-for='favorite in favoriteBrewery' :key='favorite.userId'>
      <h2>{{brewery.name}}</h2>
      <h2>{{brewery.city}} {{brewery.phone}}</h2>
    <average-brewery-rating class="avgRating" :number-of-brewery="brewery.breweryId"/>
  </div>
</div>
</template>

<script>
import AverageBreweryRating from '@/components/AverageBreweryRating.vue'
export default {
    name: "favorite-breweries",
    components: {
        AverageBreweryRating
    },
    computed: {
        favoriteBrewery() {
            return this.$store.state.userFavorites;
        }
    }
}
</script>

<style>

</style>