import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RetailcalculationComponent } from './retailcalculation.component';

describe('RetailcalculationComponent', () => {
  let component: RetailcalculationComponent;
  let fixture: ComponentFixture<RetailcalculationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RetailcalculationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RetailcalculationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
