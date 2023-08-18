<template>
  <div class="row justify-end">
    <q-btn icon="add" color="primary" label="Add" />
  </div>
  <div class="row">
    <div
      class="col-4 q-gutter-sm"
      v-for="acc in accounts"
      v-bind:key="acc.id"
      @click="() => clickHandler(acc.id)"
    >
      <q-card class="my-card cursor-pointer" flat bordered>
        <q-card-section horizontal>
          <q-card-section class="q-pt-xs">
            <div class="text-h5 q-mt-sm q-mb-xs">{{ acc.name }}</div>
            <div class="text-caption text-grey">{{ acc.balance.toFixed(2) }} UAH</div>
          </q-card-section>
        </q-card-section>
      </q-card>
    </div>
  </div>
</template>

<script setup lang="ts">
import { useRouter } from 'vue-router';
import { useAccounts } from '@/composables';

const router = useRouter();
const { accounts } = useAccounts();

const clickHandler = (accountId: number) => {
  router.push(`/account/${accountId}`);
};
</script>

<style scoped sass>
.my-card {
  margin-top: 20px;
  width: 100%;
  max-width: 350px;
}
</style>
