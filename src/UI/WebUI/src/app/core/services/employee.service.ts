import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { Employee } from '../models/Employee';
import { URL } from '../constants/api';
import { CreateUserRequest } from '../models/CreateUserRequest';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService {
  constructor(private readonly client: HttpClient) {}

  getById(id: number): Observable<Employee> {
    return this.client.get<Employee>(`${URL}api/Employees/${id}`);
  }

  getAll(): Observable<Employee[]> {
    return this.client.get<Employee[]>(`${URL}api/Employees`);
  }

  addEmployee(employee: CreateUserRequest): Observable<number> {
    return this.client.post<number>(`${URL}api/Employees`, employee);
  }

  private employeeCreatedSubject = new Subject<number>();

  employeeCreated$ = this.employeeCreatedSubject.asObservable();

  notifyEmployeeCreated(id: number): void {
    this.employeeCreatedSubject.next(id);
  }

  getCurrentEmployee() {}
  updateProfile() {}
}
