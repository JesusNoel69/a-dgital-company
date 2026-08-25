import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeesDetailsModal } from './employees-details-modal';

describe('EmployeesDetailsModal', () => {
  let component: EmployeesDetailsModal;
  let fixture: ComponentFixture<EmployeesDetailsModal>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EmployeesDetailsModal],
    }).compileComponents();

    fixture = TestBed.createComponent(EmployeesDetailsModal);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
