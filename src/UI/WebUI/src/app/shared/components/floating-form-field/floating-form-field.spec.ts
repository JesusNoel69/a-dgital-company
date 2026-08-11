import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FloatingFormField } from './floating-form-field';

describe('FloatingFormField', () => {
  let component: FloatingFormField;
  let fixture: ComponentFixture<FloatingFormField>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FloatingFormField],
    }).compileComponents();

    fixture = TestBed.createComponent(FloatingFormField);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
