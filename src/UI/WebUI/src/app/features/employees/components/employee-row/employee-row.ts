import { Component, ElementRef, HostListener, Input, ViewChild } from '@angular/core';
import { Employee } from '../../../../core/models/Employee';

@Component({
  selector: 'employee-row',
  imports: [],
  templateUrl: './employee-row.html',
  styleUrl: './employee-row.css',
})
export class EmployeeRow {
  @Input() employee!: Employee;

  @ViewChild('modal') modalElement!: ElementRef;
  public isModalOpen: boolean = false;
  toggleModal($event: Event) {
    $event.stopPropagation();
    this.isModalOpen = !this.isModalOpen;
  }
  @HostListener('document:click', ['$event'])
  onClickOutside(event: MouseEvent) {
    if (
      this.isModalOpen &&
      this.modalElement &&
      !this.modalElement.nativeElement.contains(event.target)
    ) {
      this.isModalOpen = false;
    }
  }
}
