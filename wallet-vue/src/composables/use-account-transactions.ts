import axios from 'axios';
import { onMounted, ref } from 'vue';

const host = 'https://localhost:7050';

export default function useAccountTransactions(accountId: number) {
  const loading = ref<boolean>(false);
  const transactions = ref<any[]>([]);

  const load = async () => {
    loading.value = true;
    const response = await axios.get<any[]>(`${host}/api/accounts/${accountId}/transactions`);
    transactions.value = response.data;
    loading.value = false;
    console.log(transactions);
  };

  onMounted(() => {
    load();
  });

  return {
    loading,
    transactions
  };
}
