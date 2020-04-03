<template>
  <div class="row">
  <div class="col">
<h2>Organization Locations</h2>
 <div>
    <b-table striped hover dark responsive="sm" :fields="fields" :items="items">
      <template v-slot:cell(edit)>
      <b-button @click="methodHere()" size="sm">Edit</b-button>
      </template>
    </b-table>
  </div>
  </div>
  </div>
</template>

<script>
export default {
   data() {
      return {
        fields: [
         'Location', 'Address', 'PostalCode', 'Country', 'Images', 'Edit'   
        ],
        items: [
          { Location: "Nylocation2", Address: 'Bedevej 28', PostalCode: '5700', Country: 'Danmark', Images: "None"},
          { Location: "Nylocation3", Address: 'Bedevej 28', PostalCode: '5700', Country: 'Danmark', Images: "None"}
        ]
      }
    }
}
</script>
