import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthRequest } from '../models/AuthRequest';
import { AuthResponse } from '../models/AuthResponse';
import { Observable } from 'rxjs/internal/Observable';
import { URL } from '../constants/api';
import { Employee } from '../models/Employee';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private readonly urlLogin = URL + 'api/Auth/login';

  constructor(private readonly client: HttpClient) {}
  public login(request: AuthRequest): Observable<AuthResponse> {
    return this.client.post<AuthResponse>(this.urlLogin, request);
  }
  public logout() {}
  public getToken() {}
  public getCurrentUserId(): number {
    //ToDO: this is temporal, while routes and JWt are not completely implemented
    const userId = localStorage.getItem('userLoggedId');
    return Number(userId) || 1;
  }
  public isAuthenticated() {}
  public refreshToken() {}
}
