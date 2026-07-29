import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeRow } from './employee-row';

describe('EmployeeRow', () => {
  let component: EmployeeRow;
  let fixture: ComponentFixture<EmployeeRow>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EmployeeRow],
    }).compileComponents();

    fixture = TestBed.createComponent(EmployeeRow);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
