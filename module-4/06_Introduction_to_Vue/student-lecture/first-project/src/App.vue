<template>
  <div id="app">
    <first-component />
    <first-component />
  </div>
</template>

<script>
import FirstComponent from './components/FirstComponent.vue'

export default {
  name: 'app',
  components: {
    FirstComponent
  }
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
