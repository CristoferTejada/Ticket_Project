using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Ticket_Project.Models
{
    public class Developer : Persona, IEntity
    {
        public int Id { get; set; }
        public string Role { get; set; }
        public string Seniority { get; set; }
        public List<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
