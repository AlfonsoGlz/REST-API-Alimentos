using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RESTAPI_Alimentos.Models;

namespace RESTAPI_Alimentos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlimentosController : ControllerBase
    {
        //Inyeccion del contexto
        private readonly API_AlimentosContext _context;

        //Constructor
        public AlimentosController(API_AlimentosContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("listar_todo")]
        public async Task<IActionResult> ListarTodo()
        {
            Task<List<Alimento>> lsAlimentos = _context.Alimentos.Include("Unidad").ToListAsync();
            return Ok(await lsAlimentos);
        }

        [HttpPost]
        [Route("agregar_alimento")]
        public async Task<IActionResult> AgregarAlimento(Alimento a)
        {
            await _context.Alimentos.AddAsync(a);
            await _context.SaveChangesAsync();

            return Ok();  
        }

        [HttpPut]
        [Route("editar_alimento")]
        public async Task<IActionResult> EditarAlimento(Alimento a)
        {
            var alimentoExsistente = await _context.Alimentos.FindAsync(a.IdAlimentos);

            alimentoExsistente!.NombreAlimento = a.NombreAlimento;
            alimentoExsistente.Cantidad = a.Cantidad;
            alimentoExsistente.Calorias = a.Calorias;
            alimentoExsistente.Proteinas = a.Proteinas;
            alimentoExsistente.Carbohidratos = a.Carbohidratos;
            alimentoExsistente.Grasas = a.Grasas;
            alimentoExsistente.Fibra = a.Fibra;
            alimentoExsistente.Sodio = a.Sodio;
            alimentoExsistente.CategoriaId = a.CategoriaId;
            alimentoExsistente.UnidadId = a.UnidadId;

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        [Route("eliminar_alimento/{id}")]
        public async Task<IActionResult> EliminarAlimento(int id)
        {
            var alimento = await _context.Alimentos.FindAsync(id);
            _context.Alimentos.Remove(alimento!);

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        [Route("obtener_alimentoId/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var alimento = _context.Alimentos.FindAsync(id);

            return Ok(await alimento);
        }




    }
}
