import { Routes } from '@angular/router';

export const routes: Routes = [
    {
        path: '',
        pathMatch: 'full',
        redirectTo: 'products'
    },
    {
        path: 'products',
        loadChildren: () => import('./pages/products/product.routes').then(p => p.product_routes)
    },
    {
        path: 'transactions',
        loadChildren: () => import('./pages/transacciones/transaccion.routes').then(p => p.transaccion_routes)
    },
    { path: '**', redirectTo: '/products' }
];
