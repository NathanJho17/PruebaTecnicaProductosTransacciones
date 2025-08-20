import { CommonModule } from '@angular/common';
import { Component, EventEmitter, inject, Input, OnInit, Output, signal } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { tipoTransaccion, TransaccionCrearDTO, TransaccionEditarDTO } from '../../models/DTOs/TransaccionDTO.models';
import { ActivatedRoute } from '@angular/router';
import { ProductsService } from '../../services/products.service';
import { TransactionService } from '../../services/transaction.service';
import { ProductoVerDTO } from '../../models/DTOs/ProductoDTO.model';

@Component({
  selector: 'app-form-transaction',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './form-transaction.component.html',
  styleUrl: './form-transaction.component.css'
})
export class FormTransactionComponent  implements OnInit {
 
  
  
    @Output() transactionFull = new EventEmitter<TransaccionCrearDTO | TransaccionEditarDTO>();
    @Input({ required: true }) formType!: string;
  
     tipoTransacciones:tipoTransaccion[]=['compra','venta'];
    private activedRouter = inject(ActivatedRoute);
    private productService = inject(ProductsService);
    private transaccionService = inject(TransactionService);
    productos = signal<ProductoVerDTO[]>([]);
  
    public formBuilder = inject(FormBuilder);
  
    messageCreateOrEdit = signal<string>('');
    dateRelease: any;
    idEdit: string = '';
    productoId:number=0;
    idEditDisabled: boolean = false;
  
    transactionForm: FormGroup = new FormGroup({
      id: new FormControl(null),
      tipoTransaccion: new FormControl(null),
      productoId: new FormControl(null),
      cantidad: new FormControl(null),
      precioUnitario: new FormControl(null),
      detalle: new FormControl(null),
    });
    colorInvalidInput: string = 'red';
  
  
    formTittle: string = '';
  
    ngOnInit(): void {
  
      this.getProducts();
      this.formTittle = `Formulario de ${this.formType}`;
      const idFromRoute = this.activedRouter.snapshot.paramMap.get('id');
       const productoIdFromRoute = this.activedRouter.snapshot.paramMap.get('productoId');
       if(productoIdFromRoute){
        this.productoId=+productoIdFromRoute;
       }
      if (idFromRoute) {
        this.idEdit = idFromRoute;
        this.idEditDisabled = true;
  
        this.getTransactionId(this.idEdit);
  
      }
  
      this.transactionForm = this.formBuilder.group({
        id: new FormControl({ value: this.idEdit, disabled: this.idEditDisabled }),
        tipoTransaccion: new FormControl('',
          [Validators.required]
        ),
        productoId: new FormControl(this.productoId, [Validators.required]),
        cantidad: new FormControl(0,
          [Validators.required]
        ),
        precioUnitario: new FormControl(0, [Validators.required]),
  
        detalle: new FormControl('',
          [Validators.required]
        ),
  
      });
  
  
    }
  
    getProducts() {
      this.productService.obtenerProductos(1,10).subscribe({
        next: (data) => {
          this.productos.set(data.datos);
        }
      })
    }
    getTransactionId(id: string) {
      this.transaccionService.obtenerTransaccionId(id).subscribe({
        next: (result) => {
          const { datos: data } = result;
          console.log(data);
          this.transactionForm.patchValue({
            id: data.identificadorUnico,
            detalle: data.detalle,
            tipoTransaccion: data.tipoTransaccion,
            cantidad: data.cantidad,
            precioUnitario: data.precioUnitario,
            productoId:data.productoId
          });
        }
      });
    }
    saveTransaction() {
      if (this.transactionForm.invalid) {
        return;
      }
      const transaction: TransaccionCrearDTO = this.transactionForm.getRawValue();
      this.transactionFull.emit(transaction);
    }
  
    resetForm() {
      this.transactionForm.reset();
    }
  
    onCategoriaChange(event: Event) {
      const selectedValue = (event.target as HTMLSelectElement).value;
      console.log('Producto seleccionado:', selectedValue);
      this.transactionForm.patchValue({
        idCategoria: +selectedValue
      });
    }

    onTipoTransaccionChange(event: Event) {
      const selectedValue = (event.target as HTMLSelectElement).value;
      console.log('Tipo seleccionado:', selectedValue);
      this.transactionForm.patchValue({
        tipoTransaccion: selectedValue
      });
    }

}
