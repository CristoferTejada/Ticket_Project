using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Ticket_Project.Models.Interfaces;

namespace Ticket_Project.Models
{
    public class Ticket : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public TicketStatus Status { get; set; }
        public Priority Priority { get; set; }
        public TicketCategory Category { get; set; }
        public string ReportedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastUpdated { get; set; }
        public Developer AssignedTo { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
