<template>
  <q-layout view="lHh lpr lFf" container style="height: 50px">
    <q-header elevated>
      <q-toolbar>
        <q-btn flat round dense icon="menu" class="q-mr-sm" />
        <q-avatar @click="navigateHome" class="cursor-pointer">
          <img src="https://cdn.quasar.dev/logo-v2/svg/logo-mono-white.svg" />
        </q-avatar>

        <q-toolbar-title @click="navigateHome" class="cursor-pointer">Wallet</q-toolbar-title>

        <q-btn flat round dense icon="whatshot" />
      </q-toolbar>
    </q-header>
  </q-layout>
</template>

<script setup lang="ts">
import { useRouter } from 'vue-router';

const { push } = useRouter();

const navigateHome = (): void => {
  push('/');
};
</script>
