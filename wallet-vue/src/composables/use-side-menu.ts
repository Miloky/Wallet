// TODO: types


interface MenuItem {
  path: string;
  iconName: string;
  label: string;
}



// TODO: Return type
export default function useSideMenu() {
  const items: MenuItem[] = [
    {
      path: '/',
      iconName: 'space_dashboard',
      label: 'Dashboard'
    },
    {
      path: '/accounts',
      iconName: 'account_balance',
      label: 'Accounts'
    },
    {
      path: '/transactions',
      iconName: 'payment',
      label: 'Transactions'
    },
    {
      path: '/settings',
      iconName: 'settings',
      label: 'Settings'
    },
    {
      path: '/logout',
      iconName: 'logout',
      label: 'Logout'
    }
  ];

  return {
    items
  };
}
