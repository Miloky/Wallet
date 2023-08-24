<template>
  <q-list padding>
    <q-item
      v-for="item in items"
      v-bind:key="item.label"
      :active="route.path === item.path"
      clickable
      v-ripple
      @click="() => push(item.path)"
    >
      <q-item-section avatar>
        <q-icon :name="item.iconName" />
      </q-item-section>

      <q-item-section>{{ item.label }}</q-item-section>
    </q-item>
  </q-list>
</template>

<script setup lang="ts">
import { useSideMenu } from '@/composables';
import { useRoute, useRouter } from 'vue-router';

const route = useRoute();
const { push } = useRouter();

const { items } = useSideMenu();
</script>
