import { NgOptimizedImage } from '@angular/common';
import { Component, Input } from '@angular/core';
import { FormGroup, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'form-field',
  imports: [NgOptimizedImage, ReactiveFormsModule],
  templateUrl: './form-field.html',
  styleUrl: './form-field.css',
})
export class FormField {
  @Input({ required: true }) form!: FormGroup;
  @Input() id: string = '';
  @Input() descriptionImage: string = '';
  @Input() iconSrc: string = '';
  @Input() type: string = '';
  @Input() placeHolder: string = '';
  @Input() controlName: string = '';
}
