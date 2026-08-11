import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { EmployeeFilters } from '../../components/employee-filters/employee-filters';
import { EmployeeTable } from '../../components/employee-table/employee-table';
import { EmployeePagination } from '../../components/employee-pagination/employee-pagination';
import { EmployeesAddModal } from '../../dialogs/employees-add-modal/employees-add-modal';
import { Employee } from '../../../../core/models/Employee';
import { EmployeeService } from '../../../../core/services/employee.service';

@Component({
  selector: 'employees-page',
  imports: [EmployeeFilters, EmployeeTable, EmployeePagination, EmployeesAddModal],
  templateUrl: './employees-page.html',
  styleUrl: './employees-page.css',
})
export class EmployeesPage implements OnInit {
  constructor(
    private cdr: ChangeDetectorRef,
    private employeeService: EmployeeService,
  ) {}
  employees: Employee[] = [];
  ngOnInit() {
    this.loadEmployees();
  }
  modalOpened: boolean = false;

  showModal(): void {
    this.modalOpened = true;
  }

  closeModal(): void {
    this.modalOpened = false;
  }
  loadEmployees() {
    this.employeeService.getAll().subscribe({
      next: (response) => {
        this.employees = response;
        //this.cdr.detectChanges();
      },
      error: (error) => {
        console.log(error);
      },
    });
  }
}
