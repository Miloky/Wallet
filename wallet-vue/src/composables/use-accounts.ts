import { onMounted, ref } from 'vue';
import axios from 'axios';
import authService from '@/router/auth-service';

const host = 'https://localhost:7050';

interface Account {
  id: number;
  name: string;
  balance: number;
}

export default function useAccounts() {
  const loading = ref<boolean>(false);
  const accounts = ref<Account[]>([]);

  const load = async () => {
    loading.value = true;
    const token = await authService.getAccessToken();
    const response = await axios.get<Account[]>(`${host}/api/accounts`, {
      headers: {
        Authorization: `Bearer ${token}`
      }
    });
    accounts.value = response.data;
    loading.value = false;
  };

  const loadAccount = async (id: number): Promise<Account> => {
    // TODO: Error handling
    const token = await authService.getAccessToken();

    const response = await axios.get<Account>(`${host}/api/accounts/${id}`, {
      headers: {
        Authorization: `Bearer ${token}`
      }
    });
    return response.data;
  };

  onMounted(() => {
    load();
  });

  return {
    loading,
    accounts,
    loadAccount
  };
}
