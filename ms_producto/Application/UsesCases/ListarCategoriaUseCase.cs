using Application.DTOs;
using AutoMapper;
using Domain;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UsesCases
{
    public class ListarCategoriaUseCase
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public ListarCategoriaUseCase(ICategoriaRepository categoriaRepository,IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task<RespuestaGenerica<List<CategoriaVerDTO>>> ListarCategorias()
        {
            try
            {
                List<Categoria> categorias = await _categoriaRepository.ListarCategorias();
                var mapCategorias = _mapper.Map<List<CategoriaVerDTO>>(categorias);
                return new RespuestaGenerica<List<CategoriaVerDTO>>($"Total categorías obtenidos {mapCategorias.Count}", true, mapCategorias);
            }
            catch (Exception ex)
            {

                return new RespuestaGenerica<List<CategoriaVerDTO>>(ex.Message,false,null);
            }
        }
    }
}
