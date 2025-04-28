using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket_Project.Models;
using Ticket_Project.Repositories;

namespace Ticket_Project.Services
{
    internal class CommentService
    {
        private readonly CommentRepository _commentRepository;
        private readonly TicketRepository _ticketRepository;

        public CommentService(CommentRepository commentRepository, TicketRepository ticketRepository)
        {
            _commentRepository = commentRepository;
            _ticketRepository = ticketRepository;
        }

        public Comment CreateComment(int ticketId, string author, string text)
        {
            var ticket = _ticketRepository.GetById(ticketId);
            if (ticket == null)
            {
                return null; // O podrías manejar esto de otra manera (e.g., retornar null, lanzar excepción)
            }

            var newComment = new Comment
            {
                Author = author,
                Text = text,
                CreatedDate = DateTime.Now
            };

            _commentRepository.Add(newComment);
            ticket.Comments.Add(newComment);
            _ticketRepository.Update(ticket); // Actualiza el ticket con el nuevo comentario

            return newComment;
        }

        public List<Comment> GetCommentsByTicketId(int ticketId)
        {
            var ticket = _ticketRepository.GetById(ticketId);
            return ticket?.Comments ?? new List<Comment>();
        }
    }
}
