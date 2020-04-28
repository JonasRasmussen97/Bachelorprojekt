<template>
  <div class="row">
  <div class="col">
<h2>Organization</h2>
    <b-table striped hover dark responsive="sm" :fields="fields" :items="items">
      <template v-slot:cell(edit)>
      <b-button size="sm">Edit</b-button>
      </template>
    </b-table>
        <div class="row">
    <div class="col">
      </div> 
    </div>
  </div>
  </div>
</template>

<script>
import Cookies from 'js-cookie'
export default {
  mounted() {
    this.getAdminOrganization();
  },
   data() {
      return {
        token: Cookies.get('token'),
        fields: [
         'Organization', 'Location', 'Edit'   
        ],
        items: [
          
        ]
      }
    },
        methods: {
      getAdminOrganization() {
var myHeaders = new Headers();
myHeaders.append("Authorization", "Bearer " + this.token);
var urlencoded = new URLSearchParams();

var requestOptions = {
  method: 'GET',
  headers: myHeaders,
  redirect: 'follow'
};

fetch("http://localhost:55246/api/getOrganizationFromAdminId", requestOptions)
  .then(response => response.text())
  .then(result => {
    var i; 
     this.items.push({Organization: JSON.parse(result).name, Location: JSON.parse(result).locations});
  })
  .catch(error => console.log('error', error));
  },
      }
    }

</script>