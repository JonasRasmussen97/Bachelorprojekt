<template>
  <div>
    <b-navbar toggleable="lg" type="dark" variant="dark">
      <b-navbar-toggle target="nav-collapse"></b-navbar-toggle>

      <b-collapse id="nav-collapse" is-nav>
        <b-navbar-nav small>
          <b-nav-item href="/">Home</b-nav-item>
          <b-nav-item href="/Client">Client</b-nav-item>
          <b-nav-item href="/Manager">Manager</b-nav-item>
          <b-nav-item href="/OAdmin">Organization Admin</b-nav-item>
          <b-nav-item href="/Admin">InterCare Admin</b-nav-item>
          
          <b-nav-item-dropdown text="User">
            <b-dropdown-item v-if="Token === undefined" href="/">Log In</b-dropdown-item>
            <b-dropdown-item v-if="Token != undefined" v-on:click="logout()" href="/">Logout</b-dropdown-item>
          </b-nav-item-dropdown>
        </b-navbar-nav> 
      </b-collapse>
    </b-navbar>
  </div>
</template>

<script>
import Cookies from 'js-cookie'
export default {
 data: function() {
    return {
      Token: Cookies.get('token') 
    }
  },
  methods: {
    logout() {
      Cookies.remove('token');
      this.$router.go("/")
    }
  }
}
</script>

<style scoped>
.navbar {
  margin-top: 10px;
}
</style>
