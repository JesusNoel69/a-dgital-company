import { NgOptimizedImage } from '@angular/common';
import { Component } from '@angular/core';
import { AuthRequest } from '../../../../core/models/AuthRequest';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { AuthResponse } from '../../../../core/models/AuthResponse';
import { AuthService } from '../../../../core/services/auth.service';

@Component({
  selector: 'user-login',
  imports: [NgOptimizedImage, ReactiveFormsModule],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {
  loginForm: FormGroup;
  private loginResponse!: AuthResponse;
  constructor(
    private readonly fb: FormBuilder,
    private readonly authService: AuthService,
  ) {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
    });
  }

  public onSubmit(): void {
    if (this.loginForm.invalid) {
      this.loginForm.markAllAsTouched();
      return;
    }
    const request = new AuthRequest(
      this.loginForm.controls['email'].value,
      this.loginForm.controls['password'].value,
    );

    this.authService.login(request).subscribe({
      next: (response) => {
        this.loginResponse = response;
        localStorage.setItem('token', response.token);
        localStorage.setItem('refreshToken', response.refreshToken);
        localStorage.setItem('userLoggedId', this.loginResponse.id);
        console.log(this.loginResponse);
      },
      error: (error) => {
        console.error(error);
      },
    });
  }
}
