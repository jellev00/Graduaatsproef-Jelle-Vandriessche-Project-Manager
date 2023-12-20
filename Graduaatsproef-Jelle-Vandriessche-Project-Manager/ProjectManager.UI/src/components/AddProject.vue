<script setup>
    import { defineProps, defineEmits } from 'vue';
    import axios from 'axios';

    const props = defineProps(['close']);
    const emit = defineEmits();

    const project = {
        name: '',
        description: '',
        color: '',
    };

    const closeModal = () => {
        emit('close'); // Emit an event to notify the parent component to close the modal
    };

    const addProject = async () => {
        try {
            const response = await axios.post('http://localhost:5035/api/User/AddProject/1', JSON.stringify(project), {
                headers: {
                    'Content-Type': 'application/json',
                },
            });

            if (response.status === 201) {
                // Successfully added the project, you can handle the response here if needed
                alert('Project added successfully');
                closeModal();
            } else {
                // Handle error
                alert('Failed to add Project');
            }
        } catch (error) {
            // Handle network error
            alert('Network error: ' + error.message);
        }
    };
</script>

<template>
    <div>
        <div class="w-300 h-460 flex flex-col justify-between bg-white p-5 rounded-lg text-slate-500">
            <div class="flex flex-col justify-between h-360">
                <label for="Name" class="text-sm">Task Name:</label>
                <input v-model="project.name" type="text" name="Name" id="Name" class="h-9 w-260 p-2 border border-slate-500 rounded-lg">

                <label for="Description" class="text-sm">Task Description:</label>
                <textarea v-model="project.description" maxlength="300" name="Description" id="Description" class="w-260 h-185 p-2 border border-slate-500 rounded-lg" style="resize: none; overflow-y: auto;"></textarea>
            
                <label for="colors" class="text-sm">Color:</label>
                <select v-model="project.color" name="colors" id="colors" class="h-9 w-260 p-2 border border-slate-500 rounded-lg text-sm">
                    <option value="" disabled selected hidden>Select a color</option>
                    <option value="#58AEFF">🔵 Blue</option>
                    <option value="#FF8158">🟠 Orange</option>
                    <option value="#FFB658">🟡 Yellow</option>
                    <option value="#B058FF">🟣 Purple</option>
                    <option value="#E9527D">⭕ Pink</option>
                </select>
            </div>
            <div class="flex justify-between">
                <button @click="addProject" class="h-10 w-120 rounded-xl bg-customGreen text-white">Add</button>
                <button @click="closeModal" class="w-120 h-10 rounded-lg border-2 border-customGreen text-customGreen">Cancel</button>
            </div>
        </div>
    </div>
</template>

<style scoped>

</style>