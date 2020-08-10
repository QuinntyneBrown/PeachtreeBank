import { Component, EventEmitter, Output, Input, ElementRef } from '@angular/core';

@Component({
  selector: 'app-sort-by',
  templateUrl: './sort-by.component.html',
  styleUrls: ['./sort-by.component.css']
})
export class SortByComponent {

  @Input()
  public sortAscending = true;

  @Input()
  public sortBy: SortBy = null;

  @Output()
  public sort: EventEmitter<any> = new EventEmitter();

  constructor(public elementRef: ElementRef) { }

  public onClick(field: SortBy): void {
    if (this.sortBy && this.sortBy === field) {
      this.sortAscending = !this.sortAscending;
    }

    this.sortBy = field;

    this.sort.emit({
      field, sortAscending: this.sortAscending
    });

    this.updateSortOptionCaptions(this.sortBy,this.sortAscending);
  }

  get dateElement(): HTMLElement {
    return this.elementRef.nativeElement.querySelector('span:nth-child(2) ') as HTMLElement;
  }

  get beneficiaryElement(): HTMLElement {
    return this.elementRef.nativeElement.querySelector('span:nth-child(3) ') as HTMLElement;
  }

  get amountElement(): HTMLElement {
    return this.elementRef.nativeElement.querySelector('span:nth-child(4) ') as HTMLElement;
  }

  resolveArrowIcon(sortAscending: boolean) {
    return sortAscending ? '<i class="arrow up"></i>' : '<i class="arrow down"></i>';
  }

  updateSortOptionCaptions(sortBy: string, sortAscending: boolean) {
    this.dateElement.innerHTML = 'DATE';
    this.beneficiaryElement.innerHTML = 'BENEFICIARY';
    this.amountElement.innerHTML = 'AMOUNT';

    if (sortBy === 'Date') {
      this.dateElement.innerHTML = `DATE ${this.resolveArrowIcon(sortAscending)}`;
    }

    if (sortBy === 'Beneficiary') {
      this.beneficiaryElement.innerHTML = `BENEFICIARY ${this.resolveArrowIcon(sortAscending)}`;
    }

    if (sortBy === 'Amount') {
      this.amountElement.innerHTML = `AMOUNT ${this.resolveArrowIcon(sortAscending)}`;
    }
  }
}


export type SortBy = 'Date' | 'Beneficiary' | 'Amount';
