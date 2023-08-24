<template>
  <div v-if="authGuardState.loading">loading...</div>
  <q-layout
    v-if="authGuardState.authenticated"
    view="lHh Lpr lff"
    container
    :style="{ height: `${height}px` }"
  >
    <q-header elevated>
      <q-toolbar>
        <q-toolbar-title class="non-selectable cursor-pointer" @click="navigateHome"
          >Wallet</q-toolbar-title
        >
      </q-toolbar>
    </q-header>

    <q-drawer show-if-above :width="200" :breakpoint="400">
      <q-scroll-area
        style="height: calc(100% - 150px); margin-top: 150px; border-right: 1px solid #ddd"
      >
        <SideMenu />
      </q-scroll-area>

      <q-img
        class="absolute-top"
        src="https://cdn.quasar.dev/img/material.png"
        style="height: 150px"
      >
        <div class="absolute-bottom bg-transparent">
          <q-avatar size="56px" class="q-mb-sm">
            <img src="https://cdn.quasar.dev/img/boy-avatar.png" />
          </q-avatar>
          <div class="text-weight-bold">{{ userName }}</div>
          <div>Time To Logout: {{ timeToLogout }} minutes</div>
        </div>
      </q-img>
    </q-drawer>

    <q-page-container>
      <q-page padding>
        <RouterView />
      </q-page>
    </q-page-container>
  </q-layout>
</template>

<script setup lang="ts">
import { onBeforeMount, onMounted, ref, watch } from 'vue';
import { RouterView, useRouter } from 'vue-router';
import { debounce } from 'quasar';
import { mgr } from '@/router/auth-service';
import { useAuthGuard } from '@/composables';
import SideMenu from '@/components/SideMenu.vue';
const { push } = useRouter();

const { state: authGuardState } = useAuthGuard();

const height = ref<number>(window.innerHeight);
const userName = ref<string>();
const userValue = ref();
const timeToLogout = ref<number>(0);

const resizeHandler = debounce(() => {
  height.value = window.innerHeight;
}, 200);


const navigateHome = (): void => {
  push('/');
};


const countDownTimer = () => {
  timeToLogout.value = Math.round(userValue.value.expires_in / 60);
  setTimeout(() => {
    countDownTimer();
  }, 60000);
};

watch(userValue, () => {
  if (userValue.value) {
    countDownTimer();
  }
});

onMounted(async () => {
  const user = await mgr.getUser();
  userValue.value = user;
  userName.value = user?.profile.name;
});

onBeforeMount(async () => {
  // TODO: Remove resize handler on component unmount
  window.addEventListener('resize', resizeHandler);
});
</script>
