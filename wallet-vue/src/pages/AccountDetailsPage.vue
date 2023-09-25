<template>
  <div class="q-pa-md">
    <div class="q-py-md row justify-between">
      <div class="row items-center">
        <span>{{ account.name }}:</span>
        <span>UAH {{ account.balance }}</span>
      </div>
      <q-btn icon="add" color="primary" label="Add" @click="openDialog" />
    </div>

    <q-dialog v-model="isDialogOpen" persistent>
      <q-card style="width: 100%; width: 475px">
        <q-toolbar>
        <q-avatar icon="account_balance"> </q-avatar>

        <q-toolbar-title>Create Transaction</q-toolbar-title>

        <q-btn flat round dense icon="close" v-close-popup />
      </q-toolbar>
        <q-card-section>
          <q-form class="q-gutter-md">
          <q-btn-toggle
            v-model="transactionInfo.transactionType"
            spread
            no-caps
            toggle-color="purple"
            color="white"
            text-color="black"
            :options="[
              { label: 'Expense', value: 1 },
              { label: 'Income', value: 2 },
              { label: 'Transfer', value: 3 }
            ]"
          />
          <q-select
            v-model="transactionInfo.account"
            :loading="accountsLoading"
            :options="accountOptions"
            emit-value
            map-options
            label="Account"
          />
            <q-input
              filled
              v-model="transactionInfo.description"
              label="Description"
              lazy-rules
              :rules="[(val) => (val && val.length > 0) || 'Please type something']"
            />

            <q-input filled v-model.number="transactionInfo.amount" label="amount" />
          </q-form>
        </q-card-section>
        <q-card-actions align="right">
        <q-btn color="primary" flat label="Cancel" @click="closeDialog" />
        <q-btn color="primary" label="Create" @click="create" />
      </q-card-actions>
      </q-card>
      
    </q-dialog>
    <q-table
      title=""
      :rows="transactions"
      :columns="columns"
      row-key="name"
      :loading="loading"
      :hide-pagination="true"
      :pagination="{ rowsPerPage: 0 }"
    >
      <template v-slot:body-cell-amount="props">
        <q-td :props="props">
          <div>
            <span :style="getColor(props.row.type)">{{
              getAmount(props.row.amount, props.row.type)
            }}</span>
          </div>
        </q-td>
      </template>
      <template v-slot:body-cell-actions="props">
        <q-td :props="props">
          <q-btn icon="more_vert" class="more_btn">
            <q-menu anchor="bottom middle">
              <q-list dense>
                <q-item clickable v-close-popup>
                  <q-item-section side>
                      <q-icon name="edit"/>
                  </q-item-section>
                  <q-item-section>Edit</q-item-section>
                </q-item>
                <q-item clickable @click="()=>handleDelete(props.row.id)" v-close-popup>
                  <q-item-section side>
                      <q-icon name="delete"/>
                  </q-item-section>
                  <q-item-section>Delete</q-item-section>
                </q-item>
              </q-list>
            </q-menu>
          </q-btn>
        </q-td>
      </template>
      <template v-slot:no-data>
        <div style="text-align: center; width: 100%" v-if="!loading && error">{{ error }}</div>
        <div
          style="text-align: center; width: 100%"
          v-if="!loading && !error && transactions.length === 0"
        >
          Nothing to show!
        </div>
      </template>
    </q-table>
  </div>
</template>

<script setup lang="ts">
import useAccountTransactions from '@/composables/use-account-transactions';
import useAccounts from '@/composables/use-accounts';
import { computed, onMounted, reactive, ref } from 'vue';
import { useRoute } from 'vue-router';
import { TransactionType } from '@/constants/transaction-type';

const isDialogOpen = ref<boolean>(false);
const account = reactive<any>({ name: '', balance: null });
const route = useRoute();

const closeDialog = (): void => {
  isDialogOpen.value = false;
};

const openDialog = (): void => {
  isDialogOpen.value = true;
};

const creatingTransaction = ref<boolean>(false);

interface TransactionInfo {
  transactionType: TransactionType;
  amount: number;
  description: string;
  account: number;
}

const transactionInfo = reactive<TransactionInfo>({
  transactionType: 1,
  account: parseInt(route.params.id),
  amount: 0,
  description: ''
});

const { loading: accountsLoading, accounts, loadAccount } = useAccounts();
const {
  transactions,
  loading,
  error,
  createTransaction,
  load: loadTransactions,
  deleteTransaction
} = useAccountTransactions(route.params.id as unknown as number);

const accountOptions = computed(() =>
  accounts.value.map((acc) => ({ value: acc.id, label: acc.name }))
);

const getColor = (type: number) => {
  switch (type) {
    case TransactionType.Expanse:
      return 'color:red';
    default:
      return 'color:black';
  }
};

const getAmount = (amount: number, type: TransactionType) => {
  const formattedAmount = amount.toFixed(2);
  switch (type) {
    case TransactionType.Expanse:
      return `-UAH ${formattedAmount}`;
    default:
      return `UAH ${formattedAmount}`;
  }
};

const columns = [
  {
    name: 'description',
    label: 'Description',
    align: 'left',
    field: 'description'
  },
  {
    name: 'amount',
    align: 'center',
    label: 'Amount',
    field: 'amount',
    format: (val: any) => `${val}`
  },
  {
    name: 'actions',
    label: 'Actions'
  }
];

const create = async (): Promise<void> => {
  creatingTransaction.value = true;
  // TODO: Error handling
  await createTransaction({
    accountId: transactionInfo.account,
    amount: transactionInfo.amount,
    description: transactionInfo.description,
    name: 'Some name',
    type: transactionInfo.transactionType
  });
  await loadAccountInternal();
  await loadTransactions();
  creatingTransaction.value = false;
  closeDialog();
};

const loadAccountInternal = async (): Promise<void> => {
  const acc = await loadAccount(route.params.id as unknown as number);
  account.name = acc.name;
  account.balance = acc.balance;
};


const handleDelete = async (id: number): Promise<void> => {
  await deleteTransaction(id);
  await loadAccountInternal();
}

onMounted(async () => {
  await loadAccountInternal();
});
</script>

<style lang="scss">
.more_btn {
  padding: 0;
  &::before,
  &:active::before {
    box-shadow: none !important;
  }

  * {
    background: transparent;
  }
}
</style>
