import { Component, inject, OnInit, signal } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TransactionService } from '../../../services/transaction.service';
import { tipoTransaccion, TransaccionVerDTO } from '../../../models/DTOs/TransaccionDTO.models';
import { CreateDatePipe } from '../../../pipes/create-date.pipe';
import { ButtonComponent } from '../../../components/button/button.component';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-transaction-list',
  standalone: true,
  imports: [CreateDatePipe, ButtonComponent, CommonModule, ReactiveFormsModule],
  templateUrl: './transaction-list.component.html',
  styleUrl: './transaction-list.component.css'
})
export class TransactionListComponent implements OnInit {
  private activedRouter = inject(ActivatedRoute);
  private transaccionService = inject(TransactionService);
  private router = inject(Router);
  private formBulder = inject(FormBuilder);

  formSearch!: FormGroup;
  productoId: number = 0;
  deleteMessage = signal<string>('');
  tipoTransacciones: tipoTransaccion[] = ['compra', 'venta'];

  transactions = signal<TransaccionVerDTO[]>([]);
  displayedTransacciones = signal<TransaccionVerDTO[]>([]);

  currentPage = 1;
  pageSize = 5;
  totalPages = 0;

  ngOnInit(): void {
    this.formSearch = this.formBulder.group({
      fechaDesde: [''],
      fechaHasta: [''],
      tipo: ['']
    });

    const idFromRoute = this.activedRouter.snapshot.paramMap.get('productoId');
    if (idFromRoute) {
      this.productoId = +idFromRoute;
      console.log(this.productoId);
      this.getTransactionProduct(this.productoId, 1, 10, '', '', '');

    }
  }


  getTransactionProduct(productoId: number, pagina: number, paginaLimite: number, fechaDesde: string, fechaHasta: string, tipo: string) {
    const desde = 1;
    this.transaccionService.obtenerTransacciones(productoId, desde, paginaLimite, fechaDesde, fechaHasta, tipo).subscribe({
      next: (data) => {
        console.log(data);
        this.transactions.set(data.datos);
        this.totalPages = Math.ceil(this.transactions().length / this.pageSize);
        this.currentPage = pagina;
        this.updateDisplayedTransacciones();
      }
    })
  }
  deleteTransaction(identificadorUnico: string) {
    this.transaccionService.eliminarTransaccion(identificadorUnico).subscribe({
      next: (data) => {
        this.deleteMessage.set(data.mensaje);
        setTimeout(() => {
          this.router.navigate(["transactions", "product", this.productoId]);
        }, 3000);
      }
    })
  }

  routeToEditTransaction(id: string) {
    this.router.navigate(["transactions", "product", this.productoId, "edit", id]);
  }

  searchRecords() {
    console.log(this.formSearch.value);
    const { fechaDesde = '', fechaHasta = '', tipo = '' } = this.formSearch.value;
    this.getTransactionProduct(this.productoId, 1, 10, fechaDesde, fechaHasta, tipo);
  }

  updateDisplayedTransacciones() {
    const start = (this.currentPage - 1) * this.pageSize;
    const end = start + this.pageSize;
    console.log(start);
    console.log(end);

    this.displayedTransacciones.set(this.transactions().slice(start, end));
  }

  goToPage(page: number) {
    if (page < 1 || page > this.totalPages) return;
    this.currentPage = page;
    this.updateDisplayedTransacciones();
  }

}
