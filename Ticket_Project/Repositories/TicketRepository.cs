using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket_Project.Models;
using Ticket_Project.Models.Enums;
using Ticket_Project.Repositories;

namespace Ticket_Project.Repositories
{
    public class TicketRepository
    {
        private readonly TicketRepository _ticketRepository;
        private readonly DeveloperRepository _developerRepository;

        

        private readonly List<Ticket> _tickets = new List<Ticket>();
        private int _nextId = 1;

        public void Add(Ticket ticket)
        {
            ticket.Id = _nextId++;
            _tickets.Add(ticket);
        }

        public Ticket GetById(int id)
        {
            return _tickets.FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<Ticket> GetAll()
        {
            return _tickets;
        }

        public void Update(Ticket ticket)
        {
            var existingTicketIndex = _tickets.FindIndex(t => t.Id == ticket.Id);
            if (existingTicketIndex != -1)
            {
                _tickets[existingTicketIndex] = ticket;
            }
        }

        public void Delete(int id)
        {
            _tickets.RemoveAll(t => t.Id == id);
        }
        public Ticket CreateTicket(string title, string description, string reportedBy,
                               TicketStatus status, Priority priority, TicketCategory category,
                               int assignedToDeveloperId)
        {
            var developer = _developerRepository.GetById(assignedToDeveloperId);

            var newTicket = new Ticket
            {
                Title = title,
                Description = description,
                ReportedBy = reportedBy,
                Status = status,
                Priority = priority,
                Category = category,
                CreatedDate = DateTime.Now,
                AssignedTo = developer
            };

            _ticketRepository.Add(newTicket);
            return newTicket;
        }
    }
}
