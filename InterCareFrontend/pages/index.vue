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
        <div class="col-12">
          <section>
            <h1>GET API Result Index</h1>
            <div>
              <button v-on:click="getit()">{resp}</button>
            </div>
          </section>
        </div>
      </div>
      <div class="row">
      <div class="col">
        <button >{{this.JWT}}</button>
        <Footer></Footer>
        </div>
        </div>
    </div>
    </div>
    </div>
</template>

<script>
import { mapMutations } from 'vuex'
import Navbar from "~/components/Navbar";
import LoginForm from "~/components/LoginForm";
import Footer from "~/components/Footer";
import axios from "axios";
export default {

  computed: {
    JWT () {
      return this.$store.getters.JWT;
    }
  },
  resp: "Fetch",
  components: {
    Navbar,
    LoginForm,
    Footer
  },
  methods: {
    changeJWT(state, payload) {
      this.$store.commit(state, payload);
      console.log(this.JWT)
    },
},
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