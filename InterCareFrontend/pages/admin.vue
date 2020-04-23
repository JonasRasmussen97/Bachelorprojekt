<template>
<div class="wrap">
    <div class="container">
      <div class="row justify-content-end">
        <div class="col-4">
          <div class="logo">InterCare</div>
        </div>
        <div class="col-8">
          <Navbar></Navbar>
        </div>
      </div>
      <div class="row" v-if="type === 'InterCare Admin'">
 <div class="col-12">
  <AllInformation></AllInformation>
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
import Cookies from 'js-cookie'
import Navbar from "~/components/Navbar";
import LoginForm from "~/components/LoginForm";
import Footer from "~/components/Footer";
import AllInformation from "~/components/AllInformation";
import axios from "axios";
export default {
   data: function() {
    return {
      token: Cookies.get('token'),
      type: ""
      
    }
    },
  components: {
    Navbar,
    LoginForm,
    Footer,
    AllInformation
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
  height: 65em; 
} 

</style>