import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Transaction } from '../types/transaction';
import { defaultMerchantLogo, accountBalanceKey, defaultCategoryCode } from '../../core/constants';
import { LocalStorageService } from '../../core/local-storage.service';
import { CurrencyPipe } from '@angular/common';
import { minimumBalance } from '../validators/minimum-balance.validator';
import { TransferConfirmation } from '../transfer-confirmation-overlay/transfer-confirmation';

@Component({
  selector: 'app-make-a-transfer',
  templateUrl: './make-a-transfer.component.html',
  styleUrls: ['./make-a-transfer.component.css']
})
export class MakeATransferComponent implements OnInit {

  public fromAccountPlaceholder = '';

  public form: FormGroup = new FormGroup({
    toAccount: new FormControl(null, [Validators.required]),
    amount: new FormControl(null, [Validators.required, Validators.pattern(/^\d*\.?\d*$/)]),
  },
  {
    validators: [minimumBalance(this.localStorageService)]
  });

  public get toAccount(): any { return this.form.get('toAccount'); }

  public get amount(): any { return this.form.get('amount'); }

  @Output()
  public transferCreated: EventEmitter<any> = new EventEmitter();

  constructor(
    public transferConfirmation: TransferConfirmation,
    public localStorageService: LocalStorageService,
    private currencyPipe: CurrencyPipe) { }

  ngOnInit(): void {
    this.fromAccountPlaceholder = `Free Checking(4692) ${this.currencyPipe.transform(this.accountBalance)}`;
  }

  public get accountBalance(): string { return this.localStorageService.get({ name: accountBalanceKey }); }

  public tryToSubmit(): void {
    const transaction = {} as Transaction;

    transaction.amount = this.form.value.amount;
    transaction.merchant = this.form.value.toAccount;
    transaction.transactionType = 'Transaction';
    transaction.transactionDate = Date.now();
    transaction.merchantLogo = defaultMerchantLogo;
    transaction.categoryCode = defaultCategoryCode;

    this.form.reset();

    const component = this.transferConfirmation.create({ transaction });

    component.afterClose$.pipe(

    ).subscribe(x => {
      this.transferCreated.emit();
      this.fromAccountPlaceholder = `Free Checking(4692) ${this.currencyPipe.transform(this.accountBalance)}`;
    });
  }
}