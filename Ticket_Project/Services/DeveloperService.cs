using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket_Project.Models;
using Ticket_Project.Repositories;

namespace Ticket_Project.Services
{
    internal class DeveloperService
    {
        private readonly DeveloperRepository _developerRepository;

        public DeveloperService(DeveloperRepository developerRepository)
        {
            _developerRepository = developerRepository;
        }

        public Developer CreateDeveloper(string nombre, string genero, string dni, string direccion,
                                           int edad, string role, string seniority)
        {
            var newDeveloper = new Developer
            {
                Nombre = nombre,
                Genero = genero,
                Dni = dni,
                Direccion = direccion,
                Edad = edad,
                Role = role,
                Seniority = seniority
            };

            _developerRepository.Add(newDeveloper);
            return newDeveloper;
        }

        public List<Developer> GetAllDevelopers()
        {
            return _developerRepository.GetAll().ToList();
        }

        public Developer GetDeveloperById(int id)
        {
            return _developerRepository.GetById(id);
        }
    }
}
