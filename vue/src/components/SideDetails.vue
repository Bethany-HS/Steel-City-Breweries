<template>
  <div id='side-details' >
    <div id="white-block">
    <span id='brewerydetails' v-if='$store.state.editingMode===0 && Object.keys(currentBeer).length === 0'>
    <h1 id="name">{{currentBrewery.name}}</h1>
    <h2 id="details"></h2>
    <h2 id="ratings"></h2>
    <h2 id="reviews"></h2>
    <button @click="goToBrewery()">View Brewery Details</button>
      <span id="make-a-brewery-review-btn">
        <brewery-review-form :brewery='currentBrewery'/>
         <review-display :review-id='currentBrewery.breweryId' :review-type='Object.keys(currentBeer).length !== 0'/>
      </span>
    </span>
    <span id='beerdetails' v-else-if='$store.state.editingMode===0 '>
    <h1 id="name">{{currentBeer[0].name}}</h1>
    <h2 id="details"></h2>
    <h2 id="ratings"></h2>
    <h2 id="reviews"></h2>
    <button @click="goToBeer()">View Beer Details</button>
    <beer-review-form :beer='currentBeer'/>
    <review-display :review-id='currentBeer[0].beerId' :review-type='Object.keys(currentBeer).length !== 0'/>
    </span>
    
    <span  id='brewerydetails' v-if='$store.state.editingMode===1'>
      <h1 v-if='$store.state.showEditForm === false' >{{brewery.name}}</h1>
      <edit-brewery-form :brewery='brewery'/>
      <button @click="navigateToManageBeers()">Manage Beers</button>
      <form id="form1" runat="server">
        <input @change="readURL($event)" type='file' id="imgInp" />
      </form>
      <button @click='savePicture'> Save</button>
    </span>
    <span id='beerdetails' v-if='$store.state.editingMode===2'>
      <h1>{{currentBeer.name}}</h1>
      <edit-beer-form :beer='currentBeer'/>
      <button @click='deleteBeer'>Delete Beer </button>
    </span>
    </div>
  </div>
</template>

<script>
import ReviewDisplay from '@/components/ReviewDisplay.vue'
import BeerReviewForm from '@/components/BeerReviewForm.vue'
import BreweryReviewForm from '@/components/BreweryReviewForm.vue'
import EditBreweryForm from '@/components/EditBreweryForm.vue'
import EditBeerForm from '@/components/EditBeerForm.vue'
import BeerService from '../services/BeerService.js'
import ImageService from '../services/ImageService.js'

export default {
    data(){
      return{
        input:''
      }
    },
    components: {
        BeerReviewForm,
        ReviewDisplay,
        BreweryReviewForm,
        EditBreweryForm,
        EditBeerForm
    },
    methods: {
      goToBrewery(){
        this.$store.state.currentBrewery = this.currentBrewery;
        ImageService.getImage(this.currentBrewery.breweryId).then( response=> {
          localStorage.setItem("breweryPicture",response.data.breweryImgPath)
        })
        this.$store.commit('SET_CURRENT_PAGE', 5)
        
      },
      navigateToManageBeers(){
        this.$store.state.currentBrewery = this.currentBrewery;
        this.$store.commit('SET_CURRENT_PAGE',4)
      },
      goToBeer(){
        this.$store.state.currentBeer = this.currentBeer[0];
        this.$store.commit('SET_CURRENT_PAGE', 6)
      },
      deleteBeer(){
        BeerService.deleteBeer(this.currentBeer)
        
      },
      savePicture(){
        let pic = {"BreweryId":this.currentBrewery,"BreweryImgPath":localStorage.getItem("breweryPicture")}
        ImageService.updateImage(pic)
      },
      readURL(inputEvent) {
        this.input = inputEvent.currentTarget
        if (this.input.files && this.input.files[0]) {
            var reader = new FileReader();
            
            reader.onload = function (e) {
                localStorage.setItem("breweryPicture",e.target.result)
            }
            reader.readAsDataURL(this.input.files[0]);
        }
    }
    },
    props:['currentBrewery','currentBeer'],
    computed:{
      brewery(){
        return this.$store.state.breweries.filter(x=>this.$store.state.currentBrewery ===x.breweryId)[0]
      },
      beer(){
        return this.$store.state.beers.filter(x=>this.$store.state.currentBeer ===x.beerId)[0]
      }
    }
}

</script>

<style>
#side-details {
  display: flex;
  flex-direction: column;
  flex-basis: 30%;
  background-color: rgb(53,53,53);
  border-radius: 10px;
  box-shadow: 5px 5px 3px black;
  padding: 1rem;
  justify-content: flex-start;
}

#white-block {
  display: flex;
  background-color: white;
  border-radius: 10px;
  padding: 1rem;
  justify-content: center;

  height:97%
}
review-display{
  display: flex;
  width : 20%
}
#white-block>span{
  display: flex;
  flex-direction: column;
  flex-basis:90%;
  text-align: left;
  align-items:center;
  overflow: auto;
}

</style>