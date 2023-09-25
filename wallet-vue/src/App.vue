<template>
  <div v-if="authGuardState.loading" class="load-icon-container">
    <svg viewBox="0 0 100 100">
    <path
          class="wallet"
          d="m 49,81 c -4.119302,-0.133383 -7.114451,0.229393 -10.461024,0.236513 -3.346574,0.0071 -3.853134,0.717888 -10.684122,0.121158 -8.896148,-0.777134 -9.684309,-2.495817 -11.128959,-12.758497 -0.739191,-5.251153 -0.188781,-11.357532 -0.196435,-16.329076 -0.0077,-4.971544 0.142616,-4.268999 -0.534815,-15.501762 -0.677431,-11.232767 2.724601,-13.301977 10.031192,-13.133627 7.306591,0.16835 1.275353,0.0217 6.928763,0 5.65341,-0.0217 20.40657,-0.26322 26.99115,-0.20683 6.58458,0.0564 4.930203,0.67561 12.513138,0.31025 7.582935,-0.36536 9.134672,2.09561 9.307293,6.5151 0.172621,4.41949 -0.645835,4.05121 -0.503908,7.311335 3.651927,3.113879 1.830509,8.671976 1.90125,12.102187 4.604491,0.06646 4.663611,4.721185 4.219832,8.889884 -0.600323,5.639228 -0.354062,8.169757 -4.804832,7.892303 0.830451,11.81846 -1.363381,14.720503 -8.723541,15.097818 -7.36016,0.377315 -6.469716,0.427505 -10.599972,0.465365 -4.130256,0.03786 -10.135708,-0.878738 -14.25501,-1.012121"
          style="fill:none;fill-rule:evenodd;stroke:#0e232e;stroke-width:1.8;stroke-linecap:butt;stroke-linejoin:miter;stroke-miterlimit:4;" />
    <g>
      <path
            d="m 78.90793,36.248314 c 0.136772,-2.445285 0.354257,-4.404775 -2.150914,-4.447315 -12.41111,-0.21075 -24.566825,0.0739 -32.647713,0.034 -8.080888,-0.04 -11.970786,-0.12891 -15.627332,-0.16324 -3.656547,-0.0343 -4.902258,0.10758 -6.31904,-0.10341 -1.767686,-0.26325 -3.734807,-0.88581 -3.354878,-2.61995 0.316614,-1.44516 2.34135,-1.25497 4.451753,-1.40193 1.70421,-0.11866 1.718959,-0.19887 5.11875,-0.0731 3.399791,0.12575 9.103821,-0.0486 16.453125,0 7.349305,0.0486 22.263913,0.48059 27.641249,0.36562 2.685302,-0.34899 3.362797,-0.38618 4.581021,-0.20607 1.663644,0.24597 1.926535,2.85458 1.31625,4.56772 0.992638,1.01508 0.693457,1.73988 0.537729,4.047725 z"
            style="fill:none;fill-rule:evenodd;stroke:#0e232e;stroke-width:1.8;stroke-linecap:butt;stroke-linejoin:miter;stroke-miterlimit:4;" />
      <path
            d="m 17.200933,30.873719 c 0,0 0.07434,4.03 5.222426,4.13657 4.522694,0.0936 5.832619,-0.0831 11.530701,-0.15512 5.698083,-0.0721 10.14572,0.45794 13.598989,0.36196 6.041229,-0.16792 13.435475,-0.2661 20.217508,-0.15513 13.451079,0.22009 14.340805,2.844174 14.340805,2.844174"
            style="fill:none;fill-rule:evenodd;stroke:#0e232e;stroke-width:1.8;stroke-linecap:butt;stroke-linejoin:miter;stroke-miterlimit:4;" />
      <path
            d="m 16.605431,38.442064 1.60875,0.73125"
            style="fill:none;fill-rule:evenodd;stroke:#0e232e;stroke-width:1.8;stroke-linecap:round;stroke-linejoin:miter;stroke-miterlimit:4;" />
      <path
            d="m 22.202092,39.465814 2.291968,-0.219375"
            style="fill:none;fill-rule:evenodd;stroke:#0e232e;stroke-width:1.8;stroke-linecap:round;stroke-linejoin:miter;stroke-miterlimit:4;" />
      <path
            d="m 28.929592,39.465814 2.77084,-0.313773"
            style="fill:none;fill-rule:evenodd;stroke:#0e232e;stroke-width:1.8;stroke-linecap:round;stroke-linejoin:miter;stroke-miterlimit:4;" />
      <path
            d="m 35.691056,39.392689 2.184879,0.05171"
            style="fill:none;fill-rule:evenodd;stroke:#0e232e;stroke-width:1.8;stroke-linecap:round;stroke-linejoin:miter;stroke-miterlimit:4;" />
      <path
            d="m 42.711056,39.465814 h 2.48625"
            style="fill:none;fill-rule:evenodd;stroke:#0e232e;stroke-width:1.8;stroke-linecap:round;stroke-linejoin:miter;stroke-miterlimit:4;" />
      <path
            d="m 49.731056,39.444396 2.443414,0.14625"
            style="fill:none;fill-rule:evenodd;stroke:#0e232e;stroke-width:1.8;stroke-linecap:round;stroke-linejoin:miter;stroke-miterlimit:4;" />
      <path
            d="m 57.067171,39.405402 0.517072,-0.103414 1.551215,0.206828"
            style="fill:none;fill-rule:evenodd;stroke:#0e232e;stroke-width:1.8;stroke-linecap:round;stroke-linejoin:miter;stroke-miterlimit:4;" />
      <path
            d="m 63.478861,39.301988 0.723901,0.103414 2.481945,-0.103417"
            style="fill:none;fill-rule:evenodd;stroke:#0e232e;stroke-width:1.8;stroke-linecap:round;stroke-linejoin:miter;stroke-miterlimit:4;" />
      <path
            d="m 71.131524,39.301988 0.620487,-0.103415 2.01658,0.155122"
            style="fill:none;fill-rule:evenodd;stroke:#0e232e;stroke-width:1.8;stroke-linecap:round;stroke-linejoin:miter;stroke-miterlimit:4;" />
      <path
            d="m 77.491508,40.336131 0.568779,0.568779 0.672193,0.93073"
            style="fill:none;fill-rule:evenodd;stroke:#0e232e;stroke-width:1.8;stroke-linecap:round;stroke-linejoin:miter;stroke-miterlimit:4;" />
      <path
            d="m 78.887602,45.817093 0.155121,2.171701"
            style="fill:none;fill-rule:evenodd;stroke:#0e232e;stroke-width:1.8;stroke-linecap:round;stroke-linejoin:miter;stroke-miterlimit:4;" />
      <path
            d="m 83.533087,49.557064 c 0,0 -5.856818,0.283698 -9.609375,0.396604 -3.752557,0.112906 -8.155534,0.726474 -8.997049,8.06632 -0.841515,7.339846 5.930443,8.240479 9.152171,8.376563 3.221728,0.136084 9.033784,0.05239 9.033784,0.05239"
            style="fill:none;fill-rule:evenodd;stroke:#0e232e;stroke-width:1.8;stroke-linecap:round;stroke-linejoin:miter;stroke-miterlimit:4;" />
      <path
            d="m 72.47293,62.500189 c 2.4712,-0.140993 3.791824,-1.540065 4.24125,-4.277813 0.326567,-1.989331 -1.521923,-3.952497 -3.506481,-4.079254 -2.692693,-0.171986 -4.802746,2.420734 -4.720082,4.773942 0.07625,2.17063 2.277269,3.680577 3.985313,3.583125 z"
            style="fill:none;fill-rule:evenodd;stroke:#0e232e;stroke-width:1.8;stroke-linecap:butt;stroke-linejoin:miter;stroke-miterlimit:4;" />
      <path
            d="m 85.19668,58.917063 v -0.329062"
            style="fill:none;fill-rule:evenodd;stroke:#0e232e;stroke-width:1.8;stroke-linecap:round;stroke-linejoin:miter;stroke-miterlimit:4;" />
      <path
            d="m 85.452618,56.101751 c 0,0 -0.168059,-2.550352 -0.950625,-3.254063 -0.782566,-0.70371 -2.77875,-0.585 -2.77875,-0.585"
            style="fill:none;fill-rule:evenodd;stroke:#0e232e;stroke-width:1.8;stroke-linecap:round;stroke-linejoin:miter;stroke-miterlimit:4;" />
      <path
            d="m 51.345232,-69.280345 -0.103417,0.723901"
            style="fill:none;fill-rule:evenodd;stroke:#0e232e;stroke-width:1.8;stroke-linecap:round;stroke-linejoin:miter;stroke-miterlimit:4;" />
      <path
            d="m 79.559795,70.171176 -0.258536,1.551215"
            style="fill:none;fill-rule:evenodd;stroke:#0e232e;stroke-width:1.8;stroke-linecap:round;stroke-linejoin:miter;stroke-miterlimit:4;" />
      <path
            d="m 78.991016,75.135065 c 0,0 -0.307646,0.548749 -0.620486,0.775608 -0.31284,0.226859 -1.240972,0.465365 -1.240972,0.465365"
            style="fill:none;fill-rule:evenodd;stroke:#0e232e;stroke-width:1.8;stroke-linecap:round;stroke-linejoin:miter;stroke-miterlimit:4;" />
      <path
            d="m 74.33737,76.789695 -2.326823,0.36195"
            style="fill:none;fill-rule:evenodd;stroke:#0e232e;stroke-width:1.8;stroke-linecap:round;stroke-linejoin:miter;stroke-miterlimit:4;" />
      <path
            d="m 68.64958,77.048231 -2.895603,-0.05171"
            style="fill:none;fill-rule:evenodd;stroke:#0e232e;stroke-width:1.8;stroke-linecap:round;stroke-linejoin:miter;stroke-miterlimit:4;" />
      <path
            d="m 62.393011,76.996524 -1.240973,0.206829 -2.068287,-0.05171"
            style="fill:none;fill-rule:evenodd;stroke:#0e232e;stroke-width:1.8;stroke-linecap:round;stroke-linejoin:miter;stroke-miterlimit:4;" />
      <path
            d="m 55.61937,77.099938 -2.119995,0.05171"
            style="fill:none;fill-rule:evenodd;stroke:#0e232e;stroke-width:1.8;stroke-linecap:round;stroke-linejoin:miter;stroke-miterlimit:4;" />
      <path
            d="m 48.328657,76.841402 -1.861458,0.155122"
            style="fill:none;fill-rule:evenodd;stroke:#0e232e;stroke-width:1.8;stroke-linecap:round;stroke-linejoin:miter;stroke-miterlimit:4;" />
      <path
            d="m 41.606723,76.996524 -1.292679,0.05171 -1.344387,-0.05171"
            style="fill:none;fill-rule:evenodd;stroke:#0e232e;stroke-width:1.8;stroke-linecap:round;stroke-linejoin:miter;stroke-miterlimit:4;" />
      <path
            d="m 34.316011,77.099938 -3.30926,-0.155121"
            style="fill:none;fill-rule:evenodd;stroke:#0e232e;stroke-width:1.8;stroke-linecap:round;stroke-linejoin:miter;stroke-miterlimit:4;" />
      <path
            d="m 26.973591,77.151645 -1.706337,-0.103414"
            style="fill:none;fill-rule:evenodd;stroke:#0e232e;stroke-width:1.8;stroke-linecap:round;stroke-linejoin:miter;stroke-miterlimit:4;" />
      <path
            d="m 20.613607,76.065795 h -0.620486 l -1.344387,-0.723901"
            style="fill:none;fill-rule:evenodd;stroke:#0e232e;stroke-width:1.8;stroke-linecap:round;stroke-linejoin:miter;stroke-miterlimit:4;" />
    </g>
  </svg>
  <div class="loading">LOADING...</div>
  
  </div>
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


<style lang="scss">
svg {
  height: 200px;
  stroke-width:4;
}
// .wallet {
//   stroke-dasharray: 0 240;
//   stroke-dashoffset: 0px;
// }

.loading {
  text-align: center;
  font-weight: bold;
}

.load-icon-container {
  display: flex;
  flex-direction: column;
}

</style>

