using APIInClub.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
namespace APIInClub.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrabajadoresController : Controller
    {
        [HttpGet]

        // GET: UsuariosController
        public IEnumerable<Trabajadores> Get()
        {
            return LeerArchivo();
        }


        // GET: TrabajadoresController/Details/5
        [HttpGet("{dni}")]
        public IActionResult Get(string dni)
        {
            try
            {
                List<Trabajadores> trabajadores = LeerArchivo();
                trabajadores = trabajadores.Where(x => x.dni == dni).ToList();
                return Ok(trabajadores);

            }
            catch (Exception ex)
            {
                return BadRequest("Error " + ex.Message.ToString());
            }
        }
        public List<Trabajadores> LeerArchivo()
        {
            List<Trabajadores> trabajadores = new List<Trabajadores>();
            string ruta = string.Empty;
            ruta = System.IO.File.ReadAllText(@"C:\Users\marco\Desktop\Examen_practico\data-trabajadores.csv");

            string archivo = ruta;
            foreach (string fila in archivo.Split("\n"))
            {
                double sueldo_neto = CalcularSueldo(int.Parse(fila.Split("|")[4]), int.Parse(fila.Split("|")[1]), int.Parse(fila.Split("|")[3]));
                trabajadores.Add(new Trabajadores
                {
                    dni = fila.Split("|")[0],
                    horas_laboradas = int.Parse(fila.Split("|")[1]),
                    dias_laborados = int.Parse(fila.Split("|")[2]),
                    faltas = int.Parse(fila.Split("|")[3]),
                    tipo_trabajador = int.Parse(fila.Split("|")[4]),
                    sueldo = sueldo_neto
                });
            }

            return trabajadores;
        }
        public double CalcularSueldo(int tipo_trabajador, int horas_laboradas, int faltas)
        {
            int[,] montos_calculo = new int[3, 4]
            {
                {15, 120, 130, 12},
                {35, 250, 200, 16},
                {85, 680, 350, 18}
            };


            int precio_hora = montos_calculo[tipo_trabajador, 0];
            int faltas_trabajador = montos_calculo[tipo_trabajador, 1];
            int bonificacion_trabajador = montos_calculo[tipo_trabajador, 2];
            int impuesto_trabajador = montos_calculo[tipo_trabajador, 3];

            double sueldo_bruto = (horas_laboradas * precio_hora) - (faltas * faltas_trabajador) + bonificacion_trabajador;
            double impuesto = sueldo_bruto * ((double)impuesto_trabajador / 100);
            double sueldo_neto = sueldo_bruto - impuesto;
            return sueldo_neto;
        }

    }
}
