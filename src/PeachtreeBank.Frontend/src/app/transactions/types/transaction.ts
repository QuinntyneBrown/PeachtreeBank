import { TransactionType } from './transaction-type';

export type Transaction = {
    amount: string;
    categoryCode: string;
    merchant: string;
    merchantLogo: string;
    transactionDate: number;
    transactionType: TransactionType;
};
