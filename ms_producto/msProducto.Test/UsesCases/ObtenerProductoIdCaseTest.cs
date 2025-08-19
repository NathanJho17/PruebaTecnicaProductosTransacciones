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
    public class ObtenerProductoIdCaseTest
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IProductoRepository> _productoRepositoryMock;

        private readonly ObtenerProductoIdCase _obtenerProductoIdCase;

        public ObtenerProductoIdCaseTest()
        {
            _mapperMock = new Mock<IMapper>();
            _productoRepositoryMock= new Mock<IProductoRepository>();
            _obtenerProductoIdCase = new ObtenerProductoIdCase(
                _productoRepositoryMock.Object,
                _mapperMock.Object
                );
        }

        [Fact]
        public async Task Obtener_Producto_XId_Exitosamente()
        {
            //Arrange
            int productoId = 7;
            ProductoVerDTO productoVerDTOMock = new ProductoVerDTO()
            {

                NombreProducto = "Producto a editar",
                Descripcion = "Descrip",
                IdCategoria = 1,
                Imagen = "Image",
                Precio = 123,
                Stock = 7,
                EsActivo = true,
                ProductoId = productoId,
                CategoriaProducto = new CategoriaVerDTO() { NombreCategoria = "Categoria", Descripcion = "Desc" }
            };

            Producto productoMock = new Producto()
            {

                Nombre = "Producto a editar",
                Descripcion = "Descrip",
                CategoriaId = 1,
                Imagen = "Image",
                Precio = 123,
                Stock = 7,
                Activo = true
            };

            _productoRepositoryMock
                .Setup(p => p.ObtenerProductoPorId(productoId))
                .ReturnsAsync(productoMock);

         

            _mapperMock.Setup(m => m.Map<ProductoVerDTO>(productoMock))
                .Returns(productoVerDTOMock);

            //Act

            RespuestaGenerica<ProductoVerDTO> respuesta = await _obtenerProductoIdCase.ObtenerProducto(productoId);

            //Assert
            Assert.True(respuesta.EsSatisfatorio);
            Assert.Equal($"Producto {productoMock.Nombre} encontrado", respuesta.Mensaje);

        }
    }
}
