import { Component } from '@angular/core';
import { TransactionService } from '../services/transaction.service';
import { Subject, merge } from 'rxjs';
import { Transaction } from '../types/transaction';

@Component({
  selector: 'app-transactions',
  templateUrl: './transactions.component.html',
  styleUrls: ['./transactions.component.css']
})
export class TransactionsComponent {

  private internalTransactions$: Subject<Transaction[]> = new Subject();

  transactions$ = merge(this.transactionService.transactions$, this.internalTransactions$);

  constructor(
    public transactionService: TransactionService
  ) { }

}
