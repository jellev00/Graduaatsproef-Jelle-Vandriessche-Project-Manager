<script setup>
import { RouterView, RouterLink, useRoute } from 'vue-router';
import { ref, computed, onMounted } from 'vue';
import axios from 'axios';

const userData = ref(null);
const route = useRoute();

const fetchData = async () => {
  try {
    const response = await axios.get('http://localhost:5035/api/User/ById/1');
    userData.value = response.data;
  } catch (error) {
    console.error('Error fetching data:', error);
  }
};

onMounted(() => {
  fetchData();
});

const firstInitial = computed(() => userData.value?.first_Name?.charAt(0) || '');
const lastInitial = computed(() => userData.value?.last_Name?.charAt(0) || '');

const isLinkActive = (routeName) => {
  return route.name === routeName;
};
</script>

<template>
  <div class="bg-white w-screen h-screen p-5 text-slate-800">
    <nav class="flex justify-between">
      <ul class="w-52 flex justify-between">
        <li :class="{ 'font-bold': isLinkActive('home') }">
          <!-- <RouterLink v-if="userData" :to="{ name: 'home', params: { userId: userData.userId } }">Home</RouterLink> -->
          <RouterLink :to="{ name: 'home'}">Home</RouterLink>
        </li>
        <li :class="{ 'font-bold': isLinkActive('project') }">
          <RouterLink :to="{ name: 'project' }">Projects</RouterLink>
        </li>
        <li :class="{ 'font-bold': isLinkActive('tasks') }">
          <RouterLink :to="{ name: 'tasks' }">Tasks</RouterLink>
        </li>
      </ul>
      <div class="flex justify-center items-center bg-customGreen w-8 h-8 rounded-full text-white text-sm">
        <p v-if="userData">{{ firstInitial }}{{ lastInitial }}</p>
      </div>
    </nav>
    <RouterView />
  </div>
</template>

<style scoped>/* Your styles here */</style>
