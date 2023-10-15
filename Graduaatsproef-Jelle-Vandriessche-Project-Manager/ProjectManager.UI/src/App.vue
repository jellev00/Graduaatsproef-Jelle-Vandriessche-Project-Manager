<script setup>
  import { RouterView, RouterLink } from 'vue-router';
</script>

<template>
  <!-- Test routerlinks -->
  <div class="bg-gray-700 w-screen h-screen">
      <ul>
      <li><RouterLink :to="{ name: 'home' }">Home</RouterLink></li>
      <li><RouterLink :to="{ name: 'about' }">About</RouterLink></li>
    </ul>
    <RouterView />
  </div>
</template>

<style scoped>

</style>
