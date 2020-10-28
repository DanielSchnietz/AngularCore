import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { ReactiveFormsModule, FormBuilder } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSortModule } from '@angular/material/sort';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { CalculationOutputComponent } from "../calculation-output/calculation-output.component";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { CalculationComponent } from './calculation.component';
import { By } from '@angular/platform-browser';


describe('CalculationComponent', () => {
  let component: CalculationComponent;
  let fixture: ComponentFixture<CalculationComponent>;

  const fb: FormBuilder = new FormBuilder();

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [
        CalculationComponent,
        CalculationOutputComponent
      ],
      imports: [
        ReactiveFormsModule,
        MatFormFieldModule,
        MatInputModule,
        MatSortModule,
        MatButtonModule,
        MatCardModule,
        MatIconModule,
        HttpClientModule,
        BrowserAnimationsModule
      ],
      providers: [
        // reference the new instance of formBuilder from above
        { provide: FormBuilder, useValue: fb }
      ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CalculationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges()
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  

  it('should check submitButton is disabled initially', async(() => {
    let submitBtn = fixture.debugElement.query(By.css('.submitButton'))
    fixture.detectChanges();
    fixture.whenStable().then(() => {
 
      expect(submitBtn.nativeElement.disabled).toBe(true)
    })
  }));

  it('should submit data only once', async(() => {
    

    let button = fixture.debugElement.query(By.css('.formContainer'));
    spyOn(component, 'submitCalculation');
    button.triggerEventHandler('submit', null);

    fixture.whenStable().then(() => {
      expect(component.submitCalculation).toHaveBeenCalledTimes(1)
    })
  }));
});
