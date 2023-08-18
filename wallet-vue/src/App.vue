<template>
  <q-layout view="lHh Lpr lff" container :style="{ height: `${height}px` }" class="shadow-2">
    <q-header elevated>
      <q-toolbar>
        <!-- <WalletIcon class="cursor-pointer" @click="navigateHome" /> -->
        <q-toolbar-title class="non-selectable cursor-pointer" @click="navigateHome"
          >Wallet</q-toolbar-title
        >
        <q-btn flat round dense icon="settings" @click="settingsClickHandler" />
        <!-- <q-btn flat @click="drawer = !drawer" round dense icon="menu" /> -->
      </q-toolbar>
    </q-header>

    <q-drawer v-model="drawer" show-if-above :width="200" :breakpoint="400">
      <q-scroll-area
        style="height: calc(100% - 150px); margin-top: 150px; border-right: 1px solid #ddd"
      >
        <q-list padding>
          <q-item clickable v-ripple @click="() => push('/dashboard')">
            <q-item-section avatar>
              <q-icon name="space_dashboard" />
            </q-item-section>

            <q-item-section>Dashboard</q-item-section>
          </q-item>

          <q-item clickable v-ripple @click="() => push('/')">
            <q-item-section avatar>
              <q-icon name="account_balance" />
            </q-item-section>

            <q-item-section>Accounts</q-item-section>
          </q-item>

          <q-item active clickable v-ripple @click="()=>push('/transactions')">
            <q-item-section avatar>
              <q-icon name="payment" />
            </q-item-section>

            <q-item-section>Transactions</q-item-section>
          </q-item>

          <q-item clickable v-ripple>
            <q-item-section avatar>
              <q-icon name="send" />
            </q-item-section>

            <q-item-section> Send </q-item-section>
          </q-item>

          <q-item clickable v-ripple>
            <q-item-section avatar>
              <q-icon name="settings" />
            </q-item-section>

            <q-item-section>Settings</q-item-section>
          </q-item>
        </q-list>
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

  <!-- <q-layout
    view="lHh lpr lFf"
    container
    :style="{ height: `${height}px` }"
    class="shadow-2 rounded-borders"
  >
    <q-header elevated>
      <q-toolbar>
        <WalletIcon class="cursor-pointer" @click="navigateHome" />
        <q-toolbar-title class="non-selectable cursor-pointer" @click="navigateHome"
          >Wallet</q-toolbar-title
        >
        <span>Time To Logout: {{ timeToLogout }} minutes</span>
        <span style="padding-left: 10px">{{ userName }}</span>
        <q-btn flat round dense icon="settings" @click="settingsClickHandler" />
      </q-toolbar>
    </q-header>

    <q-page-container>
      <q-page padding>
        <RouterView />
      </q-page>
    </q-page-container>
  </q-layout> -->
</template>

<script setup lang="ts">
import { onBeforeMount, onMounted, ref, watch } from 'vue';
import { RouterView, useRouter } from 'vue-router';
import { debounce } from 'quasar';
import WalletIcon from '@/components/icons/WalletIcon.vue';
import { mgr } from '@/router/auth-service';
const { push } = useRouter();

const height = ref<number>(window.innerHeight);
const userName = ref<string>();
const userValue = ref();
const timeToLogout = ref<number>(0);

const resizeHandler = debounce(() => {
  height.value = window.innerHeight;
}, 200);

const settingsClickHandler = (): void => {
  push('/settings');
};

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

onBeforeMount(() => {
  // TODO: Remove resize handler on component unmount
  window.addEventListener('resize', resizeHandler);
});
</script>
