import { Routes } from "@angular/router";
import { TransactionListComponent } from "./transaction-list/transaction-list.component";

export const transaccion_routes: Routes = [
    { path: 'product/:productoId', component: TransactionListComponent },

];