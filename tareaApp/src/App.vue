
<template>
  <v-app>
    <v-main>
      <v-container>
        <Tarea />
      </v-container>
    </v-main>
  </v-app>
</template>

<script>
import Tarea from './components/Tarea.vue';


export default {
  name: 'App',
  components: {
    Tarea
  }
}
</script>

<style>


#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>