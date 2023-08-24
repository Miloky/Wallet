<template>
  <div>loading animation</div>
</template>

<script setup lang="ts">
import { mgr } from '@/router/auth-service';
import { onBeforeMount } from 'vue';

onBeforeMount(async (): Promise<void> => {
  // TODO: Do we need to await ?
  await mgr.signoutRedirect();
});
</script>
