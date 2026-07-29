import { Component } from '@angular/core';
import { EmployeeFilters } from '../../components/employee-filters/employee-filters';
import { EmployeeTable } from '../../components/employee-table/employee-table';
import { EmployeePagination } from '../../components/employee-pagination/employee-pagination';

@Component({
  selector: 'employees-page',
  imports: [EmployeeFilters, EmployeeTable, EmployeePagination],
  templateUrl: './employees-page.html',
  styleUrl: './employees-page.css',
})
export class EmployeesPage {}
