<template>
<div>
    <button id="edit-brewery" v-if="showForm === false" @click.prevent="showForm = true">
            Edit A Brewery
    </button>
    <form class="breweryform" @submit.prevent v-if="showForm === true">
        <div class="form-element">
            <label for="name">Name</label>
            <input type="text" id="name" placeholder = "Name" v-model="newBrewery.name">
        </div>
        <div class="form-element">
            <label for="streetaddress1">Street Address 1:</label>
            <input type="text" id="streetaddress1" placeholder="Street Address 1" v-model="newBrewery.streetAddress1">
        </div>
        <div class="form-element">  
            <label for="streetaddress2">Street Address 2:</label>
            <input type="text" id="streetaddress2" v-model="newBrewery.streetAddress2">
        </div>
        <div class="form-element">
            <label for="city">City</label>
            <input type="text" id="city" placeholder="City" v-model="newBrewery.city">
        </div>
        <div class="form-element">
            <label for="state">State</label>
            <input type="text" id="state" placeholder="State" v-model="newBrewery.state">
        </div>
        <div class="form-element">
            <label for="zip">Zip Code</label>
            <input type="text" id="zip" placeholder="Zip" v-model.number="newBrewery.zip">
        </div>
        <div class="form-element">
            <label for="phone">Phone</label>
            <input type="text" id="phone" placeholder="Phone" v-model="newBrewery.phone">
        </div>
         <div class="form-element">  
            <label for="history">History</label>
            <textarea name="history" id="history" cols="30" rows="10" placeholder="Add Brewery History" v-model="newBrewery.history"></textarea>
        </div>
        <div class="form-element">  
            <label for="hours">Hours of Operation</label>
            <textarea name="hours" id="hours" cols="30" rows="10" placeholder="Add Hours of Operation" v-model="newBrewery.hoursOfOperation"></textarea>
        </div>
        <div class="form-element">
            <label for="website">Website</label>
            <input type="text" id="website" placeholder="URL" v-model="newBrewery.website">
        </div>
        <div class="form-element">
            <input type="submit" value="Submit" @click ="editBrewery"/>
            <input type="button" value="Cancel" @click.prevent="resetForm" />
        </div>
       
        
    </form>
</div>
</template>

<script>
import BreweryService from '../services/BreweryService.js'
export default {
    name:"edit-brewery",
    data(){
        return{
            showForm: false,
            
        };
    },
    computed:{
        newBrewery(){return this.brewery}
    },
    props: ['brewery'],
    methods:{
        editBrewery(){
            BreweryService
            .editBrewery(this.newBrewery)
            .then(response => {
                if (response.status === 201) {
                    this.showForm = false;
                    BreweryService.getBreweries().then(response => {
                    this.$store.state.breweries =  response.data;})
                }
            })
            .catch(error => {
                console.log(error);
            });
        }
    }
}
</script>

<style>

</style>