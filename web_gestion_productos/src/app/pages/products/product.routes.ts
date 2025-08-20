import { Routes } from "@angular/router";
import { ProductListComponent } from "./product-list/product-list.component";
import { ProductAddComponent } from "./product-add/product-add.component";
import { ProductEditComponent } from "./product-edit/product-edit.component";

export const product_routes: Routes = [
    { path: 'add', component: ProductAddComponent },
    { path: '', component: ProductListComponent },
    { path: 'edit/:id', component: ProductEditComponent, }
];