import { Component, OnInit, signal } from '@angular/core';
import { DatePipe, NgOptimizedImage } from '@angular/common';
import { Employee } from '../../../core/models/Employee';
import { AuthService } from '../../../core/services/auth.service';
import { EmployeeService } from '../../../core/services/employee.service';
@Component({
  selector: 'employee-badge',
  imports: [DatePipe, NgOptimizedImage],
  templateUrl: './badge.html',
  styleUrl: './badge.css',
})
export class Badge implements OnInit {
  public user = signal<Employee | null>(null);
  public changeBand = signal(false);
  public readonly ourValues = [
    'Security and Responsabilty',
    'Integrity and Transparency',
    'Quality',
    'People and Success',
    'Purpose',
  ];

  constructor(
    private readonly authService: AuthService,
    private readonly userService: EmployeeService,
  ) {}
  async ngOnInit() {
    const id = this.authService.getCurrentUserId();
    console.log('es' + id);
    if (id === -1) {
      return;
    }
    this.userService.getById(id).subscribe({
      next: (employee) => {
        this.user.set(employee);
        console.log(employee);
      },
      error: (err) => {
        console.error(err);
      },
    });
  }
  change() {
    this.changeBand.update((v) => !v);
  }
}
