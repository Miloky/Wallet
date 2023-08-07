import { onMounted, ref } from 'vue';
import axios from 'axios';

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
    const response = await axios.get<Account[]>(`${host}/api/accounts`);
    accounts.value = response.data;
    loading.value = false;
    console.log(accounts);
  };


  const loadAccount = async (id:number): Promise<Account> => {
    // TODO: Error handling
    const response = await axios.get<Account>(`${host}/api/accounts/${id}`);
    return response.data;
  }

  onMounted(() => {
    load();
  });

  return {
    loading,
    accounts,
    loadAccount
  };
}
