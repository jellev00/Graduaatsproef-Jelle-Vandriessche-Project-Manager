<script setup>
import { RouterLink } from 'vue-router';
import { ref, onMounted, defineProps, watch  } from 'vue';
import axios from 'axios';
import plus from '../assets/SVG/Plus.svg';
import trash from '../assets/SVG/Trash.svg'
import addProjectTask from './AddProjectTask.vue';

const props = defineProps(['projectId']);
const projectData = ref([]);
const showModal = ref(false);

const fetchProjectDetails = async (id) => {
    if (!id) {
        return;
    }

    try {
        const response = await axios.get(`http://localhost:5035/api/Project/${id}`);
        projectData.value = response.data;
        console.log('Project details:', response.data);
    } catch (error) {
        console.error('Error fetching project details:', error);
    }
};

// Use a watcher to reactively fetch project details when projectId changes
watch(() => props.projectId, (newId, oldId) => {
    if (newId !== oldId) {
        fetchProjectDetails(newId);
    }
});

const deleteTask = async (taskId) => {
    try {
        const response = await axios.delete(`http://localhost:5035/api/Project/Task/${taskId}`);
        if (response.status === 204) {
            alert(`Task with ID ${taskId} deleted successfully.`);
            fetchProjectDetails(props.projectId);
            window.location.reload();
        } else {
            alert(`Failed to delete task with ID ${taskId}. ${response.status}`);
        }
    } catch (error) {
        alert('Error deleting task:', error);
    }
};

const updateTaskStatus = async (taskId, newStatus) => {
    try {
        const response = await axios.put(
            `http://localhost:5035/api/Project/UpdateTaskStatus/${taskId}`,
            JSON.stringify(newStatus),
            { headers: { 'Content-Type': 'application/json' } }
        );

        if (response.status === 200) {
            // Update the local userData with the latest task statuses
            fetchProjectDetails();
        } else {
            alert(`Failed to update task status. ${response.status}`);
        }
    } catch (error) {
        console.error('Error updating task status:', error);
        alert('Error updating task status. See console for details.');
    }
};

const openModal = () => {
    showModal.value = true;
};

const closeModal = () => {
    showModal.value = false;
    // window.location.reload();
};

const handleTaskAdded = () => {
    fetchProjectDetails(props.projectId);
    window.location.reload();
};

const daysLeft = (taskDate) => {
    const currentDate = new Date();
    const taskDateObject = new Date(taskDate);
    const timeDifference = taskDateObject.getTime() - currentDate.getTime();
    const daysDifference = Math.ceil(timeDifference / (1000 * 3600 * 24));
    return daysDifference;
};

</script>

<template>
    <div class="flex justify-center items-center w-740 h-480 py-4 text-white">
        <div class="h-460 w-52 bg-slate-800 rounded-3xl p-4 flex flex-col justify-between z-10">
            <div class="h-360 scrollable-container">
                <p class="text-slate-500">Tasks</p>
                <div v-for="task in projectData.projectTasks" :key="task.taskId" class="flex items-center w-28 my-4">
                    <div v-if="task" class="w-2 h-2 rounded-full mr-5" :style="{ backgroundColor: task.color }"></div>
                    <p v-if="task" class="text-sm" :style="{ 'text-decoration': task.status ? 'line-through' : 'none' }">{{ task.taskName }}</p>
                </div>
            </div>
            <div class="flex justify-center">
                <button @click="openModal" class="flex justify-around items-center h-10 w-150 bg-slate-700 rounded-xl p-2">
                    <img :src="plus" alt="Folder Icon" class="w-4 h-4" />
                    <p class="text-slate-500 text-sm">Add New Task</p>
                </button>
            </div>
        </div>
        <add-project-task v-if="showModal" @close="closeModal" @taskAdded="handleTaskAdded" :projectId="projectData.projectId"
            class="fixed top-0 left-0 w-full h-full flex items-center justify-end px-40 bg-black bg-opacity-50 z-50" />
        <div class="h-460 w-532 px-12 text-slate-800 scrollable-container z-10">
            <div class="flex flex-col">
                <div v-for="task in projectData.projectTasks" :key="task.taskId"
                    class="flex flex-col justify-between items-center mb-5">
                    <div v-if="task" class="w-510 h-160 rounded-2xl flex flex-col justify-around items-start p-3.5"
                        :style="{ border: `2px solid ${task.color}` }">
                        <div class="w-full flex justify-between items-center">
                            <div class="flex">
                                <input type="checkbox" name="" id="" class="mr-2 cursor-pointer" v-model="task.status" @change="updateTaskStatus(task.taskId, task.status)">
                                <p v-if="task" class="text-sm" :style="{ 'text-decoration': task.status ? 'line-through' : 'none' }">{{ task.taskName }}</p>
                            </div>
                            <div class="w-36 flex justify-between items-center">
                                <p v-if="task" class="text-sm">
                                    <!-- {{ task.date }} -->
                                    <span v-if="daysLeft(task.date) > 0">Days Left: {{ daysLeft(task.date) }}</span>
                                    <span v-else-if="daysLeft(task.date) < 0">Days Overdue: {{ -daysLeft(task.date)
                                    }}</span>
                                    <span v-else>Today is the day!</span>
                                </p>

                                <button @click="() => deleteTask(task.taskId)">
                                    <img :src="trash" alt="Folder Icon" class="w-4 h-4" />
                                </button>
                            </div>
                        </div>
                        <div>
                            <p v-if="task" class="text-sm" :style="{ 'text-decoration': task.status ? 'line-through' : 'none' }">{{ task.taskDescription }}</p>
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
    max-height: 460px;
    /* Set the maximum height as needed */
}

/* Custom scrollbar styling */
.scrollable-container::-webkit-scrollbar {
    width: 2px;
    /* Set the width of the scrollbar */
}

.scrollable-container::-webkit-scrollbar-thumb {
    background-color: #0f172a;
    /* Set the color of the thumb */
    border-radius: 2px;
    /* Set the border-radius of the thumb */
}

.scrollable-container::-webkit-scrollbar-track {
    background-color: #cbd5e1;
    /* Set the color of the track */
}</style>