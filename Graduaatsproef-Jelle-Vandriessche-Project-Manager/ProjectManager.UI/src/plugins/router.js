import { createRouter, createWebHistory } from "vue-router";

const routes = [
    {
        // path: '/:userId', 
        path: '/', 
        name: 'home', 
        component: () => import('../pages/Home.vue')
    },
    {
        path: '/Projects', 
        name: 'project', 
        component: () => import('../pages/Projects.vue')
    },
    {
        path: '/Projects/:projectId', 
        name: 'projectDetails', 
        component: () => import('../pages/ProjectDetails.vue')
    },
    {
        path: '/Tasks', 
        name: 'tasks', 
        component: () => import('../pages/Tasks.vue')
    },
]

const router = createRouter({
    routes,
    history: createWebHistory(),
})

export default router