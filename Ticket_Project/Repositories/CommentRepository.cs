﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket_Project.Models;
using Ticket_Project.Repositories;

namespace Ticket_Project.Repositories
{
    public class CommentService(CommentRepository commentRepository, TicketRepository ticketRepository)
    {
        private readonly CommentRepository _commentRepository = commentRepository;
        private readonly TicketRepository _ticketRepository = ticketRepository;
        public List<Comment> GetCommentsByTicketId(int ticketId)
        {
            var ticket = _ticketRepository.GetById(ticketId);
            return ticket?.Comments ?? new List<Comment>();
        }
        public Comment CreateComment(int ticketId, string author, string text)
        {
            var ticket = _ticketRepository.GetById(ticketId);
            if (ticket == null)
            {
                return null;
            }

            var newComment = new Comment
            {
                Author = author,
                Text = text,
                CreatedDate = DateTime.Now
            };

            _commentRepository.Add(newComment);
            ticket.Comments.Add(newComment);
            _ticketRepository.Update(ticket);

            return newComment;
        }

        
    }
}
