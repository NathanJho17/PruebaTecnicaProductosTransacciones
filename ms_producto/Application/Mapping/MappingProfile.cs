using Application.DTOs;
using AutoMapper;
using Domain;

namespace Application;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //Map para crear producto
        CreateMap<ProductoCrearDTO, Producto>()
           .ConstructUsing(dto => new Producto(dto.NombreProducto, dto.Descripcion, dto.Precio, dto.Stock, dto.IdCategoria, dto.Imagen));

        //Map para ver productos

        CreateMap<Producto, ProductoVerDTO>()
            .ForMember(des => des.ProductoId, opt => opt.MapFrom(src => src.Id))
           .ForMember(des => des.NombreProducto, opt => opt.MapFrom(src => src.Nombre))
           .ForMember(des => des.Descripcion, opt => opt.MapFrom(src => src.Descripcion))
           .ForMember(des => des.Imagen, opt => opt.MapFrom(src => src.Imagen))
           .ForMember(des => des.Precio, opt => opt.MapFrom(src => src.Precio))
        .ForMember(des => des.Stock, opt => opt.MapFrom(src => src.Stock))
         .ForMember(des => des.EsActivo, opt => opt.MapFrom(src => src.Activo))
         .ForMember(des => des.CategoriaProducto, opt => opt.MapFrom(src => src.Categoria));

        //Map para editar producto

        CreateMap<ProductoEditarDTO, Producto>()
         .ConstructUsing(dto => new Producto(dto.NombreProducto, dto.Descripcion, dto.Precio, dto.Stock, dto.IdCategoria, dto.Imagen, dto.EsActivo));


        //Map para ver categorías

        CreateMap<Categoria, CategoriaVerDTO>()
          .ForMember(des => des.NombreCategoria, opt => opt.MapFrom(src => src.Nombre))
         .ForMember(des => des.Descripcion, opt => opt.MapFrom(src => src.Descripcion))
         .ForMember(des => des.CategoriaId, opt => opt.MapFrom(src => src.Id));


        
    }
}
