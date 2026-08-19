import { HttpClient } from '@angular/common/http';
import { Injectable, signal } from '@angular/core';
import { BehaviorSubject, Observable, Subject } from 'rxjs';
import { Employee } from '../models/Employee';
import { URL } from '../constants/api';
import { CreateUserRequest } from '../models/CreateUserRequest';
import { PaginationState } from '../interfaces/PaginationState';
import { EmployeeSort } from '../interfaces/EmployeeSort';

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

  getByRange(start: number, end: number): void {
    this.client.get<Employee[]>(`${URL}api/Employees/range?start=${start}&end=${end}`).subscribe({
      next: (employees) => {
        this.employeesSubject.next(employees);
      },
      error: (error) => {
        console.error(error);
      },
    });
  }

  /*getByField(field: string): Observable<Employee[]> {
    return this.client.get<Employee[]>(`${URL}api/Employees/field?field=${field}`);
  }*/

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

  private sortSubject = new BehaviorSubject<EmployeeSort | null>(null);

  sort$ = this.sortSubject.asObservable();

  setSort(sort: EmployeeSort): void {
    this.sortSubject.next(sort);
  }
  searchQuery = signal('');
  private employeesSubject = new BehaviorSubject<Employee[]>([]);
  employees$ = this.employeesSubject.asObservable();
  getByField(query: string): void {
    this.client.get<Employee[]>(`${URL}api/Employees/field?field=${query}`).subscribe({
      next: (employees) => {
        this.employeesSubject.next(employees);
      },
      error: (error) => {
        console.error(error);
      },
    });
  }
  setSearchQuery(query: string): void {
    this.searchQuery.set(query);
  }
  deleteEmployee(id: number): Observable<boolean> {
    return this.client.delete<boolean>(`${URL}api/Employees/${id}`);
  }
  getCurrentEmployee() {}
  updateProfile() {}
}
