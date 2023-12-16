<script setup>
    import { RouterLink } from 'vue-router';
    import { ref } from 'vue';
    import axios from 'axios';
    import folder from '../assets/SVG/Folder.svg'

    // const userData = ref({ projects: [] });
    const userData = ref([]);

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
</script>

<template>
    <div class="flex justify-center items-center w-740 h-480 py-4 text-white">
        <div class="h-460 w-52 bg-slate-800 rounded-3xl p-4">
            <p class="text-slate-500">Projects</p>
            <div v-for="project in userData.projects" :key="project.projectId" class="flex items-center w-28 my-4">
                <div v-if="project" class="w-2 h-2 rounded-full mr-5" :style="{ backgroundColor: project.color }"></div>
                <p v-if="project" class="text-sm">{{ project.name }}</p>
            </div>
        </div>
        <div class="h-460 w-532 px-12 text-slate-800">
            <div class="flex flex-wrap gap-9">
                <div v-for="project in userData.projects" :key="project.projectId" class="flex flex-col justify-between items-center h-26">
                    <div v-if="project" class="w-20 h-20 rounded-2xl flex justify-center items-center" :style="{ backgroundColor: project.color }">
                        <img :src="folder" alt="Folder Icon" class="w-8 h-8"/>
                    </div>
                    <p v-if="project" class="text-sm">{{ project.name }}</p>
                </div>
            </div>
        </div>
    </div>
</template>