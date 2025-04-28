using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket_Project.Models.Enums;
using Ticket_Project.Models;

namespace Ticket_Project.Services
{
    internal class TicketService
    {
        private readonly TicketRepository _ticketRepository;
        private readonly DeveloperRepository _developerRepository;

        public TicketService(TicketRepository ticketRepository, DeveloperRepository developerRepository)
        {
            _ticketRepository = ticketRepository;
            _developerRepository = developerRepository;
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

        public void UpdateTicketStatus(int ticketId, TicketStatus newStatus)
        {
            var ticket = _ticketRepository.GetById(ticketId);
            if (ticket != null)
            {
                ticket.Status = newStatus;
                ticket.LastUpdated = DateTime.Now;
                _ticketRepository.Update(ticket);
            }
        }

        public void DeleteTicket(int ticketId)
        {
            _ticketRepository.Delete(ticketId);
        }

        public List<Ticket> GetTicketsByUser(int userId)
        {
            return _ticketRepository.GetAll().Where(t => t.AssignedTo?.Id == userId).ToList();
        }

        public List<Ticket> GetTicketsByCreationDate(DateTime creationDate)
        {
            return _ticketRepository.GetAll().Where(t => t.CreatedDate.Date == creationDate.Date).ToList();
        }

        public List<Comment> GetCommentsByTicket(int ticketId)
        {
            var ticket = _ticketRepository.GetById(ticketId);
            return ticket?.Comments ?? new List<Comment>();
        }

        public List<Ticket> GetTicketsByPriority(Priority priority)
        {
            return _ticketRepository.GetAll().Where(t => t.Priority == priority).ToList();
        }

        public Ticket GetTicketById(int id)
        {
            return _ticketRepository.GetById(id);
        }
    }
}
