import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TransferConfirmationOverlayComponent } from './transfer-confirmation-overlay.component';

describe('TransferConfirmationOverlayComponent', () => {
  let component: TransferConfirmationOverlayComponent;
  let fixture: ComponentFixture<TransferConfirmationOverlayComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TransferConfirmationOverlayComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TransferConfirmationOverlayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
