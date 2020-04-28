<template>
  <div>
    <div class="wrapping">
     <div class="container">
      <div class="row justify-content-end">
        <div class="col-4">
          <div class="logo">InterCare</div>
        </div>
        <div class="col-8">
          <Navbar></Navbar>
        </div>
      </div>
      </div>
      </div>
    <nuxt />
  </div>
</template>

<script>
import Navbar from "~/components/Navbar";
export default {
  components: {
    Navbar
  }
}
</script>

<style>
html {
  background-color:#3c68b9; 
  font-family: 'Source Sans Pro', -apple-system, BlinkMacSystemFont, 'Segoe UI',
    Roboto, 'Helvetica Neue', Arial, sans-serif;
  font-size: 16px;
  word-spacing: 1px;
  -ms-text-size-adjust: 100%;
  -webkit-text-size-adjust: 100%;
  -moz-osx-font-smoothing: grayscale;
  -webkit-font-smoothing: antialiased;
  box-sizing: border-box;
}

.wrapping {
  background-color:#3c68b9; 
}


*,
*:before,
*:after {
  box-sizing: border-box;
  margin: 0;
}

.button--green {
  display: inline-block;
  border-radius: 4px;
  border: 1px solid #3b8070;
  color: #3b8070;
  text-decoration: none;
  padding: 10px 30px;
}

.button--green:hover {
  color: #fff;
  background-color: #3b8070;
}

.button--grey {
  display: inline-block;
  border-radius: 4px;
  border: 1px solid #35495e;
  color: #35495e;
  text-decoration: none;
  padding: 10px 30px;
  margin-left: 15px;
}

.button--grey:hover {
  color: #fff;
  background-color: #35495e;
}
</style>
