using Application;
using Application.DTOs;
using AutoMapper;
using Domain;
using Moq;

namespace msProducto.Test.UsesCases;

public class CrearProductoUseCaseTest
{
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IProductoRepository> _productoServiceMock;

    private readonly CrearProductoUseCase _crearProductoUseCase;

    public CrearProductoUseCaseTest()
    {
        _mapperMock = new Mock<IMapper>();
        _productoServiceMock = new Mock<IProductoRepository>();
        _crearProductoUseCase = new CrearProductoUseCase(
            _productoServiceMock.Object,
            _mapperMock.Object);
    }

    [Fact]
    public async Task Debe_Crear_Producto_Exitosamente()
    {
        //Arrange

         ProductoCrearDTO productoCrearDTOMock = new ProductoCrearDTO
        {
            NombreProducto = "Producto Test",
            Descripcion = "Descripcion del producto de prueba",
            Precio = 10,
            Stock = 50,
            IdCategoria = 1,
            Imagen = "http://example.com/imagen.jpg"
        };

        Categoria categoriaMock = new Categoria
        {
            Id = 1,
            Nombre = "Categoria Test",
            Descripcion = "Descripcion de la categoria de prueba"
        };
        Producto productoMock = new Producto
        {
            Id = 1,
            Nombre = "Producto Test",
            Descripcion = "Descripcion del producto de prueba",
            Precio = 10,
            Stock = 50,
            Categoria = categoriaMock,
            Imagen = "http://example.com/imagen.jpg"
        };

        ProductoVerDTO productoVerDtoMock = new ProductoVerDTO
        {
            ProductoId = 1,
            NombreProducto = "Producto Test",
            Descripcion = "Descripcion del producto de prueba",
            Precio = 10,
            Stock = 50,
            Imagen = "http://example.com/imagen.jpg"
        };

        _mapperMock.
            Setup(m => m.Map<Producto>(productoCrearDTOMock))
            .Returns(productoMock);

        _productoServiceMock.
            Setup(service => service.CrearProducto(It.IsAny<Producto>()))
            .ReturnsAsync(productoMock);

        _mapperMock.
           Setup(m => m.Map<ProductoVerDTO>(productoMock))
           .Returns(productoVerDtoMock);

        //Act
        RespuestaGenerica<ProductoVerDTO> resultado = await _crearProductoUseCase.Crear(productoCrearDTOMock);

        ProductoVerDTO? productoVerDTO = resultado.Datos;

        //Assert
        Assert.NotNull(resultado);
        Assert.True(resultado.EsSatisfatorio);
        Assert.Equal(productoMock.Id,productoVerDTO?.ProductoId);
        Assert.Equal("Producto creado exitosamente", resultado.Mensaje);
    }
}
