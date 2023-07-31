<template>
  <WalletHeader />
  <main style="padding: 20px">
    <RouterView />
  </main>
</template>

<script setup lang="ts">
import { RouterView } from 'vue-router';
import WalletHeader from '@/components/WalletHeader.vue';
</script>
