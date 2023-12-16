<script setup>
    import proFlow from '../assets/ProFLOW.png';
    import { RouterLink } from 'vue-router';
    import { ref } from 'vue';
    import axios from 'axios';

    const userData = ref(null);

    const fetchData = async () => {
        try {
            const response = await axios.get('http://localhost:5035/api/User/ById/1');
            userData.value = response.data;
            console.log("home ", response.data)
        } catch (error) {
            console.error('Error fetching data:', error);
        }
    };

    fetchData();
</script>

<template>
    <div class="flex justify-center items-center w-740 h-460 text-white">
        <div class="flex flex-col justify-between items-center bg-slate-800 p-8 w-740 h-375 rounded-50">
            <img :src="proFlow" alt="ProFLOW">
            <p v-if="userData" class="text-xl">Welcome <span class="text-customGreen">{{ userData.first_Name }}</span></p>
            <div class="w-80 flex justify-between items-center">
                <RouterLink :to="{ name: 'project' }">
                    <button class="w-36 h-12 rounded-xl bg-customGreen">
                        Create Project
                    </button>
                </RouterLink>
                <RouterLink :to="{ name: 'tasks' }">
                    <button class="w-36 h-12 rounded-lg border-2 border-customGreen">
                        Create Task
                    </button>
                </RouterLink>
            </div>
            <p class="text-sm"><span class="text-customGreen">Pro</span>FLOW<span class="text-customGreen">.</span> © 2023</p>
        </div>
    </div>
</template>

<style scoped>

</style>
