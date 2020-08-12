import { Component, OnDestroy } from '@angular/core';
import { TransactionService } from '../services/transaction.service';
import { Subject, merge } from 'rxjs';
import { Transaction } from '../types/transaction';
import { tap, takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-transactions',
  templateUrl: './transactions.component.html',
  styleUrls: ['./transactions.component.css']
})
export class TransactionsComponent implements OnDestroy {

  private internalTransactions$: Subject<Transaction[]> = new Subject();

  transactions$ = merge(this.transactionService.transactions$, this.internalTransactions$);

  private onDestroy$: Subject<any> = new Subject();
  constructor(
    public transactionService: TransactionService
  ) { }

  ngOnDestroy(): void {
    this.onDestroy$.next();
  }

  onTransactionCreated(): void {
    this.transactionService.transactions$.pipe(
      takeUntil(this.onDestroy$),
      tap(x => this.internalTransactions$.next(x))
    ).subscribe();
  }
}
