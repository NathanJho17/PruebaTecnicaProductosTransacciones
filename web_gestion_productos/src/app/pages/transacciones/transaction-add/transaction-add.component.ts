import { Component, inject, signal } from '@angular/core';
import { Router } from '@angular/router';
import { TransactionService } from '../../../services/transaction.service';
import { TransaccionCrearDTO } from '../../../models/DTOs/TransaccionDTO.models';
import { FormTransactionComponent } from '../../../components/form-transaction/form-transaction.component';

@Component({
  selector: 'app-transaction-add',
  standalone: true,
  imports: [FormTransactionComponent],
  templateUrl: './transaction-add.component.html',
  styleUrl: './transaction-add.component.css'
})
export class TransactionAddComponent {

  private router = inject(Router);
  private transaccionService = inject(TransactionService);


  createdMessage = signal<string>('');
  createTransaction(transaction: TransaccionCrearDTO) {
    this.transaccionService.crerTransaccion(transaction).subscribe({
      next: (value) => {
        this.createdMessage.set(value.mensaje || '');
        setTimeout(() => {
          this.router.navigate(["transactions","product",transaction.productoId]);
        }, 3000);
      }
    })
  }
}
