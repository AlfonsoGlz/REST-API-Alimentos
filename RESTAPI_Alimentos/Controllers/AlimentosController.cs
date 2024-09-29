﻿using Microsoft.AspNetCore.Http;
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
            Task<List<Alimento>> lsAlimentos = _context.Alimentos.ToListAsync();
            return Ok(await lsAlimentos);
        }



    }
}
