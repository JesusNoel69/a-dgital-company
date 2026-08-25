import { Component, EventEmitter, input, Input, OnInit, Output } from '@angular/core';
import { Pill } from '../../../../shared/components/pill/pill';
import { Employee } from '../../../../core/models/Employee';

@Component({
  selector: 'employees-details-modal',
  imports: [Pill],
  templateUrl: './employees-details-modal.html',
  styleUrl: './employees-details-modal.css',
})
export class EmployeesDetailsModal implements OnInit {
  ngOnInit(): void {
    //get employee by id ith details
  }
  modal = input.required<boolean>();
  roles = ['role1', 'role2', 'role3', 'role4', 'role5', 'role6'];
  @Input({ required: true }) employee: Employee | null = null;
  @Output() close = new EventEmitter<void>();
  closeModal() {
    this.close.emit();
  }
}
