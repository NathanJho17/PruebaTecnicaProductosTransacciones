import { Component, EventEmitter, inject, Input, OnInit, Output, signal } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ProductoCrearDTO, ProductoEditarDTO } from '../../models/DTOs/ProductoDTO.model';
import { ActivatedRoute } from '@angular/router';
import { ProductsService } from '../../services/products.service';
import { CommonModule } from '@angular/common';
import { CategoryService } from '../../services/category.service';
import { CategoriaVerDTO } from '../../models/DTOs/CategoriaDTO.model';

@Component({
  selector: 'app-form-product',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './form-product.component.html',
  styleUrl: './form-product.component.css'
})
export class FormProductComponent implements OnInit {




  @Output() productFull = new EventEmitter<ProductoCrearDTO | ProductoEditarDTO>();
  @Input({ required: true }) formType!: string;

  private activedRouter = inject(ActivatedRoute);
  private productService = inject(ProductsService);
  private categoryService = inject(CategoryService);
  categorias = signal<CategoriaVerDTO[]>([]);

  public formBuilder = inject(FormBuilder);

  messageCreateOrEdit = signal<string>('');
  dateRelease: any;
  idEdit: string = '';
  idEditDisabled: boolean = false;

  productForm: FormGroup = new FormGroup({
    id: new FormControl(null),
    nombreProducto: new FormControl(null),
    descripcion: new FormControl(null),
    precio: new FormControl(null),
    stock: new FormControl(null),
    idCategoria: new FormControl(null),
    imagen: new FormControl(null),
  });
  colorInvalidInput: string = 'red';


  formTittle: string = '';

  ngOnInit(): void {

    this.getCategories();
    this.formTittle = `Formulario de ${this.formType}`;
    const idFromRoute = this.activedRouter.snapshot.paramMap.get('id');
    if (idFromRoute) {
      this.idEdit = idFromRoute;
      this.idEditDisabled = true;

      this.getProductId(+this.idEdit);

    }

    this.productForm = this.formBuilder.group({
      id: new FormControl({ value: this.idEdit, disabled: this.idEditDisabled }),
      nombreProducto: new FormControl('',
        [Validators.required,
        Validators.minLength(1),
        Validators.maxLength(100)]
      ),
      descripcion: new FormControl('',
        [Validators.required,
        Validators.minLength(1),
        Validators.maxLength(200)]
      ),
      precio: new FormControl(0, [Validators.required]),
      stock: new FormControl(0,
        [Validators.required]
      ),
      idCategoria: new FormControl(0, [Validators.required]),

      imagen: new FormControl('',
        [Validators.required]
      ),

    });


  }

  getCategories() {
    this.categoryService.obtenerCategorias().subscribe({
      next: (data) => {
        this.categorias.set(data.datos);
      }
    })
  }
  getProductId(id: number) {
    this.productService.obtenerProductoId(id).subscribe({
      next: (result) => {
        const { datos: data } = result;
        console.log(data);
        this.productForm.patchValue({
          id: data.productoId,
          nombreProducto: data.nombreProducto,
          descripcion: data.descripcion,
          precio: data.precio,
          stock: data.stock,
          idCategoria: data.categoriaProducto.categoriaId,
          imagen: data.imagen
        });
      }
    });
  }
  saveProduct() {
    if (this.productForm.invalid) {
      return;
    }
    const product: ProductoCrearDTO = this.productForm.getRawValue();
    this.productFull.emit(product);
  }

  resetForm() {
    this.productForm.reset();
  }

  onCategoriaChange(event: Event) {
    const selectedValue = (event.target as HTMLSelectElement).value;
    console.log('Categoría seleccionada:', selectedValue);
    this.productForm.patchValue({
      idCategoria: +selectedValue
    });
  }
}
