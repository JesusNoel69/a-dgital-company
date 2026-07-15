import { NgOptimizedImage } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AuthRequest } from '../../../../core/models/AuthRequest';
import { URL } from '../../../../core/constants/api';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { AuthResponse } from '../../../../core/models/AuthResponse';

@Component({
  selector: 'user-login',
  imports: [NgOptimizedImage, ReactiveFormsModule],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {
  private readonly urlLogin = URL + 'api/Auth/login';
  loginForm: FormGroup;
  private loginResponse!: AuthResponse;
  constructor(
    private readonly fb: FormBuilder,
    private readonly client: HttpClient,
  ) {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
    });
  }

  onSubmit(): void {
    if (this.loginForm.invalid) {
      this.loginForm.markAllAsTouched();
      return;
    }
    const body = new AuthRequest(
      this.loginForm.controls['email'].value,
      this.loginForm.controls['password'].value,
    );

    this.client.post<AuthResponse>(this.urlLogin, body).subscribe({
      next: (response) => {
        this.loginResponse = response;
        console.log(this.loginResponse);
      },
      error: (error) => {
        console.error(error);
      },
    });
  }
}
