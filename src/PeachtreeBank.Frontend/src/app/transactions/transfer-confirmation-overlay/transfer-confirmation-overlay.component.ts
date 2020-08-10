import { Component, OnInit, Inject } from '@angular/core';
import { OverlayRef } from '@angular/cdk/overlay';
import { Transaction } from '../types/transaction';
import { TransactionService } from '../services/transaction.service';
import { LocalStorageService } from '../../core/local-storage.service';
import { accountBalanceKey } from '../../core/constants';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-transfer-confirmation-overlay',
  templateUrl: './transfer-confirmation-overlay.component.html',
  styleUrls: ['./transfer-confirmation-overlay.component.css']
})
export class TransferConfirmationOverlayComponent {
  public afterClose$: Subject<any> = new Subject();

  public transaction: Transaction;

  constructor(
    public overlayRef: OverlayRef,
    public transactionService: TransactionService,
    public localStorageService: LocalStorageService
    ) { }

  public get accountBalance(): any {
    return this.localStorageService.get({ name: accountBalanceKey });
  }

  public close(): void {
    this.overlayRef.dispose();
    this.afterClose$.next();
  }

  public confirm(): void {
    this.transactionService.upsert({ transaction: this.transaction })
    .subscribe();
    this.localStorageService.put({ name: accountBalanceKey, value: this.accountBalance - Number.parseInt(this.transaction.amount) });
    this.close();
  }
}
