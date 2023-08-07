import { createRouter, createWebHistory } from 'vue-router';
import HomeView from '@/pages/HomeView.vue';

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomeView
    },
    {
      path: '/account/:id',
      name: 'account-details',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../pages/AccountDetails.vue')
    },
    {
      path: "/:catchAll(.*)",
      name: '404',
      component: () => import('../pages/NotFound44.vue')
    }
  ]
});

export default router;
