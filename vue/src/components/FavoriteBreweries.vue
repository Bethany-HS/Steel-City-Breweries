<template>
<div>
  <div id="fav-breweries" v-for='favorite in favoriteBrewery' :key='favorite.breweryId'>
      <h2>{{favorite.name}}</h2>
      <h2>{{favorite.city}} {{favorite.phone}}</h2>
    <average-brewery-rating class="avgRating" :number-of-brewery="favorite.breweryId"/>
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

            return this.$store.state.breweries.filter(brewery => {
                return this.$store.state.userFavorites.includes(brewery.breweryId);
            }) 

        }
    }
}
</script>

<style>

</style>