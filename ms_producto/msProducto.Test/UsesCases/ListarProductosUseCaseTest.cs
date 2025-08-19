using Application.DTOs;
using Application.UsesCases;
using AutoMapper;
using Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace msProducto.Test.UsesCases
{
    public class ListarProductosUseCaseTest
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IProductoRepository> _productoServiceMock;
        private readonly ListarProductosUseCase _listaProductosUseCase;
        public ListarProductosUseCaseTest()
        {
            _mapperMock = new Mock<IMapper>();
            _productoServiceMock = new Mock<IProductoRepository>();

            _listaProductosUseCase = new ListarProductosUseCase(
                _productoServiceMock.Object,
                _mapperMock.Object
                );
        }


        [Fact]
        public async Task Debe_Retornar_Listado_Productos__Exitosamente_Paginado()
        {
            //Arrange
            int offset = 7;
            int limit = 10;
            List<ProductoVerDTO> productoVerDTOs = new List<ProductoVerDTO>()
            {
                new ProductoVerDTO()
                {
                     ProductoId = 1,
                    NombreProducto = "Producto Test",
                    Descripcion = "Descripcion del producto de prueba",
                    Precio = 10,
                    Stock = 50,
                    Imagen = "http://example.com/imagen.jpg",
                    CategoriaProducto= new CategoriaVerDTO{NombreCategoria="Test",Descripcion="Descripción 1"},
                    EsActivo=true
                 },
                 new ProductoVerDTO()
                {
                    ProductoId = 2,
                    NombreProducto = "Producto Test 2",
                    Descripcion = "Descripcion del producto de prueba",
                    Precio = 120,
                    Stock = 503,
                    Imagen = "http://example.com/imagen.jpg",
                     CategoriaProducto= new CategoriaVerDTO{NombreCategoria="Test",Descripcion="Descripción 2"},
                       EsActivo=true
                 },
                  new ProductoVerDTO()
                  {
                    ProductoId = 3,
                    NombreProducto = "Producto Test",
                    Descripcion = "Descripcion del producto de prueba",
                    Precio = 10,
                    Stock = 50,
                    Imagen = "http://example.com/imagen.jpg",
                     CategoriaProducto= new CategoriaVerDTO{NombreCategoria="Test",Descripcion="Descripción 3"},
                       EsActivo=true
                 },
                   new ProductoVerDTO()
                   {
                    ProductoId = 3,
                    NombreProducto = "Producto Test 3",
                    Descripcion = "Descripcion del producto de prueba 3",
                    Precio = 10,
                    Stock = 50,
                    Imagen = "http://example.com/imagen.jpg",
                     CategoriaProducto= new CategoriaVerDTO{NombreCategoria="Test",Descripcion="Descripción 4"},
                       EsActivo=true
                 },
            };

            _productoServiceMock.
                Setup(p => p.ListarProductos(offset, limit))
                .ReturnsAsync(It.IsAny<List<Producto>>());

            _mapperMock.Setup(m => m.Map<List<ProductoVerDTO>>(It.IsAny<List<Producto>>()))
                .Returns(productoVerDTOs);

            //Act

            RespuestaGenerica<List<ProductoVerDTO>>resultado = await _listaProductosUseCase.Listar(offset, limit);

            //Assert

            Assert.NotNull(resultado);
            Assert.True(resultado.EsSatisfatorio);
            Assert.Equal($"Total productos obtenidos {resultado.Datos.Count}", resultado.Mensaje);

        }
    }
}
