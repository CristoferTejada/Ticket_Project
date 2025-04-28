using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket_Project.Models
{
    public abstract class Persona
    {
        public string Nombre { get; set; }
        public string Genero { get; set; }
        public string Dni { get; set; }
        public string Direccion { get; set; }
        public int Edad { get; set; }
    }
}
