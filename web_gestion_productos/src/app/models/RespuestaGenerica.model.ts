export interface RespuestaGenerica<T = unknown>{
    mensaje:string;
    esSatisfatorio:boolean;
    datos:T;
}