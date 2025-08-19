using Application.UsesCases;
using Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace msProducto.Test.UsesCases
{
    public class EliminarProductoSoftUseCaseTest
    {
        private readonly Mock<IProductoRepository> _productoServiceMock;

        private readonly EliminarProductoSoftUseCase _eliminarProductoSoftUseCase;

        public EliminarProductoSoftUseCaseTest()
        {
            _productoServiceMock = new Mock<IProductoRepository>();
            _eliminarProductoSoftUseCase = new EliminarProductoSoftUseCase(_productoServiceMock.Object);

        }

        [Fact]
        public async Task Debe_Eliminar_Producto_Exitosamente()
        {
            //Arrange
            int productoId = 7;
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

            _productoServiceMock.Setup(p => p.ObtenerProductoPorId(productoId))
                .ReturnsAsync(productoMock);

            _productoServiceMock.Setup(p => p.BorrarProductoSoft(productoMock))
                .ReturnsAsync(true);

            //Act

            RespuestaGenerica<bool> respuesta = await _eliminarProductoSoftUseCase.EliminarSoft(productoId);

            //Assert

            Assert.True(respuesta.EsSatisfatorio);
            Assert.Equal("Producto eliminado exitosamente", respuesta.Mensaje);


        }
    }
}
