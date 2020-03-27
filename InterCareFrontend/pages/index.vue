<template>
  <div class="html">
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
        <div class="col-12">
          <section>
            <h1>GET API Result Index</h1>
            <div>
              <button v-on:click="asyncData">Greet</button>
            </div>
          </section>
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
  components: {
    Navbar,
    LoginForm,
    Footer
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
}
.welcomeText {
  font-size: 55px;
  font-family: "Trebuchet MS", "Lucida Sans Unicode", "Lucida Grande",
    "Lucida Sans", Arial, sans-serif;
  color: rgb(40, 109, 211);
  margin-top: 150px;
}
.html {
  /* The image used */
  background-image: url("https://www.ecopetit.cat/wpic/mpic/8-85314_minimalist-macbook-wallpaper-hd.jpg");
  /* Center and scale the image nicely */
  /* Full height */
  height: 100%;
  background-position: center;
  background-repeat: no-repeat;
  background-size: cover;
}
</style>