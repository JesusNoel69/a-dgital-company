import { Component, OnInit, signal } from '@angular/core';
import { EmployeeRow } from '../employee-row/employee-row';
import { Employee } from '../../../../core/models/Employee';
import { EmployeeService } from '../../../../core/services/employee.service';
import { PaginationState } from '../../../../core/interfaces/PaginationState';

@Component({
  selector: 'employee-table',
  standalone: true,
  imports: [EmployeeRow],
  templateUrl: './employee-table.html',
  styleUrl: './employee-table.css',
})
export class EmployeeTable implements OnInit {
  employees = signal<Employee[]>([]);
  rowColor: boolean = false;
  private currentPagination: PaginationState = {
    start: 1,
    end: 20,
  };
  changeRowColor(): boolean {
    this.rowColor = !this.rowColor;
    return this.rowColor;
  }

  constructor(private employeeService: EmployeeService) {}
  ngOnInit(): void {
    this.employeeService.pagination$.subscribe((pagination) => {
      this.currentPagination = pagination;

      this.loadEmployees(pagination.start, pagination.end);
    });

    this.employeeService.employeeCreated$.subscribe(() => {
      this.loadEmployees(this.currentPagination.start, this.currentPagination.end);
    });
  }
  loadEmployees(start: number, end: number): void {
    //loadEmployees(start?: number, end?: number): void {
    /*this.employeeService.getAll().subscribe({
      next: (response) => {
        this.employees.set(response);
      },
      error: (error) => {
        console.log(error);
      },
    });*/
    this.employeeService.getByRange(start, end).subscribe({
      next: (response) => {
        this.employees.set(response);
      },
      error: (error) => {
        console.log(error);
      },
    });
  }
}
