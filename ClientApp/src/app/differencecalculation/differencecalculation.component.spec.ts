import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DifferencecalculationComponent } from './differencecalculation.component';

describe('DifferencecalculationComponent', () => {
  let component: DifferencecalculationComponent;
  let fixture: ComponentFixture<DifferencecalculationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DifferencecalculationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DifferencecalculationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
