<script setup>
    import { RouterLink } from 'vue-router';
    import { ref } from 'vue';
    import axios from 'axios';

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
                <p class="text-slate-500">Tasks</p>
                <div v-for="task in userData.userTasks" :key="task.taskId" class="flex items-center w-28 my-4">
                    <div v-if="task" class="w-2 h-2 rounded-full mr-5" :style="{ backgroundColor: task.color }"></div>
                    <p v-if="task" class="text-sm">{{ task.taskName }}</p>
                </div>
            </div>
            <div class="h-460 w-532 px-12 text-slate-800 scrollable-container">
                <div class="flex flex-col">
                    <div v-for="task in userData.userTasks" :key="task.taskId" class="flex flex-col justify-between items-center mb-5">
                        <div v-if="task" class="w-510 h-160 rounded-2xl flex flex-col justify-around items-start p-3.5" :style="{ border: `2px solid ${task.color}` }">
                            <div class="flex items-center">
                                <input type="checkbox" name="" id="" class="mr-2 cursor-pointer">
                                <p v-if="task" class="text-sm">{{ task.taskName }}</p>
                            </div>
                            <div>
                                <p v-if="task" class="text-sm">{{ task.taskDescription }}</p>
                            </div>
                        </div>
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