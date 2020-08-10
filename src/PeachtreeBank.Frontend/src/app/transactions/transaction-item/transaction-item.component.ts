import { Component, OnInit, Input, ElementRef } from '@angular/core';
import { Transaction } from '../types/transaction';

@Component({
  selector: 'app-transaction-item',
  templateUrl: './transaction-item.component.html',
  styleUrls: ['./transaction-item.component.css']
})
export class TransactionItemComponent implements OnInit {

  @Input()
  public transaction: Transaction;

  constructor(public elementRef: ElementRef) { }

  ngOnInit(): void {
    this.elementRef.nativeElement.style.setProperty('--border-color', this.transaction.categoryCode);
  }
}
