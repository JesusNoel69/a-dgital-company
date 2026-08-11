import { Component, OnInit, signal } from '@angular/core';
import { EmployeeRow } from '../employee-row/employee-row';
import { Employee } from '../../../../core/models/Employee';
import { EmployeeService } from '../../../../core/services/employee.service';

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

  changeRowColor(): boolean {
    this.rowColor = !this.rowColor;
    return this.rowColor;
  }

  constructor(private employeeService: EmployeeService) {}
  ngOnInit(): void {
    this.loadEmployees();

    this.employeeService.employeeCreated$.subscribe(() => {
      this.loadEmployees();
    });
  }

  loadEmployees(): void {
    this.employeeService.getAll().subscribe({
      next: (response) => {
        this.employees.set(response);
      },
      error: (error) => {
        console.log(error);
      },
    });
  }
}
