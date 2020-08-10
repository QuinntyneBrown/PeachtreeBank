import { Injectable, Inject } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { data } from './data';
import { Transaction } from '../types/transaction';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { baseUrl } from 'src/app/core/constants';

@Injectable({
  providedIn: 'root'
})
export class TransactionService {
  constructor(
    @Inject(baseUrl) private _baseUrl: string,
    private httpClient: HttpClient) { }

  public get(): Observable<Transaction[]>{
    return this.httpClient.get<{ transactions: Transaction[]}>(`${this._baseUrl}api/transactions`).pipe(
      map(x => x.transactions)
    );
  }

  public getById(options: { transactionId: string }): Observable<Transaction>{
    return this.httpClient.get<{ transaction: Transaction}>(`${this._baseUrl}api/transactions/${options.transactionId}`).pipe(
      map(x => x.transaction)
    );
  }

  public remove(options: { transactionId: string }): Observable<Transaction[]>{
    return this.httpClient.delete<{ transactions: Transaction[]}>(`${this._baseUrl}api/transactions/${options.transactionId}`).pipe(
      map(x => x.transactions)
    );
  }

  public upsert(options: { transaction: Transaction }): Observable<Transaction>{
    return this.httpClient.post<{ transaction: Transaction}>(`${this._baseUrl}api/transactions/`, options).pipe(
      map(x => x.transaction)
    );
  }
}
