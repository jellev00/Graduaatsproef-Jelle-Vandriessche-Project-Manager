<script setup>
    import { RouterLink } from 'vue-router';
    import { ref } from 'vue';
    import axios from 'axios';
    import folder from '../assets/SVG/Folder.svg';
    import plus from '../assets/SVG/Plus.svg';
    import addProject from '../components/AddProject.vue';

    const userData = ref([]);
    const showModal = ref(false);

    const fetchData = async () => {
        try {
            const response = await axios.get('http://localhost:5035/api/User/ById/1');
            userData.value = response.data;
            console.log("home ", response.data);
        } catch (error) {
            console.error('Error fetching data:', error);
        }
    };

    fetchData();

        const openModal = () => {
            showModal.value = true;
        };

        const closeModal = () => {
            showModal.value = false;
            fetchData();
        };
</script>

<template>
    <div class="flex justify-center items-center w-740 h-480 py-4 text-white">
        <div class="h-460 w-52 bg-slate-800 rounded-3xl p-4 flex flex-col justify-between z-10">
            <div class="h-360 scrollable-container">
                <p class="text-slate-500">Projects</p>
                <div v-for="project in userData.projects" :key="project.projectId" class="flex items-center w-28 my-4">
                    <div v-if="project" class="w-2 h-2 rounded-full mr-5" :style="{ backgroundColor: project.color }"></div>
                    <p v-if="project" class="text-sm">{{ project.name }}</p>
                </div>
            </div>
            <div class="flex justify-center">
                <button @click="openModal" class="flex justify-around items-center h-10 w-150 bg-slate-700 rounded-xl p-2">
                    <img :src="plus" alt="Folder Icon" class="w-4 h-4"/>
                    <p class="text-slate-500 text-sm">Add New Project</p>
                </button>
            </div>
        </div>

        <add-project v-if="showModal" @close="closeModal" class="fixed top-0 left-0 w-full h-full flex items-center justify-end px-40 bg-black bg-opacity-50 z-50" />

        <div class="h-460 w-532 px-12 text-slate-800 scrollable-container z-10">
            <div class="flex flex-wrap gap-9">
                <div v-for="project in userData.projects" :key="project.projectId" class="flex flex-col justify-between items-center h-26">
                    <router-link
                        :to="{ name: 'projectDetails', params: { projectId: project.projectId } }"
                        class="flex flex-col justify-between items-center h-26"
                    >
                        <div v-if="project" class="w-20 h-20 rounded-2xl flex justify-center items-center" :style="{ backgroundColor: project.color }">
                            <img :src="folder" alt="Folder Icon" class="w-8 h-8"/>
                        </div>
                        <p v-if="project" class="text-sm">{{ project.name }}</p>
                    </router-link>
                </div>
            </div>
        </div>
    </div>
</template>

<style scoped>
.scrollable-container {
  overflow-y: auto;
  max-height: 460px; /* Set the maximum height as needed */
}

/* Custom scrollbar styling */
.scrollable-container::-webkit-scrollbar {
  width: 2px; /* Set the width of the scrollbar */
}

.scrollable-container::-webkit-scrollbar-thumb {
  background-color: #0f172a; /* Set the color of the thumb */
  border-radius: 2px; /* Set the border-radius of the thumb */
}

.scrollable-container::-webkit-scrollbar-track {
  background-color: #cbd5e1; /* Set the color of the track */
}
</style>