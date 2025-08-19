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
    public class EditarProductoCaseTest
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IProductoRepository> _productoServiceMock;

        private readonly EditarProductoCase _editarProductoCase;

        public EditarProductoCaseTest()
        {
            _mapperMock = new Mock<IMapper>();  
            _productoServiceMock = new Mock<IProductoRepository>();

            _editarProductoCase = new EditarProductoCase(
                _productoServiceMock.Object,
                _mapperMock.Object
                );
        }

        [Fact]
        public async Task Debe_Editar_Producto_Exitosamente()
        {
            //Arrange
            int productoId = 7;
            ProductoEditarDTO productoEditarDTOMock = new ProductoEditarDTO()
            {

                NombreProducto = "Producto a editar",
                Descripcion = "Descrip",
                IdCategoria = 1,
                Imagen = "Image",
                Precio = 123,
                Stock = 7,
                EsActivo = true
            };

            ProductoVerDTO productoVerDTOMock = new ProductoVerDTO()
            {

                NombreProducto = "Producto a editar",
                Descripcion = "Descrip",
                IdCategoria = 1,
                Imagen = "Image",
                Precio = 123,
                Stock = 7,
                EsActivo = true,
                ProductoId=productoId,
                CategoriaProducto=new CategoriaVerDTO() { NombreCategoria="Categoria",Descripcion="Desc"}
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

            _productoServiceMock
                .Setup(p => p.ObtenerProductoPorId(productoId))
                .ReturnsAsync(productoMock);

            _mapperMock.Setup(m => m.Map<Producto>(productoEditarDTOMock))
                 .Returns(productoMock);

            _productoServiceMock.Setup(p => p.EditarProducto(productoMock))
                .ReturnsAsync(productoMock);

            _mapperMock.Setup(m => m.Map<ProductoVerDTO>(productoMock))
                .Returns(productoVerDTOMock);

            //Act

            RespuestaGenerica<ProductoVerDTO> respuesta = await _editarProductoCase.Editar(productoId, productoEditarDTOMock);

            //Assert
            Assert.True(respuesta.EsSatisfatorio);
            Assert.Equal("Producto editado exitosamente",respuesta.Mensaje);



        }

    }
}
