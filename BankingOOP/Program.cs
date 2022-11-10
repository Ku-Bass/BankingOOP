using BankingOOP;

Account Kuba = new Account("Kuba", 100);

Kuba.Deposit(100, "na školu");
Kuba.Deposit(9000, "výlata brigáda");
Kuba.Withdrawal(200, "platba za boty");

Kuba.PrintTransactions();