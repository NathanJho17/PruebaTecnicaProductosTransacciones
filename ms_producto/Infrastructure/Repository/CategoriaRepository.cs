using Domain;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoriaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Categoria>> ListarCategorias()
        {
			try
			{
                return await _context.Categoria.ToListAsync();

            }
			catch (Exception ex)
			{

				throw new Exception("Error al cargar listado de categorías",ex);
			}
        }
    }
}
