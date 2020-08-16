import { Injectable } from '@angular/core';
import { storageKey } from './constants';

@Injectable({
  providedIn: 'root'
})
export class LocalStorageService {
  // tslint:disable-next-line: variable-name
  private _items?: any[] = undefined;

  public get items(): any[] | undefined {
    if (this._items === null) {
      let storageItems = localStorage.getItem(storageKey);
      if (storageItems === 'null') {
        storageItems = null;
      }
      this._items = JSON.parse(storageItems || '[]');
    }
    return this._items;
  }

  public set items(value: any[] | undefined) {
    this._items = value;
  }

  public get = (options: { name: string }) => {
    let storageItem = null;
    if (this.items) {
      for (const item of this.items) {
        if (options.name === item.name) { storageItem = item.value; }
      }
    }
    return storageItem;
  }

  public put = (options: { name: string; value: any }) => {
    let itemExists = false;

    if (this.items) {
      this.items.forEach((item: any) => {
        if (options.name === item.name) {
          itemExists = true;
          item.value = options.value;
        }
      });
    }

    if (this.items && !itemExists) {
      let items: any[] | undefined = this.items;
      items.push({ name: options.name, value: options.value });
      this.items = items;
      items = undefined;
    }

    this.updateLocalStorage();
  }

  public updateLocalStorage(): void {
    localStorage.setItem(storageKey, JSON.stringify(this._items));
  }
}
