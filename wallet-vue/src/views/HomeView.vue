<template>
  <q-layout view="lHh lpr lFf" container style="height: 50px">
    <q-header elevated>
      <q-toolbar>
        <q-btn flat round dense icon="menu" class="q-mr-sm" />
        <q-avatar>
          <img src="https://cdn.quasar.dev/logo-v2/svg/logo-mono-white.svg" />
        </q-avatar>

        <q-toolbar-title>Wallet</q-toolbar-title>

        <q-btn flat round dense icon="whatshot" />
      </q-toolbar>
    </q-header>
  </q-layout>

  <main style="padding: 20px">
    <q-card class="my-card" flat bordered>
      <q-card-section horizontal>
        <q-card-section class="q-pt-xs">
          <div class="text-overline">Overline</div>
          <div class="text-h5 q-mt-sm q-mb-xs">Title</div>
          <div class="text-caption text-grey">
            Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor
            incididunt ut labore et dolore magna aliqua.
          </div>
        </q-card-section>

        <q-card-section class="col-5 flex flex-center">
          <q-img class="rounded-borders" src="https://cdn.quasar.dev/img/parallax2.jpg" />
        </q-card-section>
      </q-card-section>

      <q-separator />

      <q-card-actions>
        <q-btn flat round icon="event" />
        <q-btn flat> 7:30PM </q-btn>
        <q-btn flat color="primary"> Reserve </q-btn>
      </q-card-actions>
    </q-card>
  </main>
</template>

<script setup lang="ts">
import { useAccounts } from '@/composables';

const a = useAccounts();

</script>

<style scoped sass>
.my-card {
  margin-top: 20px;
  width: 100%;
  max-width: 350px;
}
</style>
