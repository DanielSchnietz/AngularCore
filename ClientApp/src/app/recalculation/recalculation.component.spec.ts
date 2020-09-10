import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RecalculationComponent } from './recalculation.component';

describe('RecalculationComponent', () => {
  let component: RecalculationComponent;
  let fixture: ComponentFixture<RecalculationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RecalculationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RecalculationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
