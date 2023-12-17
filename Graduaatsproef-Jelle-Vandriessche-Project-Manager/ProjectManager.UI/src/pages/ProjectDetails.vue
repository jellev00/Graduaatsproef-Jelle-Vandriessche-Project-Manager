<script setup>
    import { ref, onMounted } from 'vue';
    import axios from 'axios';
    import { useRoute, useRouter } from 'vue-router';
    import trash from '../assets/SVG/Trash.svg';
    import projectTask from '../components/ProjectTask.vue'

    const projectData = ref([]);
    const projectId = ref(null);
    const router = useRouter();

    const fetchProjectDetails = async () => {
        try {
            const response = await axios.get(`http://localhost:5035/api/Project/${projectId.value}`);
            // Handle response data as needed
            projectData.value = response.data;
            console.log('Project details:', response.data);
        } catch (error) {
            console.error('Error fetching project details:', error);
        }
    };

    const deleteTask = async (projectId) => {
        try {
            const response = await axios.delete(`http://localhost:5035/api/User/Project/${projectId}`);
            if (response.status === 204) {
                alert(`Project with ID ${projectId} deleted successfully.`);
                router.push({ name: 'project' });
            } else {
                alert(`Failed to delete Project with ID ${projectId}. ${response.status}`);
            }
        } catch (error) {
            alert('Error deleting Project:', error);
        }
    };

    onMounted(() => {
        // Access projectId from the route parameter using useRoute
        const route = useRoute();
        projectId.value = route.params.projectId;

        fetchProjectDetails();
    });
</script>

<template>
    <div class="text-slate-500">
        <div class="scrollable-container pr-4 mt-2">
            <div>
                <div class="w-full flex justify-between items-center my-4">
                    <div class="w-28 flex items-center">
                        <div v-if="projectData" class="h-2 w-2 rounded-full mr-5" :style="{ backgroundColor: projectData.color }"></div>
                        <p v-if="projectData" class="text-sm">{{ projectData.name }}</p>
                    </div>

                    <div>
                        <button @click="() => deleteTask(projectData.projectId)">
                            <img :src="trash" alt="Folder Icon" class="w-4 h-4"/>
                        </button>
                    </div>
                </div>
                <div v-if="projectData" class="w-full h-160 rounded-2xl flex flex-col justify-start items-start p-3.5" :style="{ border: `2px solid ${projectData.color}` }">
                    <p v-if="projectData" class="text-sm">{{ projectData.description }}</p>
                </div>
            </div>

            <div>
                <div class="h-480 mt-24">
                    <project-task :projectId="projectData.projectId" />
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