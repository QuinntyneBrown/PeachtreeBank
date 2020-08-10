import { Pipe, PipeTransform } from '@angular/core';
import { Transaction } from '../types/transaction';

@Pipe({
  name: 'multiOrderBy'
})
export class MultiOrderByPipe implements PipeTransform {

  transform(value: Transaction[], sortOptions): unknown {

    if (sortOptions) {
      switch (sortOptions.field) {

        case 'Date': {
          value = value.sort((a, b) => {
            if (sortOptions.sortAscending) {
              return b.transactionDate - a.transactionDate;
            } else {
              return a.transactionDate - b.transactionDate;
            }
          });

          break;
        }

        case 'Beneficiary': {

          if (sortOptions.sortAscending) {
            value = value.sort((a: Transaction, b: Transaction) => {
              if ( a.merchant < b.merchant ){
                return -1;
              }
              if ( a.merchant > b.merchant ){
                return 1;
              }
              return 0;
            });
          }
          else {
            value = value.sort((a: Transaction, b: Transaction) => {
              if ( b.merchant < a.merchant ){
                return -1;
              }
              if ( b.merchant > a.merchant ){
                return 1;
              }
              return 0;
            });
          }

          break;
        }

        case 'Amount': {
          value = value.sort((a, b) => {
            if (sortOptions.sortAscending) {
              return b.transactionDate - a.transactionDate;
            } else {
              return a.transactionDate - b.transactionDate;
            }
          });

          break;
        }

      }
    }

    return value;
  }
}
