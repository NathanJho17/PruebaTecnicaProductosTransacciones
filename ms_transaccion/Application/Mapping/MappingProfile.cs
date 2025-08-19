using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<TransaccionCrearDTO, Transaccion>()
            .ConstructUsing(dto => new Transaccion(Guid.NewGuid(), dto.TipoTransaccion.ToString(), dto.ProductoId, dto.Cantidad, dto.PrecioUnitario, dto.Detalle));

            CreateMap<Transaccion, TransaccionVerDTO>()
                .ForMember(des => des.Detalle, or => or.MapFrom(src => src.Detalle))
                .ForMember(des => des.EsActivo, or => or.MapFrom(src => src.Activo))
                .ForMember(des => des.FechaCreacion, or => or.MapFrom(src => src.FechaCreacion))
                .ForMember(des => des.Cantidad, or => or.MapFrom(src => src.Cantidad))
                .ForMember(des => des.IdentificadorUnico, or => or.MapFrom(src => src.Id))
                .ForMember(des => des.PrecioUnitario, or => or.MapFrom(src => src.PrecioUnitario))
                .ForMember(des => des.PrecioTotal, or => or.MapFrom(src => src.PrecioTotal))
                 .ForMember(des => des.TipoTransaccion, or => or.MapFrom(src => src.Tipo));


            CreateMap<TransaccionEditarDTO, Transaccion>()
               .ForMember(des => des.Detalle, or => or.MapFrom(src => src.Detalle))
               .ForMember(des => des.Activo, or => or.MapFrom(src => src.EsActivo))
               .ForMember(des => des.Cantidad, or => or.MapFrom(src => src.Cantidad))
               .ForMember(des => des.PrecioUnitario, or => or.MapFrom(src => src.PrecioUnitario))
                .ForMember(des => des.Tipo, or => or.MapFrom(src => src.TipoTransaccion));
        }
    }
}
