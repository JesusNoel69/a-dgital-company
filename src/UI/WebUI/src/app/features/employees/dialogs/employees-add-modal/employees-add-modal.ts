import { Component, EventEmitter, Input, Output, signal } from '@angular/core';
import { FormGroup, FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { JobPosition } from '../../../../core/constants/JobPositions';
import { JobPositionOption } from '../../../../core/interfaces/JobPositionOptions';
import { CreateUserRequest } from '../../../../core/models/CreateUserRequest';
import { DepartmentDto } from '../../../../core/models/DepartmentDto';
import { DepartmentService } from '../../../../core/services/department.service';
import { FloatingFormField } from '../../../../shared/components/floating-form-field/floating-form-field';
import { EmployeeService } from '../../../../core/services/employee.service';
import { DEFAULT_PASSWORD } from '../../../../core/constants/pass';
import { email } from '@angular/forms/signals';
import { Spinner } from '../../../../shared/components/spinner/spinner';

@Component({
  selector: 'employees-add-modal',
  imports: [ReactiveFormsModule, FloatingFormField, Spinner],
  templateUrl: './employees-add-modal.html',
  styleUrl: './employees-add-modal.css',
})
export class EmployeesAddModal {
  @Input() modalOpened!: boolean;
  @Output() close = new EventEmitter<void>();
  //@Output() employeeCreated = new EventEmitter<number>();
  buttonAddDisabled = signal(false);
  departments = signal<DepartmentDto[]>([]);
  jobPositions = signal<JobPositionOption[]>([]);
  employeeForm!: FormGroup;
  addEmployeeResponse!: number;

  constructor(
    private readonly fb: FormBuilder,
    private readonly departmentService: DepartmentService,
    private readonly employeeService: EmployeeService,
  ) {
    this.employeeForm = this.fb.group({
      email: [''],
      firstName: [''],
      lastName: [''],
      hireDate: [''],
      salary: [],
      departmentId: [],
      jobPosition: [JobPosition.Unassigned],
      rfc: [''],
      clockNumber: [''],
      socialNumber: [''],
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

  addEmployee(): void {
    this.buttonAddDisabled.set(true);
    if (this.employeeForm.invalid) {
      this.employeeForm.markAllAsTouched();
      return;
    }

    const form = this.employeeForm.getRawValue();

    const employee = new CreateUserRequest(
      form.email,
      form.fistName + ' ' + form.lastName,
      DEFAULT_PASSWORD,
      form.firstName,
      form.lastName,
      form.clockNumber,
      form.rfc,
      form.socialNumber,
      form.hireDate,
      form.departmentId,
      form.jobPosition,
      form.salary,
    );
    this.employeeService.addEmployee(employee).subscribe({
      next: (id) => {
        this.employeeService.notifyEmployeeCreated(id);
        //this.employeeCreated.emit(id);

        this.employeeForm.reset({
          jobPosition: JobPosition.Unassigned,
          departmentId: null,
          salary: null,
          email: null,
          rfc: null,
          hireDate: Date(),
          clockNumber: null,
          socialNumber: null,
          firstName: null,
          lastName: null,
        });
        this.closeModal();
      },
      error: (error) => {
        console.error('Error creating employee:', error);
        console.error('Backend validation:', error.error);
      },
    });
    this.buttonAddDisabled.set(false);
  }

  closeModal() {
    this.close.emit();
  }

  private formatEnum(text: string): string {
    return text.replace(/([A-Z])/g, ' $1').trim();
  }
}
