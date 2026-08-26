import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeesEditModal } from './employees-edit-modal';

describe('EmployeesEditModal', () => {
  let component: EmployeesEditModal;
  let fixture: ComponentFixture<EmployeesEditModal>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EmployeesEditModal],
    }).compileComponents();

    fixture = TestBed.createComponent(EmployeesEditModal);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
