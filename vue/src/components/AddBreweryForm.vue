<template>
<div>
    <button id="add-brewery" v-if="showForm === false" @click.prevent="showForm = true">
            Add A Brewery
    </button>
    <form class="breweryform" @submit.prevent="addNewBrewery" v-if="showForm === true">
        <div class="form-element">
            <label for="name">Name</label>
            <input type="text" id="name" placeholder = "Name" v-model="newBrewery.name">
        </div>
        <div class="form-element">
            <label for="brewer">Brewer</label>
            <input type="text" id="brewer" placeholder="Brewer Name" v-model.number="newBrewery.brewer">
        </div>
        <div class="form-element">
            <label for="streetaddress1">Street Address 1:</label>
            <input type="text" id="streetaddress1" placeholder="Street Address 1" v-model="newBrewery.address1">
        </div>
        <div class="form-element">  
            <label for="streetaddress2">Street Address 2:</label>
            <input type="text" id="streetaddress2" v-model="newBrewery.address2">
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
            <input type="submit" value="Submit" />
            <input type="button" value="Cancel" @click.prevent="resetForm" />
        </div>
       
        
    </form>
</div>
</template>

<script>
export default {
    name:"add-brewery",
    data(){
        return{
            showForm: false,
            newBrewery:{
                name: "",
                brewer: "",
                address1: "",
                address2: "",
                city: "",
                state: "",
                zip: "",
                phone: "",
                history: "",
                isActive: true
            }
        };
    },
    methods:{
        addNewBrewery(){
            this.$store.commit("ADD_BREWERY", this.newBrewery);
        },
        resetForm() {
            this.showForm = false;
            this.newBrewery = {};
        }
    }
}
</script>

<style>

</style>