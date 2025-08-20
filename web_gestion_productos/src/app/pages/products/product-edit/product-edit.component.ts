import { Component, inject, OnInit, signal } from '@angular/core';
import { FormProductComponent } from '../../../components/form-product/form-product.component';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductsService } from '../../../services/products.service';
import { ProductoEditarDTO, ProductoVerDTO } from '../../../models/DTOs/ProductoDTO.model';

@Component({
  selector: 'app-product-edit',
  standalone: true,
  imports: [FormProductComponent],
  templateUrl: './product-edit.component.html',
  styleUrl: './product-edit.component.css'
})
export class ProductEditComponent implements OnInit {

  private router = inject(Router);
  private activedRouter = inject(ActivatedRoute);
  idEdit: number = 0;

  ngOnInit(): void {
    const idFromRoute = this.activedRouter.snapshot.paramMap.get('id');
    if (idFromRoute) {
      this.idEdit=+idFromRoute;
    }
  }
  private productService = inject(ProductsService);
  editedMessage = signal<string>('');

  editProduct(product: ProductoEditarDTO) {
    this.productService.editarProducto(this.idEdit, product).subscribe({
      next: (value) => {
        this.editedMessage.set(value.mensaje || '');
        setTimeout(() => {
          this.router.navigate(["/products"]);
        }, 3000);
      }
    })
  }
}
