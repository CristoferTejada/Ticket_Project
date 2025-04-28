using System;

namespace Ticket_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Inicializar repositorios y servicios
            var developerRepository = new DeveloperRepository();
            var ticketRepository = new TicketRepository();
            var commentRepository = new CommentRepository();

            var developerService = new DeveloperService(developerRepository);
            var ticketService = new TicketService(ticketRepository, developerRepository);
            var commentService = new CommentService(commentRepository, ticketRepository);

            // Crear algunos desarrolladores
            var dev1 = developerService.CreateDeveloper("Juan Perez", "Masculino", "12345678A", "Calle A, 123", 30, "Frontend", "Senior");
            var dev2 = developerService.CreateDeveloper("Maria Gomez", "Femenino", "98765432B", "Calle B, 456", 25, "Backend", "Junior");

            // Crear algunos tickets
            var ticket1 = ticketService.CreateTicket("Bug en el login", "El botón de login no funciona", "Usuario1", TicketStatus.Nuevo, Priority.Alta, TicketCategory.Bug, dev1.Id);
            var ticket2 = ticketService.CreateTicket("Nueva funcionalidad: Carrito de compras", "Implementar el carrito de compras", "Usuario2", TicketStatus.Nuevo, Priority.Media, TicketCategory.Feature, dev2.Id);

            // Crear algunos comentarios
            commentService.CreateComment(ticket1.Id, "Admin1", "Revisar logs del servidor");
            commentService.CreateComment(ticket1.Id, "dev1", "Ya lo estoy revisando");
            commentService.CreateComment(ticket2.Id, "Admin2", "Diseñar la interfaz primero");

            // Ejemplos de uso (sin manejo de errores)
            Console.WriteLine("Lista de Desarrolladores:");
            foreach (var dev in developerService.GetAllDevelopers())
            {
                Console.WriteLine($"- {dev.Nombre} ({dev.Role})");
            }

            Console.WriteLine("\nLista de Tickets:");
            foreach (var ticket in ticketService.GetTicketsByCreationDate(DateTime.Now))
            {
                Console.WriteLine($"- {ticket.Title} (Asignado a: {ticket.AssignedTo?.Nombre})");
            }

            Console.WriteLine("\nComentarios del Ticket 1:");
            foreach (var comment in commentService.GetCommentsByTicketId(ticket1.Id))
            {
                Console.WriteLine($"  - {comment.Author}: {comment.Text}");
            }

            Console.WriteLine("\nTickets del Desarrollador 1:");
            foreach (var ticket in ticketService.GetTicketsByUser(dev1.Id))
            {
                Console.WriteLine($"- {ticket.Title}");
            }

            Console.WriteLine("\nTickets por Prioridad Alta:");
            foreach (var ticket in ticketService.GetTicketsByPriority(Priority.Alta))
            {
                Console.WriteLine($"- {ticket.Title}");
            }

            // Actualizar el estado de un ticket
            ticketService.UpdateTicketStatus(ticket1.Id, TicketStatus.EnProgreso);
            Console.WriteLine($"\nEstado del Ticket 1 actualizado a: {ticketService.GetTicketById(ticket1.Id).Status}");

            // Eliminar un ticket
            ticketService.DeleteTicket(ticket2.Id);
            Console.WriteLine("\nTicket 2 eliminado");

            Console.ReadKey();
        }
    }

}