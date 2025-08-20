import { Component, inject, OnInit, signal } from '@angular/core';
import { ProductsService } from '../../../services/products.service';
import { ProductoVerDTO } from '../../../models/DTOs/ProductoDTO.model';
import { ImageComponent } from '../../../components/image/image.component';
import { ButtonComponent } from '../../../components/button/button.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product-list',
  standalone: true,
  imports: [ImageComponent, ButtonComponent],
  templateUrl: './product-list.component.html',
  styleUrl: './product-list.component.css'
})
export class ProductListComponent implements OnInit {
  private productService = inject(ProductsService);
  private router = inject(Router);

  ngOnInit(): void {
    this.getProducts(1, 10);

    
}

  productos = signal<ProductoVerDTO[]>([]);

  productosSeleccionados = signal<ProductoVerDTO[]>([]);
  itemSeleccionado = signal<number>(5);
  deleteMessage = signal<string>('');

  totalRegistros = signal<number>(0);

  
  getProducts(desde: number, limite: number) {
    this.productService.obtenerProductos(desde, limite).subscribe({
      next: (data) => {
        console.log(data);
        this.productos.set(data.datos);
        this.totalRegistros.set(this.productos().length);
        this.productosSeleccionados.set(this.productos().slice(0, this.itemSeleccionado()));
      }
    });
  }

  deleteProduct(id: number) {
    this.productService.eliminarProducto(id).subscribe({
      next: (data) => {
        this.deleteMessage.set(data.mensaje);
        setTimeout(() => {
          this.router.navigate(["/products"]);
        }, 3000);
      }
    })
  }

  routeToEditProduct(id: number) {
    this.router.navigate(['/products/edit', id]);
  }

  routeToTtansactionsProduct(productoId: number) {
    this.router.navigate(['/transactions/product', productoId]);
  }

}
