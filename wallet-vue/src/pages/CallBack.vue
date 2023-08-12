<template>
  <div></div>
</template>

<script lang="ts" setup>
import { onBeforeMount } from 'vue';
import { useRouter } from 'vue-router';
import { mgr } from '@/router/auth-service';

const { push } = useRouter();

onBeforeMount(async () => {
  try {
    var result = await mgr.signinRedirectCallback();
    var returnToUrl = '/';
    if (result.state !== undefined) {
      returnToUrl = result.state;
    }
    push({ path: returnToUrl });
  } catch (e) {
    push({ name: 'Unauthorized' });
  }
});
</script>
