import { Routes } from "@angular/router";
import { TransactionListComponent } from "./transaction-list/transaction-list.component";
import { TransactionAddComponent } from "./transaction-add/transaction-add.component";
import { TransactionEditComponent } from "./transaction-edit/transaction-edit.component";

export const transaccion_routes: Routes = [
    { path: 'product/:productoId', component: TransactionListComponent },
     { path: 'product/:productoId/add', component: TransactionAddComponent },
         { path: 'product/:productoId/edit/:identificador', component: TransactionEditComponent, }
     
];