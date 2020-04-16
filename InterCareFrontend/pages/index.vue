<template>
<div class="wrap">
<div class="container-fluid">
    <div class="container">
      <div class="row justify-content-end">
        <div class="col-4">
          <div class="logo">InterCare</div>
        </div>
        <div class="col-8">
          <Navbar></Navbar>
        </div>
      </div>
      <div class="row">
        <div class="col-12 text-center">
          <div class="welcomeText">Welcome back!</div>
        </div>
      </div>
      <div class="row">
        <div class="col-12">
          <LoginForm></LoginForm>
        </div>
      </div>
      <div class="row">
      <div class="col">
        <Footer></Footer>
        </div>
        </div>
    </div>
    </div>
    </div>
</template>

<script>
import Navbar from "~/components/Navbar";
import LoginForm from "~/components/LoginForm";
import Footer from "~/components/Footer";
import axios from "axios";
export default {
  resp: "Fetch",
  components: {
    Navbar,
    LoginForm,
    Footer
  },
  methods: {
    async fetchJWT() {
      // Error handling and such omitted here for simplicity.
      const res = await fetch(`http://localhost:55246/api/login/`);
      this.jwt = await res.text();
    },
     async doSomethingWithJWT() {
     var myHeaders = new Headers();
     myHeaders.append("Authorization", "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJleHAiOjE1ODU5MTcyNjIsInVzZXJuYW1lIjoiVGhvbWFzIiwicGFzc3dvcmQiOiJOaWdnYSIsImFjY2Vzc0xldmVsIjoiMCJ9.XoiChMMimfM8ABYLRfGyctdipmO6GHPLuNOYs-GIBdA");

    var urlencoded = new URLSearchParams();

var requestOptions = {
  method: 'GET',
  headers: myHeaders,
  redirect: 'follow'
};

fetch("http://localhost:55246/api/test", requestOptions)
  .then(response => response.text())
  .then(result => console.log(result))
  .catch(error => console.log('error', error));
  },
}
}

</script>

<style>

.logo {
  font-size: 45px;
  font-weight: 400;
  color: white;
}
.welcomeText {
  font-size: 55px;
  font-family: "Trebuchet MS", "Lucida Sans Unicode", "Lucida Grande",
    "Lucida Sans", Arial, sans-serif;
  color: white;
  margin-top: 90px;
}

.wrap{
  background-color:#3c68b9;  
  height: 55.35em; 
}  


</style>