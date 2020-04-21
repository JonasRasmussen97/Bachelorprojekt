<template>
 <div class="row">
  <div class="col">
<h2>Organizations</h2>
    <b-table striped hover dark responsive="sm" :fields="fields" :items="items">
      <template v-slot:cell(edit)>
      <b-button @click="methodHere()" size="sm">Edit</b-button>
      </template>
    </b-table>
     <div class="row">
    <div class="col">
     <div class="row">
    <div class="col">
<h2>Users</h2>
 <div>
    <b-table striped hover dark responsive="sm" :fields="fields2" :items="items2">
      <template v-slot:cell(edit)>
      <b-button @click="methodHere()" size="sm">Edit</b-button>
      </template>
    </b-table>
  </div>
      </div> 
    </div>
  </div>
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
        fields: [
         'Organization', 'Location', 'Edit'   
        ],
        items: [
         
        ],
        fields2: [
          'Email', 'Full Name', 'Type'
        ],
        items2: [
            { Email: "Nylocation2", 'Full Name': 'Bedevej 28', Type: '5700'},
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

fetch("http://localhost:55246/api/getAllOrganizations", requestOptions)
  .then(response => response.text())
  .then(result => {
    var i; 
    for(i = 0; i < JSON.parse(result).length; i++) {
     this.items.push({Organization: JSON.parse(result)[i].name, Location: JSON.parse(result)[i].locations});
    }
  })
  .catch(error => console.log('error', error));
  },
      }
    }
</script>