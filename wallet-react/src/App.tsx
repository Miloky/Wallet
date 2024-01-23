import React, { useEffect, useState } from 'react';
import logo from './logo.svg';
import './App.css';
import walletApiClient, { Account } from './services/wallet-api-service';
import Header from './components/header';
import Container from '@mui/material/Container';
import AccountCard from './components/Card';
import Grid from '@mui/material/Grid';

interface State {
  loading: boolean,
  accounts: Account[]
}

function App() {

  const [accounts, setAccounts] = useState<State>({
    loading: false,
    accounts: []
  });

  useEffect(() => {
    setAccounts({
      loading: true,
      accounts: []
    });
    walletApiClient.getAllAccounts().then((accounts) => {
      setAccounts({
        loading: false,
        accounts: accounts
      })
    });
  }, []);

  const clickHandler = (accountId: number) => {
    console.log('click');
  }

  return (
    <>
      <Container>
        <Grid container>
          {!accounts.loading && accounts.accounts.map((account) => <Grid style={{ cursor: 'pointer' }} key={account.id} item xs={6} onClick={() => clickHandler(account.id)}>
            <AccountCard accountName={account.name} />
          </Grid>)}
        </Grid>
      </Container>
    </>
  );
}

export default App;
