<template>
  <div>Account id = {{ route.params.id }}</div>
</template>

<script setup lang="ts">
import useAccountTransactions from '@/composables/use-account-transactions';
import { watch } from 'vue';
import { useRoute } from 'vue-router';

const route = useRoute();
const { transactions } = useAccountTransactions(route.params.id as unknown as number);

watch(transactions, ()=> {
  console.log('transactions', transactions.value);
});

</script>

<style>
</style>
