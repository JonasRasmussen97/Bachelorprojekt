<template>
  <div class="row">
  <div class="col">
<h2>Organization Location</h2>
 <div>
    <b-table striped hover dark responsive="sm" :fields="fields" :items="items">
      <template v-slot:cell(edit)>
      <b-button size="sm">Edit</b-button>
      </template>
    </b-table>
  </div>
  </div>
  </div>
</template>

<script>
import Cookies from 'js-cookie';
export default {
  
  mounted() {
    this.getLocations();
  },
  
   data() {
      return {
        token: Cookies.get('token'),
        fields: [
         'Location', 'Address', 'PostalCode', 'Country', 'Images', 'Edit'   
        ],
        items: [
      
        ]
      }
    },
      methods: {
      getLocations() {
var myHeaders = new Headers();
myHeaders.append("Authorization", "Bearer " + this.token);
var urlencoded = new URLSearchParams();

var requestOptions = {
  method: 'GET',
  headers: myHeaders,
  redirect: 'follow'
};

fetch("http://localhost:55246/api/getLocationFromManagerId", requestOptions)
  .then(response => response.text())
  .then(result => {
    var i; 
     this.items.push({Location: JSON.parse(result).name, Address: JSON.parse(result).address, PostalCode: JSON.parse(result).postalCode, Country: JSON.parse(result).country, Images: JSON.parse(result).images });
  })
  .catch(error => console.log('error', error));
  },
      }
    }
</script>
