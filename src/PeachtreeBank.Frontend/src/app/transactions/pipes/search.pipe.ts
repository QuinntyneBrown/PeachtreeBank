import { Pipe, PipeTransform } from '@angular/core';
import { Transaction } from '../types/transaction';

@Pipe({
  name: 'search'
})
export class SearchPipe implements PipeTransform {

  transform(value: Transaction[], searchInput: string): unknown {

    if (searchInput) {
      return value.filter(x => x.merchant.toLocaleLowerCase().indexOf(searchInput.toLocaleLowerCase()) > -1);
    }

    return value;
  }

}
