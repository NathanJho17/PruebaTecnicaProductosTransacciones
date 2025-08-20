import { Component, inject, signal } from '@angular/core';
import { Router } from '@angular/router';
import { ProductsService } from '../../../services/products.service';
import { ProductoCrearDTO } from '../../../models/DTOs/ProductoDTO.model';
import { FormProductComponent } from '../../../components/form-product/form-product.component';
import { CategoriaVerDTO } from '../../../models/DTOs/CategoriaDTO.model';
import { CategoryService } from '../../../services/category.service';

@Component({
  selector: 'app-product-add',
  standalone: true,
  imports: [FormProductComponent],
  templateUrl: './product-add.component.html',
  styleUrl: './product-add.component.css'
})
export class ProductAddComponent {

  private router = inject(Router);
  private productService = inject(ProductsService);


  createdMessage = signal<string>('');
  createProduct(product: ProductoCrearDTO) {
    this.productService.crerProducto(product).subscribe({
      next: (value) => {
        this.createdMessage.set(value.mensaje || '');
        setTimeout(() => {
          this.router.navigate(["/products"]);
        }, 3000);
      }
    })
  }

 
}
