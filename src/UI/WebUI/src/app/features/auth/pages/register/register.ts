import { NgOptimizedImage } from '@angular/common';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { AuthService } from '../../../../core/services/auth.service';
import { RegisterResponse } from '../../../../core/models/RegisterResponse';
import { RegisterRequest } from '../../../../core/models/RegisterRequest';

@Component({
  selector: 'user-register',
  imports: [NgOptimizedImage, ReactiveFormsModule],
  templateUrl: './register.html',
  styleUrl: './register.css',
})
export class Register {
  registerForm: FormGroup;
  private registerResponse!: RegisterResponse;
  constructor(
    private readonly fb: FormBuilder,
    private readonly authService: AuthService,
  ) {
    this.registerForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
      passwordConfirm: ['', Validators.required],
    });
  }
  onSubmit() {
    console.log(1);
    if (this.registerForm.invalid) {
      console.log('invalid');
      return;
    }
    if (
      this.registerForm.controls['password'].value !==
      this.registerForm.controls['passwordConfirm'].value
    ) {
      console.log('password and its confirmation are different');
      return;
    }
    const userName = `${this.registerForm.controls['firstName'].value} ${this.registerForm.controls['lastName'].value}`;
    const request = new RegisterRequest(
      this.registerForm.controls['email'].value,
      userName,
      this.registerForm.controls['firstName'].value,
      this.registerForm.controls['lastName'].value,
      this.registerForm.controls['password'].value,
    );
    console.log('req: ', request);
    this.authService.registration(request).subscribe({
      next: (response) => {
        this.registerResponse = response;
        console.log(this.registerResponse);
      },
      error: (error) => {
        console.error(error);
      },
    });
  }
}
