import { Component, inject, Input } from '@angular/core';
import { Router } from '@angular/router';
type ActionButton = 'Add' | 'Reset' | 'Send' | 'Edit' | 'Delete'

@Component({
  selector: 'app-button',
  standalone: true,
  imports: [],
  templateUrl: './button.component.html',
  styleUrl: './button.component.css'
})

export class ButtonComponent {

  
  @Input({ required: true }) textButton: string = '';
  @Input({ required: true }) colorButton: string = '';
  @Input({ required: true }) colorTextButton: string = '';
  @Input({ required: true }) actionButton!: ActionButton;

  router = inject(Router);


  getTypeButton(tipo: ActionButton) {
    switch (tipo) {
      case 'Add':
        this.router.navigate(['/products/add']);
        break;
      case 'Send':
        break;
      case 'Reset':

        break;
    }
  }
}
