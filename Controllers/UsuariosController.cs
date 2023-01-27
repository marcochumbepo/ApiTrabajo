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
    public class UsuariosController : Controller
    {
        private readonly conexionBD context;

        public UsuariosController(conexionBD context)
        {
            this.context = context;
        }

        [HttpGet]
        // GET: UsuariosController
        public IEnumerable<Usuarios> Get()
        {
            return context.Usuarios.ToList();
        }

        [HttpGet("{id}")]
        // GET: UsuariosController/Details/5
        public IActionResult Get(int id)
        {
            try
            {
                List<Usuarios> usuarios = new List<Usuarios>();
                usuarios = context.Usuarios.Where(x => x.usuario_codigo == id).ToList();
                return Ok(usuarios);

            }
            catch (Exception ex)
            {
                return BadRequest("Error " + ex.Message.ToString());
            }
        }

        // POST: UsuariosController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult<Usuarios>> Create(Usuarios usuario)
        {
            try
            {
                context.Usuarios.Add(usuario);
                await context.SaveChangesAsync();

                return CreatedAtAction("Get", new { id = usuario.usuario_codigo }, usuario);
            }
            catch (Exception ex)
            {
                return BadRequest("Error " + ex.Message.ToString());
            }
        }

       
        [HttpPut("{id}")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult<Usuarios>> Edit(int id, Usuarios usuario)
        {
            try
            {
                if (usuario.usuario_codigo == id)
                {
                    context.Entry(usuario).State = EntityState.Modified;
                    await context.SaveChangesAsync();

                    return CreatedAtAction("Get", new { id = usuario.usuario_codigo }, usuario);
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
        public async Task<ActionResult<Usuarios>> Delete(int id)
        {
            try
            {
                var usuario = context.Usuarios.FirstOrDefaultAsync(p => p.usuario_codigo == id);
                if (usuario != null)
                {
                    context.Usuarios.Remove(await usuario);
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

        [HttpGet("{login}/{clave}")]
        public IActionResult Login(string login, string clave)
        {
            try
            {
                List<Usuarios> usuarios = new List<Usuarios>();
                usuarios = context.Usuarios.Where(x => x.usuario_login == login && x.usuario_clave == clave).ToList();
                if (usuarios == null)
                {
                    return NotFound();
                }
                return Ok(usuarios);

            }
            catch (Exception ex)
            {
                return BadRequest("Error " + ex.Message.ToString());
            }
        }

    }
}
