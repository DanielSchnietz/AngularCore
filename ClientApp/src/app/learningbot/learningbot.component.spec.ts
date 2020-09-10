import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LearningbotComponent } from './learningbot.component';

describe('LearningbotComponent', () => {
  let component: LearningbotComponent;
  let fixture: ComponentFixture<LearningbotComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LearningbotComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LearningbotComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
