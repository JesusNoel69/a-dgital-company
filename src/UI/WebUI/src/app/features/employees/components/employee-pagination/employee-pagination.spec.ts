import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeePagination } from './employee-pagination';

describe('EmployeePagination', () => {
  let component: EmployeePagination;
  let fixture: ComponentFixture<EmployeePagination>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EmployeePagination],
    }).compileComponents();

    fixture = TestBed.createComponent(EmployeePagination);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
