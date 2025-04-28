using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket_Project.Models;

namespace Ticket_Project.Repositories
{
    internal class DeveloperRepository
    {
        private readonly List<Developer> _developers = new List<Developer>();
        private int _nextId = 1;

        public void Add(Developer developer)
        {
            developer.Id = _nextId++;
            _developers.Add(developer);
        }

        public Developer GetById(int id)
        {
            return _developers.FirstOrDefault(d => d.Id == id);
        }

        public IEnumerable<Developer> GetAll()
        {
            return _developers;
        }

        public void Update(Developer developer)
        {
            var existingDeveloperIndex = _developers.FindIndex(d => d.Id == developer.Id);
            if (existingDeveloperIndex != -1)
            {
                _developers[existingDeveloperIndex] = developer;
            }
        }

        public void Delete(int id)
        {
            _developers.RemoveAll(d => d.Id == id);
        }
    }
}
