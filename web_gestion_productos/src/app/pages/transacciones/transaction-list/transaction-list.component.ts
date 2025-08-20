import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { TransactionService } from '../../../services/transaction.service';

@Component({
  selector: 'app-transaction-list',
  standalone: true,
  imports: [],
  templateUrl: './transaction-list.component.html',
  styleUrl: './transaction-list.component.css'
})
export class TransactionListComponent implements OnInit{
    private activedRouter = inject(ActivatedRoute);
    private transaccionService=inject(TransactionService);
    productoId:number=0;
  ngOnInit(): void {
    const idFromRoute = this.activedRouter.snapshot.paramMap.get('productoId');
    if (idFromRoute) {
      this.productoId=+idFromRoute;
      console.log(this.productoId);
      this.getTransactionProduct(this.productoId,1,10);
    }
  }


  getTransactionProduct(productoId:number,desde:number,limite:number){

    this.transaccionService.obtenerTransacciones(productoId,desde,limite).subscribe({
      next:(data)=>{
        console.log(data);
      }
    })
  }

}
