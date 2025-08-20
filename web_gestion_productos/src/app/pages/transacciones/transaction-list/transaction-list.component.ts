import { Component, inject, OnInit, signal } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TransactionService } from '../../../services/transaction.service';
import { TransaccionVerDTO } from '../../../models/DTOs/TransaccionDTO.models';
import { CreateDatePipe } from '../../../pipes/create-date.pipe';
import { ButtonComponent } from '../../../components/button/button.component';

@Component({
  selector: 'app-transaction-list',
  standalone: true,
  imports: [CreateDatePipe, ButtonComponent],
  templateUrl: './transaction-list.component.html',
  styleUrl: './transaction-list.component.css'
})
export class TransactionListComponent implements OnInit {
  private activedRouter = inject(ActivatedRoute);
  private transaccionService = inject(TransactionService);
  private router = inject(Router);

  productoId: number = 0;
  deleteMessage = signal<string>('');

  transactions = signal<TransaccionVerDTO[]>([]);

  ngOnInit(): void {
    const idFromRoute = this.activedRouter.snapshot.paramMap.get('productoId');
    if (idFromRoute) {
      this.productoId = +idFromRoute;
      console.log(this.productoId);
      this.getTransactionProduct(this.productoId, 1, 10);
    }
  }


  getTransactionProduct(productoId: number, desde: number, limite: number) {

    this.transaccionService.obtenerTransacciones(productoId, desde, limite).subscribe({
      next: (data) => {
        console.log(data);
        this.transactions.set(data.datos);
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

}
