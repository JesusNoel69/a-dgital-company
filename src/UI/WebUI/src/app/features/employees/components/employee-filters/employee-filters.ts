import { Component } from '@angular/core';
import { EmployeeService } from '../../../../core/services/employee.service';
import { Employee } from '../../../../core/models/Employee';
import { FormsModule, NgModel } from '@angular/forms';
import { take } from 'rxjs';

@Component({
  selector: 'employee-filters',
  imports: [FormsModule],
  templateUrl: './employee-filters.html',
  styleUrl: './employee-filters.css',
})
export class EmployeeFilters {
  sortField: keyof Employee | null = null;
  sortDirection: 'asc' | 'desc' = 'asc';
  query: string = '';

  constructor(private employeeService: EmployeeService) {}

  search(): void {
    const query = this.query.trim();

    if (!query) {
      this.clearSearch();
      return;
    }

    this.employeeService.setSearchQuery(query);
    this.employeeService.getByField(query);
  }

  clearSearch(): void {
    this.query = '';

    this.employeeService.pagination$.pipe(take(1)).subscribe((pagination) => {
      this.employeeService.getByRange(pagination.start, pagination.end);
    });
  }

  onQueryChange(query: string): void {
    if (!query.trim()) {
      this.clearSearch();
    }
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
