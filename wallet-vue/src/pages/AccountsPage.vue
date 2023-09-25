<template>
  <div class="row justify-end">
    <q-btn icon="add" color="primary" label="Add" @click="openDialog" />
  </div>
  <q-dialog v-model="isDialogOpen" persistent>
    <q-card style="width: 100%; max-width: 475px">
      <q-toolbar>
        <q-avatar icon="account_balance"> </q-avatar>

        <q-toolbar-title>Create Account</q-toolbar-title>

        <q-btn flat round dense icon="close" v-close-popup />
      </q-toolbar>
      <q-card-section>
        <q-form class="q-gutter-md">
          <q-input filled v-model="newAccountModel.name" label="Name" />

          <q-input filled v-model="newAccountModel.initialBalance" label="Initial Balance" />
        </q-form>
      </q-card-section>
      <q-separator />

      <q-card-actions align="right">
        <q-btn color="primary" flat label="Cancel" @click="closeDialog" />
        <q-btn color="primary" label="Create" @click="createAccountHanlder" />
      </q-card-actions>
    </q-card>
  </q-dialog>
  <div class="row" style="margin-left: -20px; margin-right: -20px">
    <div
      class="col-12 col-md-4 q-py-md"
      style="padding-left: 20px; padding-right: 20px"
      v-for="acc in accounts"
      v-bind:key="acc.id"
      @click="() => clickHandler(acc.id)"
    >
      <q-card class="my-card cursor-pointer">
        <q-card-section horizontal>
          <q-card-section class="q-pt-xs col">
            <div class="text-h5 q-mt-sm q-mb-xs">{{ acc.name }}</div>
            <div class="text-caption text-grey">{{ acc.balance.toFixed(2) }} UAH</div>
          </q-card-section>
          <q-card-actions vertical align="right">
            <q-btn color="grey" round flat dense icon="more_vert" @click.stop>

              <q-menu anchor="bottom left" :offset="[96,-5]">
              <q-list dense>
                <q-item clickable v-close-popup>
                  <q-item-section side>
                      <q-icon name="edit"/>
                  </q-item-section>
                  <q-item-section>Edit</q-item-section>
                </q-item>
                <q-item clickable v-close-popup @click="()=>deleteHandler(acc.id)">
                  <q-item-section side>
                      <q-icon name="delete"/>
                  </q-item-section>
                  <q-item-section>Delete</q-item-section>
                </q-item>
              </q-list>
            </q-menu>

            </q-btn>
          </q-card-actions>
        </q-card-section>
      </q-card>
    </div>
  </div>
</template>

<script setup lang="ts">
import { useRouter } from 'vue-router';
import { useAccounts } from '@/composables';
import { reactive, Ref, ref } from 'vue';

const router = useRouter();
const { accounts, load: loadAccounts, createAccount, deleteAccount } = useAccounts();

const isDialogOpen: Ref<boolean> = ref<boolean>(false);
const newAccountModel = reactive({ name: '', initialBalance: '' });
const resetNewAccountModel = () => {
  newAccountModel.initialBalance = '';
  newAccountModel.name = '';
};

const openDialog = () => {
  isDialogOpen.value = true;
};

const closeDialog = () => {
  isDialogOpen.value = false;
};

const clickHandler = (accountId: number) => {
  router.push(`/account/${accountId}`);
};

const createAccountHanlder = async () => {
  // TODO: Validation
  await createAccount({
    name: newAccountModel.name,
    initialBalance: parseFloat(newAccountModel.initialBalance)
  });
  await loadAccounts();
  closeDialog();
  resetNewAccountModel();
};

const deleteHandler = async (accountId: number): Promise<void> => {
  await deleteAccount(accountId);
  await loadAccounts();
}

</script>

<style scoped sass>
.my-card {
  /* max-width: 350px; */
  width: 100%;
}
</style>
