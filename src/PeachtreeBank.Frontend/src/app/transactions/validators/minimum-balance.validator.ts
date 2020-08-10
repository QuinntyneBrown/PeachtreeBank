import { LocalStorageService } from '../../core/local-storage.service';
import { ValidationErrors, ValidatorFn, AbstractControl } from '@angular/forms';
import { accountBalanceKey } from '../../core/constants';

export function minimumBalance(localSorageService: LocalStorageService): ValidatorFn {
    return (form: AbstractControl): ValidationErrors | null => {
      const balance = Number.parseInt(localSorageService.get({ name: accountBalanceKey }));
      const amount = Number.parseInt(form.value.amount);

      return  (balance - amount) <= -500 ? { minimumBalance:  true } : null;
    };
  }