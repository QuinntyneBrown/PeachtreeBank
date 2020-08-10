import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MakeATransferComponent } from './make-a-transfer.component';

describe('MakeATransferComponent', () => {
  let component: MakeATransferComponent;
  let fixture: ComponentFixture<MakeATransferComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MakeATransferComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MakeATransferComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
