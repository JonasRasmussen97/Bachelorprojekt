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
      <div class="row">
 <div class="col-12">
  <OrganizationAndLocations></OrganizationAndLocations>
        </div>
     <div>
      </div>
      </div>
      <div class="row">
      <div class="col">
        <Footer></Footer>
        </div>
        </div>
  </div>
  </div>
</template>

<script>
import Navbar from "~/components/Navbar";
import LoginForm from "~/components/LoginForm";
import Footer from "~/components/Footer";
import OrganizationAndLocations from "~/components/OrganizationAndLocations";
import axios from "axios";
export default {
  components: {
    Navbar,
    LoginForm,
    Footer,
    OrganizationAndLocations
  },
  methods: {
    async asyncData() {
      // Working PUT REQUEST.
      var myHeaders = new Headers();
      var formdata = new FormData();
      formdata.append("email", "JonasBig");
      formdata.append("fullName", "Big bananaman");
      formdata.append("password", "dirtydirty");
      formdata.append("accessLevel", "0");
      formdata.append("gender", "Male");
      formdata.append("age", "2000");
      var requestOptions = {
        method: "PUT",
        headers: myHeaders,
        body: formdata,
        redirect: "follow"
      };
      fetch("http://localhost:55246/api/createClient", requestOptions)
        .then(response => response.text())
        .then(result => console.log(result))
        .catch(error => console.log("error", error));
    },
    async getUser() {
      const url = "http://localhost:55246/api/";
      axios({
        method: "get",
        url: url
      }).then(data => (this.data = data));
      return { articles: data };
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