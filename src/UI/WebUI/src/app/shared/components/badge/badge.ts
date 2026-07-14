import { Component, OnInit, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DatePipe, NgOptimizedImage } from '@angular/common';
import { URL } from '../../../core/constants/api';
import { Employee } from '../../../core/models/Employee';
@Component({
  selector: 'employee-badge',
  imports: [DatePipe, NgOptimizedImage],
  templateUrl: './badge.html',
  styleUrl: './badge.css',
})
export class Badge implements OnInit {
  public user = signal<Employee | null>(null);
  public changeBand = signal(false);
  private userId: number = 1;
  private readonly urlEmployee = URL + 'api/Employees/' + this.userId;
  public readonly ourValues = [
    'Security and Responsabilty',
    'Integrity and Transparency',
    'Quality',
    'People and Success',
    'Purpose',
  ];

  constructor(private readonly client: HttpClient) {}
  async ngOnInit() {
    console.log(this.urlEmployee);
    this.client.get<Employee>(this.urlEmployee).subscribe({
      next: (employee) => {
        this.user?.set(employee);
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
