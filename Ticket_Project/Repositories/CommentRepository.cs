using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket_Project.Models;

namespace Ticket_Project.Repositories
{
    internal class CommentRepository
    {
        private readonly List<Comment> _comments = new List<Comment>();
        private int _nextId = 1;

        public void Add(Comment comment)
        {
            comment.Id = _nextId++;
            _comments.Add(comment);
        }

        public Comment GetById(int id)
        {
            return _comments.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Comment> GetAll()
        {
            return _comments;
        }

        public void Update(Comment comment)
        {
            var existingCommentIndex = _comments.FindIndex(c => c.Id == comment.Id);
            if (existingCommentIndex != -1)
            {
                _comments[existingCommentIndex] = comment;
            }
        }

        public void Delete(int id)
        {
            _comments.RemoveAll(c => c.Id == id);
        }
    }
}
