<template>
  <q-layout
    view="lHh lpr lFf"
    container
    :style="{ height: `${height}px` }"
    class="shadow-2 rounded-borders"
  >
    <q-header elevated>
      <q-toolbar>
        <WalletIcon class="cursor-pointer" @click="navigateHome" />
        <q-toolbar-title class="non-selectable cursor-pointer" @click="navigateHome">Wallet</q-toolbar-title>

        <q-btn flat round dense icon="settings" @click="settingsClickHandler" />
      </q-toolbar>
    </q-header>

    <q-page-container>
      <q-page padding>
        <RouterView />
      </q-page>
    </q-page-container>
  </q-layout>
</template>

<script setup lang="ts">
import { onBeforeMount, ref } from 'vue';
import { RouterView, useRouter } from 'vue-router';
import { debounce } from 'quasar';
import WalletIcon from '@/components/icons/WalletIcon.vue';
const { push } = useRouter();

const height = ref<number>(window.innerHeight);

const resizeHandler = debounce(() => {
  height.value = window.innerHeight;
}, 200);

const settingsClickHandler = (): void => {
  push('/settings');
};

const navigateHome = (): void => {
  push('/');
}

onBeforeMount(() => {
  window.addEventListener('resize', resizeHandler);
});
</script>
