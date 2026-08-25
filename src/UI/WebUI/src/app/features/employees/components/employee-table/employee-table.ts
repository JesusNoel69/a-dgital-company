import { Component, EventEmitter, OnInit, Output, signal } from '@angular/core';
import { EmployeeRow } from '../employee-row/employee-row';
import { Employee } from '../../../../core/models/Employee';
import { EmployeeService } from '../../../../core/services/employee.service';
import { PaginationState } from '../../../../core/interfaces/PaginationState';
import { EmployeeSort } from '../../../../core/interfaces/EmployeeSort';
import { EmployeesDetailsModal } from '../../dialogs/employees-details-modal/employees-details-modal';
@Component({
  selector: 'employee-table',
  standalone: true,
  imports: [EmployeeRow],
  templateUrl: './employee-table.html',
  styleUrl: './employee-table.css',
})
export class EmployeeTable implements OnInit {
  employees = signal<Employee[]>([]);
  openEmployeeId = signal<number | null>(null);
  rowColor: boolean = false;
  private currentPagination: PaginationState = {
    start: 1,
    end: 20,
  };
  //public selectedEmployee: Employee | null = null;
  @Output() employeeDetailsRequested = new EventEmitter<Employee>();

  constructor(private employeeService: EmployeeService) {}
  ngOnInit(): void {
    this.employeeService.employees$.subscribe((employees) => {
      this.employees.set(employees);
    });

    this.employeeService.pagination$.subscribe((pagination) => {
      this.currentPagination = pagination;

      this.loadEmployees(pagination.start, pagination.end);
    });

    this.employeeService.sort$.subscribe((sort) => {
      if (!sort) return;

      this.sortEmployees(sort);
    });

    this.employeeService.employeeCreated$.subscribe(() => {
      this.loadEmployees(this.currentPagination.start, this.currentPagination.end);
    });
  }

  loadEmployees(start: number, end: number): void {
    this.employeeService.getByRange(start, end);
  }

  onEmployeeDeleted(id: number): void {
    this.employees.update((employees) => employees.filter((employee) => employee.id !== id));
  }

  sortEmployees(sort: EmployeeSort): void {
    const sorted = [...this.employees()].sort((a, b) => {
      const valueA = a[sort.field];
      const valueB = b[sort.field];

      if (valueA == null) return 1;
      if (valueB == null) return -1;

      const comparison = String(valueA).localeCompare(String(valueB), undefined, { numeric: true });

      return sort.direction === 'asc' ? comparison : -comparison;
    });

    this.employees.set(sorted);
  }

  openEmployeeDetails(employee: Employee): void {
    this.employeeDetailsRequested.emit(employee);
  }

  openModal(id: number): void {
    this.openEmployeeId.set(id);
  }

  closeModal(): void {
    this.openEmployeeId.set(null);
  }
}
