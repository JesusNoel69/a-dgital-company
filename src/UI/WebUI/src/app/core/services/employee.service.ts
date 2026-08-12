import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, Subject } from 'rxjs';
import { Employee } from '../models/Employee';
import { URL } from '../constants/api';
import { CreateUserRequest } from '../models/CreateUserRequest';
import { PaginationState } from '../interfaces/PaginationState';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService {
  constructor(private readonly client: HttpClient) {}
  private paginationSubject = new BehaviorSubject<PaginationState>({
    start: 1,
    end: 20,
  });

  pagination$ = this.paginationSubject.asObservable();

  setPagination(start: number, end: number): void {
    this.paginationSubject.next({
      start,
      end,
    });
  }

  getById(id: number): Observable<Employee> {
    return this.client.get<Employee>(`${URL}api/Employees/${id}`);
  }

  getAll(): Observable<Employee[]> {
    return this.client.get<Employee[]>(`${URL}api/Employees`);
  }

  getByRange(start: number, end: number): Observable<Employee[]> {
    return this.client.get<Employee[]>(`${URL}api/Employees/range?start=${start}&end=${end}`);
  }

  addEmployee(employee: CreateUserRequest): Observable<number> {
    return this.client.post<number>(`${URL}api/Employees`, employee);
  }

  private employeeCreatedSubject = new Subject<number>();

  employeeCreated$ = this.employeeCreatedSubject.asObservable();

  notifyEmployeeCreated(id: number): void {
    this.employeeCreatedSubject.next(id);
  }

  getAllEmployeesCount(): Observable<number> {
    return this.client.get<number>(`${URL}api/Employees/count`);
  }

  getCurrentEmployee() {}
  updateProfile() {}
}
