import { Employee } from '../models/Employee';

export interface EmployeeSort {
  field: keyof Employee;
  direction: 'asc' | 'desc';
}
