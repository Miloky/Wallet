import { createRouter, createWebHistory } from 'vue-router';
import DashboardPage from '@/pages/DashboardPage.vue';
import AccountsPage from '@/pages/AccountsPage.vue';
import TransactionsPage from '@/pages/TransactionsPage.vue';
import LogoutPage from '@/pages/LogoutPage.vue';


const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      name: 'Dashboard',
      path: '/',
      component: DashboardPage
    },
    {
      name: 'Accounts',
      path: '/accounts',
      component: AccountsPage
    },
    {
      name: 'Transactions',
      path: '/transactions',
      component: TransactionsPage
    },
    {
      path: '/account/:id',
      name: 'account-details',
      // route level code-splitting
      // this generates a separate chunk (About.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import('../pages/AccountDetailsPage.vue')
    },
    {
      name: 'Logout',
      path: '/logout',
      component: LogoutPage
    },
    {
      path: '/:catchAll(.*)',
      name: '404',
      component: () => import('../pages/NotFoundPage.vue')
    }
  ]
});

export default router;
