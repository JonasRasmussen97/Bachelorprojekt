<template>
<client-only>
  <div v-if="Token === undefined" class="login-form">
        <h2 class="text-center">Log in</h2>       
        <div  class="form-group">
            <input type="text"  v-model="email" class="form-control" placeholder="Email" required="required">
        </div>
        <div class="form-group">
            <input type="password" v-model="password" class="form-control" placeholder="Password" required="required">
        </div>
        <div class="form-group">
            <button v-on:click="login()" class="btn btn-primary btn-block">Log in</button>
        </div>
        <div class="clearfix">
            <a href="#" class="text-center">Forgot Password?</a>
        </div>        
    <p class="text-center"><a href="#">Create an Account</a></p>
    <p class="text-center">Login status: {{status}}</p>
  </div>
</client-only>
</template>


<script>
import Cookies from 'js-cookie'
import axios from 'axios'
export default {
  data: function() {
    return {
      Token: Cookies.get('token'),
      email: "",
      password: "",
      Resp: "",
      status: ""
    }
  },
  methods: {
  login() {
var myHeaders = new Headers();
myHeaders.append("Content-Type", "application/x-www-form-urlencoded");
var urlencoded = new URLSearchParams();
urlencoded.append("email", this.email);
urlencoded.append("password", this.password);

var requestOptions = {
  method: 'POST',
  headers: myHeaders,
  body: urlencoded,
  redirect: 'follow'
};

fetch("http://localhost:55246/api/login", requestOptions)
  .then(response => response.text())
  .then(result => {
      if(JSON.parse(result).token != null) {
      console.log(JSON.parse(result).token);
      Cookies.set("token", JSON.parse(result).token);
      this.status = "You are logged in!";
      } else {
        this.status ="Unable to login!";
      }
  });
  }
  }
}
</script>

<style scoped>
.login-form {
		width: 340px;
    	margin: 50px auto;
	}
    .login-form form {
    	margin-bottom: 15px;
        background: #f7f7f7;
        box-shadow: 0px 2px 2px rgba(0, 0, 0, 0.3);
        padding: 30px;
    }
    .login-form h2 {
        margin: 0 0 15px;
    }
    .form-control, .btn {
        min-height: 38px;
        border-radius: 2px;
    }
    .btn {        
        font-size: 15px;
        font-weight: bold;
    }
</style>