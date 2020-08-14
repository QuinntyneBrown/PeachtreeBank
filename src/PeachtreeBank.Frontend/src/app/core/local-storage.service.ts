import { Injectable } from '@angular/core';
import { storageKey } from './constants';

@Injectable({
  providedIn: 'root'
})
export class LocalStorageService {
  private _items?: any[] | null = null;

  public get items(): any[] | null | undefined {
    if (this._items === null) {
      let storageItems = localStorage.getItem(storageKey);
      if (storageItems === 'null') {
        storageItems = null;
      }
      this._items = JSON.parse(storageItems || '[]');
    }
    return this._items;
  }

  public set items(value: any[] | null | undefined) {
    this._items = value;
  }

  public get = (options: { name: string }) => {
    let storageItem = null;
    for (const item of this.items) {
      if (options.name === item.name) { storageItem = item.value; }
    }
    return storageItem;
  }

  public put = (options: { name: string; value: any }) => {
    let itemExists = false;

    this.items.forEach((item: any) => {
      if (options.name === item.name) {
        itemExists = true;
        item.value = options.value;
      }
    });

    if (!itemExists) {
      let items = this.items;
      items.push({ name: options.name, value: options.value });
      this.items = items;
      items = null;
    }

    this.updateLocalStorage();
  };
  public updateLocalStorage(): void {
    localStorage.setItem(storageKey, JSON.stringify(this._items));
  }
}
