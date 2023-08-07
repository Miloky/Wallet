import axios from 'axios';
import { onMounted, ref } from 'vue';
import { TransactionType } from '@/constants/transaction-type';

const host = 'https://localhost:7050';

interface CreateTransactionRequest {
  name: string;
  description: string;
  amount: number;
  type: TransactionType;
  accountId: number;
}

// TODO: Add types
export default function useAccountTransactions(accountId: number) {
  const loading = ref<boolean>(false);
  const transactions = ref<any[]>([]);
  const error = ref<string | null>(null);

  // TODO: Return type
  const load = async () => {
    loading.value = true;
    try {
      // TODO: Replace any
      const response = await axios.get<any[]>(`${host}/api/accounts/${accountId}/transactions`);
      transactions.value = response.data;
    } catch {
      // TODO: Add appropriate error handling
      error.value = 'Something happened wrong...';
      transactions.value = [];
    } finally {
      loading.value = false;
    }
  };

  const createTransaction = async (transaction: CreateTransactionRequest): Promise<any> => {
    const response = await axios.post(`${host}/api/transactions`, transaction);
    return response.data;
  };

  onMounted(async () => {
    await load();
  });

  return {
    load,
    loading,
    transactions,
    error,
    createTransaction
  };
}
