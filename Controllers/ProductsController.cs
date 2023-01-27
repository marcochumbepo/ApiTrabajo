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
    public class ProductsController : Controller
    {

        private readonly conexionBD context;

        public ProductsController(conexionBD context)
        {
            this.context = context;
        }


        // GET: ProductsController
        [HttpGet]
        public IEnumerable<Products> Get()
        {
            return context.Productos.ToList();
        }

        //GET: ProductsController/Details/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                List<Products> products = new List<Products>();
                products = context.Productos.Where(x => x.producto_id == id).ToList();
                return Ok(products);

            }
            catch (Exception ex)
            {
                return BadRequest("Error " + ex.Message.ToString());
            }
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult<Products>> Create(Products product)
        {
            try
            {
                context.Productos.Add(product);
                await context.SaveChangesAsync();

                return CreatedAtAction("Get", new { id = product.producto_id }, product);
            }
            catch (Exception ex)
            {
                return BadRequest("Error " + ex.Message.ToString());
            }
        }

        // PUT: ProductsController/5
        [HttpPut("{id}")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult<Products>> Edit(int id, Products product)
        {
            try
            {
                if(product.producto_id == id)
                {
                    context.Entry(product).State = EntityState.Modified;
                    await context.SaveChangesAsync();

                    return CreatedAtAction("Get", new { id = product.producto_id }, product);
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
        public async Task<ActionResult<Products>> Delete(int id)
        {
            try
            {
                var producto = context.Productos.FirstOrDefaultAsync(p=>p.producto_id == id);
                if (producto != null) {
                    context.Productos.Remove(await producto);
                    await context.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    return NotFound();
                }

            }
            catch(Exception ex)
            {
                return BadRequest("Error: " + ex.Message.ToString());
            }
        }
    }
}
