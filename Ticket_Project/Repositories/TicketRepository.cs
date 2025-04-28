using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket_Project.Models;

namespace Ticket_Project.Repositories
{
    internal class TicketRepository
    {
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
    }
}
