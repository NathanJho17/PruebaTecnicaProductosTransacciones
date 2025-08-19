namespace Domain;

public class RespuestaGenerica<T>
{
    public string Mensaje { get; set; } = string.Empty;
    public bool EsSatisfatorio { get; set; }
    public T Datos { get; set; }



    public RespuestaGenerica(string mensaje, bool esSatisfatorio, T datos)
    {
        Mensaje = mensaje;
        EsSatisfatorio = esSatisfatorio;
        Datos = datos;
    }

}
