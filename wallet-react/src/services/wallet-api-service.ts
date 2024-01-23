import axios from 'axios';


const host: string = 'https://localhost:7050';

class WalletApiClient {
    public getAllAccounts(): Promise<Account[]> {
        return axios.get(`${host}/api/accounts`).then(response => response.data);
    }
}

const walletApiClient = new WalletApiClient();
export default walletApiClient;


export interface Account {
    id: number;
    name: string;
    balance: number;
}
