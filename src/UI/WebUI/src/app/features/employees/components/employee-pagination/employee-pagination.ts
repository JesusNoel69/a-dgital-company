import { Component, computed, Input, OnInit, Signal, signal } from '@angular/core';
import { EmployeeService } from '../../../../core/services/employee.service';
import { Employee } from '../../../../core/models/Employee';
import { PaginationState } from '../../../../core/interfaces/PaginationState';

@Component({
  selector: 'employee-pagination',
  imports: [],
  templateUrl: './employee-pagination.html',
  styleUrl: './employee-pagination.css',
})
export class EmployeePagination implements OnInit {
  constructor(private employeeService: EmployeeService) {}
  numberOfEmployees = signal<number>(0);
  readonly pageSize = 20;
  totalPages = computed(() => Math.ceil(this.numberOfEmployees() / this.pageSize));
  pages = computed(() =>
    Array.from({ length: this.totalPages() }, (_, i) => {
      if (i <= 5) {
        return i + 1;
      }
      return i;
    }),
  );
  currentPage = signal<number>(1);
  pagination = signal<PaginationState>({
    end: 20,
    start: 1,
  });

  ngOnInit(): void {
    this.employeeService.pagination$.subscribe({
      next: (pagination) => {
        this.pagination.set(pagination);
        this.updateEnd(pagination.start);
      },
    });
    this.employeeService.getAllEmployeesCount().subscribe({
      next: (response) => {
        this.numberOfEmployees.set(response);
        this.updateEnd(this.pagination().start);
      },
      error: (err) => {
        console.log(err);
      },
    });
  }

  private updateEnd(start: number): void {
    const end = Math.min(start + this.pageSize - 1, this.numberOfEmployees());

    this.pagination.update((current) => ({
      ...current,
      end,
    }));
  }

  nextPage(): void {
    const nextStart = this.pagination().start + this.pageSize;

    if (nextStart > this.numberOfEmployees()) {
      return;
    }

    const nextEnd = Math.min(nextStart + this.pageSize - 1, this.numberOfEmployees());
    this.employeeService.setPagination(nextStart, nextEnd);
  }

  advance(page: number): void {
    const start = (page - 1) * this.pageSize + 1;
    const end = Math.min(page * this.pageSize, this.numberOfEmployees());
    this.currentPage.set(page);
    this.employeeService.setPagination(start, end);
  }

  previousPage(): void {
    const previousStart = this.pagination().start - this.pageSize;

    if (previousStart < 1) {
      return;
    }

    const previousEnd = previousStart + this.pageSize - 1;
    this.employeeService.setPagination(previousStart, previousEnd);
  }
}
