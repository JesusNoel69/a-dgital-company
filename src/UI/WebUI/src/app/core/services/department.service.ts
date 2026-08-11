import { Injectable } from '@angular/core';
import { DepartmentDto } from '../models/DepartmentDto';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { URL } from '../constants/api';

@Injectable({
  providedIn: 'root',
})
export class DepartmentService {
  constructor(private client: HttpClient) {}
  getDeparments(): Observable<DepartmentDto[]> {
    return this.client.get<DepartmentDto[]>(`${URL}api/Departments`);
  }
}
