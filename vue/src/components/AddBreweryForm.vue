<template>
<div>
    <button id="add-brewery" v-if="showForm === false" @click.prevent="showForm = true">
            Add A Brewery
    </button>
    <form class="breweryform" @submit.prevent v-if="showForm === true">
        <div class="form-element">
            <label for="name">Name</label>
            <input type="text" id="name" placeholder = "Name" v-model="newBrewery.Name">
        </div>
        <div class="form-element">
            <label for="streetaddress1">Street Address 1:</label>
            <input type="text" id="streetaddress1" placeholder="Street Address 1" v-model="newBrewery.StreetAddress1">
        </div>
        <div class="form-element">  
            <label for="streetaddress2">Street Address 2:</label>
            <input type="text" id="streetaddress2" v-model="newBrewery.StreetAddress2">
        </div>
        <div class="form-element">
            <label for="city">City</label>
            <input type="text" id="city" placeholder="City" v-model="newBrewery.City">
        </div>
        <div class="form-element">
            <label for="state">State</label>
            <input type="text" id="state" placeholder="State" v-model="newBrewery.State">
        </div>
        <div class="form-element">
            <label for="zip">Zip Code</label>
            <input type="text" id="zip" placeholder="Zip" v-model.number="newBrewery.Zip">
        </div>
        <div class="form-element">
            <label for="phone">Phone</label>
            <input type="text" id="phone" placeholder="Phone" v-model="newBrewery.Phone">
        </div>
         <div class="form-element">  
            <label for="history">History</label>
            <textarea name="history" id="history" cols="30" rows="10" placeholder="Add Brewery History" v-model="newBrewery.History"></textarea>
        </div>
        <div class="form-element">
            <input type="submit" value="Submit" @click ="addBrewery"/>
            <input type="button" value="Cancel" @click.prevent="resetForm" />
        </div>
       
        
    </form>
</div>
</template>

<script>
import BreweryService from '../services/BreweryService.js'
export default {
    name:"add-brewery",
    data(){
        return{
            showForm: false,
            newBrewery:{
                Name: "",
                BrewerId: this.$store.state.user.userId,
                StreetAddress1: "",
                StreetAddress2: "",
                City: "",
                State: "",
                Zip: "",
                Phone: "",
                History: "",
                BreweryStatus: 1
            }
        };
    },
    methods:{
        resetForm() {
            this.showForm = false;
            this.newBrewery = { 
                Name: "",
                BrewerId: this.$store.state.user.userId,
                StreetAddress1: "",
                StreetAddress2: "",
                City: "",
                State: "",
                Zip: "",
                Phone: "",
                History: "",
                BreweryStatus: 1
            };
        },
        addBrewery(){
            BreweryService
            .addBrewery(this.newBrewery)
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