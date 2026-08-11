import { Component, Input } from '@angular/core';
import { FormGroup, ReactiveFormsModule } from '@angular/forms';
import { NgClass } from '../../../../../node_modules/@angular/common/types/_common_module-chunk';
@Component({
  selector: 'floating-form-field',
  imports: [ReactiveFormsModule],
  templateUrl: './floating-form-field.html',
  styleUrl: './floating-form-field.css',
})
export class FloatingFormField {
  @Input({ required: true }) form!: FormGroup;
  @Input({ required: true }) controlName!: string;
  @Input({ required: true }) id!: string;
  @Input({ required: true }) label!: string;

  @Input() type: 'text' | 'email' | 'number' | 'date' | 'select' | 'password' = 'text';

  @Input() options: any[] = [];
  @Input() optionLabel = 'label';
  @Input() optionValue = 'value';
}
