import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { RespuestaGenerica } from '../models/RespuestaGenerica.model';
import { TransaccionCrearDTO, TransaccionEditarDTO, TransaccionVerDTO } from '../models/DTOs/TransaccionDTO.models';

@Injectable({
  providedIn: 'root'
})
export class TransactionService {


  private http = inject(HttpClient);
  private apiUrl = `${environment.API_TRANSACCIONES}`;

  constructor() { }

  obtenerTransacciones(productoId: number, desde: number, limite: number, fechaDesde?: string,
    fechaHasta?: string,
    tipo?: string): Observable<RespuestaGenerica<TransaccionVerDTO[]>> {
    return this.http.get<RespuestaGenerica<TransaccionVerDTO[]>>
    (`${this.apiUrl}?ProductoId=${productoId}&desde=${desde}&limite=${limite}&FechaDesde=${fechaDesde}&FechaHasta=${fechaHasta}&TipoTransaccion=${tipo}`);
  }

  obtenerTransaccionId(id: string): Observable<RespuestaGenerica<TransaccionVerDTO>> {
    return this.http.get<RespuestaGenerica<TransaccionVerDTO>>(`${this.apiUrl}/${id}`);
  }

  crerTransaccion(product: TransaccionCrearDTO): Observable<RespuestaGenerica<TransaccionVerDTO>> {
    return this.http.post<RespuestaGenerica<TransaccionVerDTO>>(`${this.apiUrl}`, product);
  }



  editarTransaccion(id: string, editBody: TransaccionEditarDTO): Observable<RespuestaGenerica<TransaccionVerDTO>> {
    return this.http.put<RespuestaGenerica<TransaccionVerDTO>>(`${this.apiUrl}/${id}`, editBody);
  }

  eliminarTransaccion(id: string): Observable<RespuestaGenerica<boolean>> {
    return this.http.delete<RespuestaGenerica<boolean>>(`${this.apiUrl}/${id}`);
  }
}
