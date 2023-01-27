using APIInClub.Contexts;
using APIInClub.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIInClub.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComprasController : Controller
    {
        private readonly conexionBD context;

        public ComprasController(conexionBD context)
        {
            this.context = context;
        }
        [HttpGet]

        // GET: ComprasController
        public IEnumerable<Compras> Get()
        {
            return context.Compras.ToList();
        }
        
        [HttpGet("{id}")]
        // GET: Compras/Details/5
        public IActionResult Get(int id)
        {
            try
            {
                List<Compras> compras = new List<Compras>();
                compras = context.Compras.Where(x => x.compra_codigo == id).ToList();
                return Ok(compras);

            }
            catch (Exception ex)
            {
                return BadRequest("Error " + ex.Message.ToString());
            }
        }

        // POST: Compras/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult<Compras>> Create(Compras compra)
        {
            try
            {
                context.Compras.Add(compra);
                await context.SaveChangesAsync();

                return CreatedAtAction("Get", new { id = compra.compra_codigo }, compra);
            }
            catch (Exception ex)
            {
                return BadRequest("Error " + ex.Message.ToString());
            }
        }


        [HttpPut("{id}")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult<Compras>> Edit(int id, Compras compra)
        {
            try
            {
                if (compra.compra_codigo == id)
                {
                    context.Entry(compra).State = EntityState.Modified;
                    await context.SaveChangesAsync();

                    return CreatedAtAction("Get", new { id = compra.compra_codigo }, compra);
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message.ToString());
            }
        }

        [HttpDelete("{id}")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult<Compras>> Delete(int id)
        {
            try
            {
                var compra = context.Compras.FirstOrDefaultAsync(p => p.compra_codigo == id);
                if (compra != null)
                {
                    context.Compras.Remove(await compra);
                    await context.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message.ToString());
            }
        }
    }
}
