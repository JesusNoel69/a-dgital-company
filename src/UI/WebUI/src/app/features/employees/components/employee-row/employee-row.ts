import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Employee } from '../../../../core/models/Employee';
import { JobPosition } from '../../../../core/constants/JobPositions';
import { EmployeeService } from '../../../../core/services/employee.service';
import { EditSvg } from '../../../../shared/components/svg/edit-svg/edit-svg';
import { DeleteSvg } from '../../../../shared/components/svg/delete-svg/delete-svg';
import { InfoSvg } from '../../../../shared/components/svg/info-svg/info-svg';

@Component({
  selector: 'employee-row',
  standalone: true,
  imports: [EditSvg, DeleteSvg, InfoSvg],
  templateUrl: './employee-row.html',
  styleUrl: './employee-row.css',
})
export class EmployeeRow {
  @Input({ required: true }) employee!: Employee;
  @Input() rowColor: boolean = false;
  @Output() employeeDeleted = new EventEmitter<number>();
  @Input() isModalOpen = false;

  @Output() openModal = new EventEmitter<number>();
  @Output() closeModal = new EventEmitter<void>();
  @Output() detailsRequested = new EventEmitter<Employee>();
  @Output() detailsRequestedClose = new EventEmitter<void>();

  protected readonly JobPosition = JobPosition;
  constructor(private employeeService: EmployeeService) {}
  toggleModal(event: MouseEvent): void {
    event.stopPropagation();

    if (this.isModalOpen) {
      this.closeModal.emit();
    } else {
      this.openModal.emit(this.employee.id);
    }
  }

  onCloseModal(): void {
    this.closeModal.emit();
  }

  showEmployeeDetails(): void {
    console.log('here');
    this.onCloseModal();
    this.detailsRequested.emit(this.employee);
  }
  updateEmployee() {
    this.onCloseModal();
  }
  deleteEmployee() {
    this.onCloseModal();
    this.employeeService.deleteEmployee(this.employee.id).subscribe({
      next: () => {
        this.employeeDeleted.emit(this.employee.id);
      },
    });
  }
}
