<template>
<div class="wrap">
    <div class="container">
       <div class="row" v-if="type === 'Location Manager'">
 <div class="col-12">
  <Locations></Locations>
        </div>
     <div>
      </div>
      </div>
      <h3 v-else>You are not authorized to visit this site.</h3>
      <div class="row">
      <div class="col">
        <Footer></Footer>
        </div>
        </div>
  </div>
  </div>
</template>

<script>
import Cookies from 'js-cookie';
import Navbar from "~/components/Navbar";
import LoginForm from "~/components/LoginForm";
import Footer from "~/components/Footer";
import Locations from "~/components/Locations";
import axios from "axios";
export default {
   data: function() {
    return {
      token: Cookies.get('token'),
      type: ""

    }
    },
       // What to do before the page is created.
  mounted() {
var myHeaders = new Headers();
myHeaders.append("Authorization", "Bearer " + this.token);
var urlencoded = new URLSearchParams();

var requestOptions = {
  method: 'GET',
  headers: myHeaders,
  redirect: 'follow'
};

fetch("http://localhost:55246/api/getUserType", requestOptions)
  .then(response => response.text())
  .then(result => this.type = result)
  .catch(error => console.log('error', error));
  },
  components: {
    Navbar,
    LoginForm,
    Footer,
    Locations
  },
  methods: {
    async getLocationsData() {
      var myHeaders = new Headers();
      myHeaders.append("Authorization", "Bearer " + this.token);
      var urlencoded = new URLSearchParams();

      var requestOptions = {
      method: 'GET',
      headers: myHeaders,
      redirect: 'follow'
};
fetch("http://localhost:55246/api/getLocationsFromManagerId", requestOptions)
  .then(response => response.text())
  .then(result => this.type = result)
  .catch(error => console.log('error', error));
  }
  }
};
</script>

<style>
.logo {
  font-size: 45px;
  font-weight: 400;
  color: white;
}


.wrap{
  background-color:#3c68b9;  
  height: 55.35em; 
} 

</style>