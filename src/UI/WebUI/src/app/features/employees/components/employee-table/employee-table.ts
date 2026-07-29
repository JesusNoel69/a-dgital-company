import { Component } from '@angular/core';
import { EmployeeRow } from '../employee-row/employee-row';

@Component({
  selector: 'employee-table',
  imports: [EmployeeRow],
  templateUrl: './employee-table.html',
  styleUrl: './employee-table.css',
})
export class EmployeeTable {}
