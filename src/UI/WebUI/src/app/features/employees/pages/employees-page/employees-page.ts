import { Component, OnInit, signal } from '@angular/core';
import { EmployeeFilters } from '../../components/employee-filters/employee-filters';
import { EmployeeTable } from '../../components/employee-table/employee-table';
import { EmployeePagination } from '../../components/employee-pagination/employee-pagination';
import { EmployeesAddModal } from '../../dialogs/employees-add-modal/employees-add-modal';
import { Employee } from '../../../../core/models/Employee';
import { EmployeeService } from '../../../../core/services/employee.service';
import { EmployeesDetailsModal } from '../../dialogs/employees-details-modal/employees-details-modal';

@Component({
  selector: 'employees-page',
  imports: [
    EmployeeFilters,
    EmployeeTable,
    EmployeePagination,
    EmployeesAddModal,
    EmployeesDetailsModal,
  ],
  templateUrl: './employees-page.html',
  styleUrl: './employees-page.css',
})
export class EmployeesPage implements OnInit {
  constructor(private employeeService: EmployeeService) {}
  employees: Employee[] = [];
  public selectedEmployee: Employee | null = null;
  //public detailsModalOpen = false;

  ngOnInit() {
    this.loadEmployees();
  }
  modalOpened: boolean = false;
  detailsModalOpened: boolean = false;

  showModal(): void {
    this.modalOpened = true;
  }

  closeAddEmployeesModal(): void {
    this.modalOpened = false;
  }

  showEmployeeDetails(employee: Employee | null): void {
    this.selectedEmployee = employee;
    this.detailsModalOpened = true;
  }

  closeDetailsModal(): void {
    this.detailsModalOpened = false;
    this.selectedEmployee = null;
  }

  loadEmployees() {
    this.employeeService.getAll().subscribe({
      next: (response) => {
        this.employees = response;
      },
      error: (error) => {
        console.log(error);
      },
    });
  }
}
