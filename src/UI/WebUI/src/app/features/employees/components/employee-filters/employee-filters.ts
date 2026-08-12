import { Component } from '@angular/core';
import { EmployeeService } from '../../../../core/services/employee.service';
import { Employee } from '../../../../core/models/Employee';

@Component({
  selector: 'employee-filters',
  imports: [],
  templateUrl: './employee-filters.html',
  styleUrl: './employee-filters.css',
})
export class EmployeeFilters {
  sortField: keyof Employee | null = null;
  sortDirection: 'asc' | 'desc' = 'asc';
  query: string = '';

  constructor(private employeeService: EmployeeService) {}

  search() {
    console.log(this.query);
  }

  changeSort(field: keyof Employee): void {
    if (this.sortField === field) {
      this.sortDirection = this.sortDirection === 'asc' ? 'desc' : 'asc';
    } else {
      this.sortField = field;
      this.sortDirection = 'asc';
    }

    this.employeeService.setSort({
      field: field,
      direction: this.sortDirection,
    });
  }
}
