namespace APIInClub.Models
{
    public class Trabajadores
    {
        public string dni { get; set; }
        public int horas_laboradas { get; set; }
        public int dias_laborados { get; set; }
        public int faltas { get; set; }
        public int tipo_trabajador { get; set; }
        public double sueldo { get; set; }
    }
}
