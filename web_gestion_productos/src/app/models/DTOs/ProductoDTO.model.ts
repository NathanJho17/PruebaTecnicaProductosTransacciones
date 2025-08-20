import { CategoriaVerDTO } from "./CategoriaDTO.model";

export interface ProductoCrearDTO {
  nombreProducto: string;      
  descripcion: string;          
  precio: number;               
  stock: number;              
  idCategoria: number;          
  imagen: string;               
}

// Extiende ProductoCrearDTO para ver producto
export interface ProductoVerDTO extends ProductoCrearDTO {
  productoId: number;
  esActivo: boolean;
  categoriaProducto: CategoriaVerDTO;
}

// Extiende ProductoCrearDTO para editar producto
export interface ProductoEditarDTO extends ProductoCrearDTO {
  esActivo?: boolean;
}