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
   data() {
      return {
        items: [
          { Organization: "Bobby's Hospital", Specialities: 'Dog Food', Locations: 'Macdonald' },
        ]
      }
    }
}
</script>

<style scoped>

</style>