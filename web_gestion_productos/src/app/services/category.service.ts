import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { CategoriaVerDTO } from '../models/DTOs/CategoriaDTO.model';
import { Observable } from 'rxjs';
import { RespuestaGenerica } from '../models/RespuestaGenerica.model';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

   private http = inject(HttpClient);
    private apiUrl = `${environment.API_CATEGORY}`;
  constructor() { }

  obtenerCategorias(): Observable<RespuestaGenerica<CategoriaVerDTO[]>> {
      return this.http.get<RespuestaGenerica<CategoriaVerDTO[]>>(`${this.apiUrl}`);
    }
  
}
