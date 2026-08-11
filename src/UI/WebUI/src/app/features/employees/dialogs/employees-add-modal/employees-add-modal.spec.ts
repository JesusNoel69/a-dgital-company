import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeesAddModal } from './employees-add-modal';

describe('EmployeesAddModal', () => {
  let component: EmployeesAddModal;
  let fixture: ComponentFixture<EmployeesAddModal>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EmployeesAddModal],
    }).compileComponents();

    fixture = TestBed.createComponent(EmployeesAddModal);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
