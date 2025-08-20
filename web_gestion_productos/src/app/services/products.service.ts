import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { ProductoCrearDTO, ProductoEditarDTO, ProductoVerDTO } from '../models/DTOs/ProductoDTO.model';
import { RespuestaGenerica } from '../models/RespuestaGenerica.model';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {


  private http = inject(HttpClient);
  private apiUrl = `${environment.API_PRODUCTS}`;

  constructor() { }

  obtenerProductos(desde:number,limite:number): Observable<RespuestaGenerica<ProductoVerDTO[]>> {
    return this.http.get<RespuestaGenerica<ProductoVerDTO[]>>(`${this.apiUrl}?desde=${desde}&limite=${limite}`);
  }

   obtenerProductoId(id:number): Observable<RespuestaGenerica<ProductoVerDTO>> {
    return this.http.get<RespuestaGenerica<ProductoVerDTO>>(`${this.apiUrl}/${id}`);
  }

   crerProducto(product:ProductoCrearDTO): Observable<RespuestaGenerica<ProductoVerDTO>> {
    return this.http.post<RespuestaGenerica<ProductoVerDTO>>(`${this.apiUrl}`,product);
  }

 

  editarProducto(id:number,editBody:ProductoEditarDTO): Observable<RespuestaGenerica<ProductoVerDTO>> {
    return this.http.put<RespuestaGenerica<ProductoVerDTO>>(`${this.apiUrl}/${id}`,editBody);
  }

  eliminarProducto(id:number): Observable<RespuestaGenerica<boolean>> {
    return this.http.delete<RespuestaGenerica<boolean>>(`${this.apiUrl}/${id}`);
  }
}
