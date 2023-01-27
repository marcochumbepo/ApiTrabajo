using APIInClub.Contexts;
using APIInClub.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIInClub.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DetalleComprasController : Controller
    {
        private readonly conexionBD context;

        public DetalleComprasController(conexionBD context)
        {
            this.context = context;
        } 

        [HttpGet("{usuario}")]
        // GET: DetalleCompras/mchumbe
        public async Task<List<DetalleCompras>> Get(string usuario)
        {
                var detalles = context.Detalles
                                .FromSqlInterpolated($"EXEC usp_sel_DetalleCompra @usuario={usuario}")
                                .AsAsyncEnumerable();
                List<DetalleCompras> detalleCompras = new List<DetalleCompras>();

                await foreach(var detalle in detalles)
                {
                    detalleCompras.Add(detalle);
                }
                return detalleCompras;
        }
    }
}
