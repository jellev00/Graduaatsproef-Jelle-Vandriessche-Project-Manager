<script setup>
import { defineProps, defineEmits } from 'vue';

const props = defineProps(['close', 'projectId']);
const emit = defineEmits();

const task = {
    taskName: '',
    taskDescription: '',
    color: '',
    date: '',
};

const project = {
    projectId: props.projectId,
}

const closeModal = () => {
    emit('close'); // Emit an event to notify the parent component to close the modal
};


const addTask = async () => {
    try {
        const response = await fetch(`http://localhost:5035/api/Project/AddTask/${project.projectId}`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(task),
        });

        if (response.ok) {
            // Successfully added the task, you can handle the response here if needed
            alert('Task added successfully');
            closeModal();
        } else {
            // Handle error
            alert('Failed to add task');
        }
    } catch (error) {
        // Handle network error
        alert('Network error: ' + error.message);
    }
};
</script>

<template>
    <div>
        <div class="w-300 h-490 flex flex-col justify-between bg-white p-5 rounded-lg text-slate-500">
            <div class="flex flex-col justify-between h-96">
                <label for="taskName" class="text-sm">Task Name:</label>
                <input v-model="task.taskName" type="text" name="taskName" id="taskName"
                    class="w-260 h-9 p-2 border border-slate-500 rounded-lg">

                <label for="taskDescription" class="text-sm">Task Description:</label>
                <textarea v-model="task.taskDescription" maxlength="300" name="taskDescription" id="taskDescription"
                    class="w-260 h-185 p-2 border border-slate-500 rounded-lg"
                    style="resize: none; overflow-y: auto;"></textarea>

                <label for="colors" class="text-sm">Color:</label>
                <select v-model="task.color" name="colors" id="colors"
                    class="h-9 w-260 p-2 border border-slate-500 rounded-lg text-sm">
                    <option value="" disabled selected hidden>Select a color</option>
                    <option value="#58AEFF">🔵 Blue</option>
                    <option value="#FF8158">🟠 Orange</option>
                    <option value="#FFB658">🟡 Yellow</option>
                    <option value="#B058FF">🟣 Purple</option>
                    <option value="#E9527D">⭕ Pink</option>
                </select>

                <label for="date" class="text-sm">Date:</label>
                <input v-model="task.date" type="date" name="date" id="date"
                    class="h-9 w-260 p-2 text-sm border border-slate-500 rounded-lg">
            </div>
            <div class="flex justify-between">
                <button @click="addTask" class="h-10 w-120 rounded-xl bg-customGreen text-white">
                    Add
                </button>
                <button @click="closeModal" class="w-120 h-10 rounded-lg border-2 border-customGreen text-customGreen">
                    Cancel
                </button>
            </div>
    </div>
</div></template>

<style scoped></style>