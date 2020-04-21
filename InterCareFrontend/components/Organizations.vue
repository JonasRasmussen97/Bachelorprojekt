<template>
  <div class="row">
  <div class="col">
<h2>Organizations</h2>
 <div>
    <b-table striped hover dark :items="items"></b-table>
  </div>
  </div>
  </div>
</template>

<script>
export default {
  mounted() {
    this.getAllOrganizations();
  },
   data() {
      return {
        items: [
          
        ]
      }
    },
    methods: {
      getAllOrganizations() {
var myHeaders = new Headers();
myHeaders.append("Authorization", "Bearer " + this.token);
var urlencoded = new URLSearchParams();

var requestOptions = {
  method: 'GET',
  headers: myHeaders,
  redirect: 'follow'
};

fetch("http://localhost:55246/api/getAllOrganizationsAsClient", requestOptions)
  .then(response => response.text())
  .then(result => {
    var i; 
    for(i = 0; i < JSON.parse(result).length; i++) {
     this.items.push({Organization: JSON.parse(result)[i].name});
      console.log(JSON.parse(result)[i].name);
    }
  })
  .catch(error => console.log('error', error));
  },
      }
    }
</script>

<style scoped>

</style>