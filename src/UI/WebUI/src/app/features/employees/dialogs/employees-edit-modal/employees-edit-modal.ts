import { Component, EventEmitter, input, Input, OnInit, Output, signal } from '@angular/core';
import { Employee } from '../../../../core/models/Employee';
import { FormBuilder, FormGroup, ɵInternalFormsSharedModule } from '@angular/forms';
import { JobPosition } from '../../../../core/constants/JobPositions';
import { FloatingFormField } from '../../../../shared/components/floating-form-field/floating-form-field';
import { JobPositionOption } from '../../../../core/interfaces/JobPositionOptions';
import { DepartmentDto } from '../../../../core/models/DepartmentDto';
import { DepartmentService } from '../../../../core/services/department.service';

@Component({
  selector: 'employees-edit-modal',
  imports: [FloatingFormField, ɵInternalFormsSharedModule],
  templateUrl: './employees-edit-modal.html',
  styleUrl: './employees-edit-modal.css',
})
export class EmployeesEditModal implements OnInit {
  /*
        ┌──────────────────────────────────┐
        │ Edit Employee                    │
        ├──────────────────────────────────┤
        │                                  │
        │ Personal Information             │
        │ [ First Name ] [ Last Name ]     │
        │ [ Email ]                        │
        │ [ Phone ]                        │
        │                                  │
        │ Employment                       │
        │ [ Position ▼ ]                   │
        │ [ Department ▼ ]                 │
        │ [ Hire Date ]                    │
        │ [ Clock Number ]                 |
        │                                  │
        │ [ Salary ]                       │
        │                                  │
        │ Identification                   │
        │ [ RFC ]                          │
        │ [ Social Number ]                │
        │                                  │
        │             Cancel   Save        │
        └──────────────────────────────────┘
        email
        userName
        poneNumber
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public string IdentityUserId { get; private set; } = default!;
        public string ClockNumber { get; private set; } = default!;
        public string? PhotoUrl { get; private set; }
        public string Rfc { get; private set; }
        public string SocialNumber { get; private set; }
        public DateTime HireDate { get; private set; }
        public JobPosition JobPosition { get; private set; }
        public int DepartmentId { get; private set; }
        public decimal Salary { get; private set; }
  */
  modal = input.required<boolean>();
  @Input({ required: true }) employee: Employee | null = null;
  @Output() close = new EventEmitter<void>();
  employeeForm!: FormGroup;
  departments = signal<DepartmentDto[]>([]);
  jobPositions = signal<JobPositionOption[]>([]);

  constructor(
    private readonly fb: FormBuilder,
    private readonly departmentService: DepartmentService,
  ) {
    this.employeeForm = this.fb.group({
      email: [''],
      firstName: [''],
      lastName: [''],
      salary: [],
      departmentId: [],
      hireDate: [],
      jobPosition: [JobPosition.Unassigned],
      rfc: [''],
      clockNumber: [''],
      socialNumber: [''],
      photoUrl: [''],
      phone: [''],
    });
  }
  ngOnInit(): void {
    this.departmentService.getDeparments().subscribe({
      next: (response: DepartmentDto[]) => {
        this.departments.set(response);
        this.jobPositions.set(
          Object.keys(JobPosition)
            .filter((key) => isNaN(Number(key)))
            .map((key) => ({
              value: JobPosition[key as keyof typeof JobPosition],
              label: this.formatEnum(key),
            })),
        );
      },
      error: (error) => {
        console.error(error);
      },
    });
  }
  //create an utility for it
  private formatEnum(text: string): string {
    return text.replace(/([A-Z])/g, ' $1').trim();
  }
  closeModal() {
    this.close.emit();
  }
}
