import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from '../models/Employee';
import { URL } from '../constants/api';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService {
  constructor(private readonly client: HttpClient) {}
  getById(id: number): Observable<Employee> {
    return this.client.get<Employee>(`${URL}api/Employees/${id}`);
  }
  getCurrentEmployee() {}
  updateProfile() {}
}
