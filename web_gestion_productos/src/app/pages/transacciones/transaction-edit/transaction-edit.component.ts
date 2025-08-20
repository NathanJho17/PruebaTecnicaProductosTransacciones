import { Component, inject, signal } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { TransactionService } from '../../../services/transaction.service';
import { TransaccionEditarDTO } from '../../../models/DTOs/TransaccionDTO.models';
import { FormTransactionComponent } from '../../../components/form-transaction/form-transaction.component';

@Component({
  selector: 'app-transaction-edit',
  standalone: true,
  imports: [FormTransactionComponent],
  templateUrl: './transaction-edit.component.html',
  styleUrl: './transaction-edit.component.css'
})
export class TransactionEditComponent {

    private router = inject(Router);
    private activedRouter = inject(ActivatedRoute);
    identificadorEdit: string = '';
  
    ngOnInit(): void {
      const idFromRoute = this.activedRouter.snapshot.paramMap.get('identificador');
        console.log(idFromRoute);
      if (idFromRoute) {
        this.identificadorEdit=idFromRoute;
      
      }
    }
    private transactionService = inject(TransactionService);
    editedMessage = signal<string>('');
  
    editarTransaccion(transaction: TransaccionEditarDTO) {
      this.transactionService.editarTransaccion(this.identificadorEdit, transaction).subscribe({
        next: (value) => {
          this.editedMessage.set(value.mensaje || '');
          setTimeout(() => {
            this.router.navigate(["transactions","product", transaction.productoId]);
          }, 3000);
        }
      })
    }
}
