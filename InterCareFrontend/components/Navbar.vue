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
          <b-nav-item href="#" disabled>Statistics</b-nav-item>
        </b-navbar-nav> 
      </b-collapse>
    </b-navbar>
  </div>
</template>

<style scoped>
.navbar {
  margin-top: 10px;
}
</style>
