export interface TransaccionVerDTO {
  identificadorUnico: string;     
  esActivo: boolean;
  fechaCreacion: string;           
  tipoTransaccion: 'compra' | 'venta'; 
  nombreProducto: string;
  stockProducto: number;
  cantidad: number;
  precioUnitario: number;
  precioTotal: number;
  detalle: string;
}

export interface TransaccionCrearDTO {
  tipoTransaccion: string;   
  productoId: number;        
  cantidad: number;        
  precioUnitario: number;  
  detalle?: string;         
}

export interface TransaccionEditarDTO extends TransaccionCrearDTO {
  esActivo: boolean;      
}