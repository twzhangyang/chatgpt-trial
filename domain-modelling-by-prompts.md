## Aggregate: LedgerAccount
- ID: A unique identifier for the LedgerAccount.
- Accounts: A collection of Account entities associated with the LedgerAccount.
- Transactions: A collection of Transaction entities associated with the LedgerAccount.

## Entities:
### Account
- AccountCode: A unique identifier for the account.
- AccountType: The type of the account (assets, liabilities, revenue, expenses, equity).
- Balance: The current balance of the account.
#### Capabilities
##### Create: This action involves creating a new account within the General Ledger.
- Business Rule: 
    - Business Rule 1: Unique Account Code
Each account within the General Ledger must have an account code with no empty GUID value.
    - Business Rule 2: Valid Account Type
The account type assigned during the creation of a new account must be a valid type as per the standard account classifications. These classifications might include assets, liabilities, revenue, expenses, and equity.
    - Business Rule 3: Initial Balance
When a new account is created, the initial balance of the account must be set to great or equal zero.
- Outcome: A new account is created in the General Ledger with a unique account code and an associated account type.
##### BalanceUpdate: This action involves updating the balance of an account in the General Ledger.
- Business Rule: The balance of an account should be updated after a transaction has been posted. The balance should always reflect the accurate state of the account.
    - Business Rule 1: Valid Transaction
Transaction Amount should great or equal to zero

    - Business Rule 2: Accurate Balance Calculation
The system should accurately calculate the new balance of an account after a transaction. This means appropriately adding or subtracting the transaction amount from the current balance, based on whether the transaction is a debit or a credit.
- Outcome: The balance of the relevant account is updated in the General Ledger.

### Transaction
- ID: A unique identifier for the transaction.
TransactionDetails: The details of the transaction (transaction type, date, debit amount, credit amount).
- AccountCode: The account code that the transaction is associated with.
#### Capabilities
##### Record: This action involves recording a new transaction in the General Ledger.
- Business Rules:
    - Business Rule 1: Transaction Integrity
Every transaction recorded in the General Ledger must have both a debit and a credit entry, maintaining the fundamental principle of double-entry accounting. This ensures that the accounting equation (Assets = Liabilities + Equity) stays balanced.

    - Business Rule 2: Valid Accounts
Each transaction must involve valid accounts in the General Ledger. Account code with no empty GUID value.

    - Business Rule 3: Accurate Transaction Amounts
The debit and credit amounts in a transaction must be equal. This is necessary to ensure the consistency and integrity of the accounting records. It's also important to verify that the transaction amount is a positive, non-zero number.
- Outcome: A new transaction is recorded in the General Ledger, associated with the relevant accounts.

### Value Objects:
#### AccountCode
- Code: A string representing the unique code of the account.

#### AccountType
- Type: A string representing the type of account (assets, liabilities, revenue, expenses, equity).

#### TransactionDetail
- TransactionType: The type of the transaction (purchase, sale, payment, receipt).
- Date: The date of the transaction.
- DebitAmount: The debit amount of the transaction.
- CreditAmount: The credit amount of the transaction.

## Events:
### AccountCreatedEvent
- AccountCode: The account code of the newly created account.
- AccountType: The type of the newly created account.

### TransactionRecordedEvent
- TransactionID: The ID of the transaction that was recorded.
- AccountCode: The account code that the transaction was associated with.

### TransactionPostedEvent
- TransactionID: The ID of the transaction that was posted.
- PostDate: The date the transaction was posted.

### AccountBalanceUpdatedEvent
- AccountCode: The account code of the account whose balance was updated.
- NewBalance: The new balance of the account.

### FinancialReportGeneratedEvent
- ReportID: The ID of the generated report.
- GenerationDate: The date the report was generated.