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
      .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.NombreProducto))
      .ForMember(dest => dest.Descripcion, opt => opt.MapFrom(src => src.Descripcion))
      .ForMember(dest => dest.Precio, opt => opt.MapFrom(src => src.Precio))
      .ForMember(dest => dest.Stock, opt => opt.MapFrom(src => src.Stock))
      .ForMember(dest => dest.CategoriaId, opt => opt.MapFrom(src => src.IdCategoria))
      .ForMember(dest => dest.Imagen, opt => opt.MapFrom(src => src.Imagen))
      .ForMember(dest => dest.Activo, opt => opt.MapFrom(src => src.EsActivo));

        //Map para ver categorías

        CreateMap<Categoria, CategoriaVerDTO>()
          .ForMember(des => des.NombreCategoria, opt => opt.MapFrom(src => src.Nombre))
         .ForMember(des => des.Descripcion, opt => opt.MapFrom(src => src.Descripcion))
         .ForMember(des => des.CategoriaId, opt => opt.MapFrom(src => src.Id));


        
    }
}
