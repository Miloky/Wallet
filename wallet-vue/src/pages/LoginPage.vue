<template>
  <h1>Login page</h1>
</template>

<script setup lang="ts">
import authService from '@/router/auth-service';
import { onMounted } from 'vue';

onMounted(() => {
  authService.login();
});
</script>
