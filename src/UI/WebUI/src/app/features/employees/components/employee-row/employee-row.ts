import { Component, Input } from '@angular/core';
import { Employee } from '../../../../core/models/Employee';
import { JobPosition } from '../../../../core/constants/JobPositions';

@Component({
  selector: 'employee-row',
  standalone: true,
  imports: [],
  templateUrl: './employee-row.html',
  styleUrl: './employee-row.css',
})
export class EmployeeRow {
  @Input({ required: true }) employee!: Employee;
  @Input() rowColor: boolean = false;
  isModalOpen = false;
  protected readonly JobPosition = JobPosition;

  toggleModal(event: MouseEvent): void {
    event.stopPropagation();
    this.isModalOpen = !this.isModalOpen;
  }

  closeModal(): void {
    this.isModalOpen = false;
  }
}
