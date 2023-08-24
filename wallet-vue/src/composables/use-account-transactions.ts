import axios from 'axios';
import { onMounted, ref } from 'vue';
import { TransactionType } from '@/constants/transaction-type';
import authService from '@/router/auth-service';

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
  // TODO: Replace any[]
  const transactions = ref<any[]>([]);
  const error = ref<string | null>(null);

  // TODO: Return type
  const load = async () => {
    loading.value = true;
    const token = await authService.getAccessToken();
    try {
      // TODO: Replace any
      const response = await axios.get<any[]>(`${host}/api/accounts/${accountId}/transactions`, {
        headers: {
          Authorization: `Bearer ${token}`
        }
      });
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
    const token = await authService.getAccessToken();
    const response = await axios.post(`${host}/api/transactions`, transaction, {
      headers: {
        Authorization: `Bearer ${token}`
      }
    });
    return response.data;
  };

  // TODO: Add return type
  // TODO: Add exception handling
  const deleteTransaction = async (transactionId: number): Promise<any> => {
    const token = await authService.getAccessToken();
    await axios.delete(`${host}/api/transactions/${transactionId}`, {
      headers: {
        Authorization: `Bearer ${token}`
      }
    });


    transactions.value = transactions.value.filter(t=>t.id!== transactionId);

  }

  onMounted(async () => {
    await load();
  });

  return {
    load,
    loading,
    transactions,
    error,
    createTransaction,
    deleteTransaction
  };
}
