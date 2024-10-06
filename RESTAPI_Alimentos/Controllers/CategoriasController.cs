using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESTAPI_Alimentos.Models;

namespace RESTAPI_Alimentos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly API_AlimentosContext _context;

        public CategoriasController(API_AlimentosContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("listar_categorias")]
        public async Task<IActionResult> ObtenerCategorias()
        {
            Task<List<Categoria>> lsCategorias = _context.Categorias.ToListAsync();

            return Ok(await lsCategorias);
        }

        [HttpPost]
        [Route("agregar_categoria")]
        public async Task<IActionResult> AgregarCategoria(Categoria c)
        {
            await _context.Categorias.AddAsync(c);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        [Route("editar_categoria")]
        public async Task<IActionResult> EditarCategoria(Categoria c)
        {
            var categoria = await _context.Categorias.FindAsync(c.IdCategoria);

            categoria!.NombreCategoria = c.NombreCategoria;

            await _context.SaveChangesAsync();

            return Ok();
        }


    }
}
