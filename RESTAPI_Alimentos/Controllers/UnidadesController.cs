using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESTAPI_Alimentos.Models;

namespace RESTAPI_Alimentos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadesController : ControllerBase
    {
        private readonly API_AlimentosContext _context;

        public UnidadesController(API_AlimentosContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("listar_unidades")]
        public async Task<IActionResult> ObtenerUnidades()
        {
            Task<List<Unidad>> lsUnidades = _context.Unidad.ToListAsync();

            return Ok(await lsUnidades);
        }

        [HttpPost]
        [Route("agregar_unidad")]
        public async Task<IActionResult> AgregarUnidad(Unidad u)
        {
            await _context.Unidad.AddAsync(u);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        [Route("editar_unidad")]
        public async Task<IActionResult> EditarUnidad(Unidad u)
        {
            var unidad = await _context.Unidad.FindAsync(u.IdUnidad);

            unidad!.NombreUnidad = u.NombreUnidad;
            await _context.SaveChangesAsync();

            return Ok();

        }


    }
}
