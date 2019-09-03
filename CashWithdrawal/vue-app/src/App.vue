<template>
  <div id="app">
    
    <atm />
  </div>
</template>

<script>
import atm from './components/ATM.vue'

export default {
  name: 'app',
  components: {
    atm
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
