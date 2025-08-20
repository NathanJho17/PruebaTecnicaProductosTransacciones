import { Component, inject, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
type ActionButton = 'Add' | 'Reset' | 'Send' | 'Edit' | 'Delete'

@Component({
  selector: 'app-button',
  standalone: true,
  imports: [],
  templateUrl: './button.component.html',
  styleUrl: './button.component.css'
})

export class ButtonComponent implements OnInit {


  private activedRouter = inject(ActivatedRoute);

  @Input({ required: true }) textButton: string = '';
  @Input({ required: true }) colorButton: string = '';
  @Input({ required: true }) colorTextButton: string = '';
  @Input({ required: true }) actionButton!: ActionButton;
  @Input({ required: true }) entity!: 'Transaccion' | 'Producto';

  router = inject(Router);
  productoId:number=0;
  ngOnInit(): void {
    const idFromRoute = this.activedRouter.snapshot.paramMap.get('productoId');
    if (idFromRoute) {
      this.productoId = +idFromRoute;
    }
  }
  getTypeButton(tipo: ActionButton) {
    switch (tipo) {
      case 'Add':
        switch (this.entity) {
          case 'Producto':
            this.router.navigate(['/products/add']);
            break;
          case 'Transaccion':
            this.router.navigate(['transactions', 'product', this.productoId, 'add']);
            break;

          default:
            break;
        }
        break;
      case 'Send':
        break;
      case 'Reset':

        break;
    }
  }
}
