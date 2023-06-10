using InternLogAndTicketManagement.Models;

namespace InternLogAndTicketManagement.Interfaces
{
    public interface ITicketAndSolutionRepo
    {
        public Task<Ticket> AddTicket(Ticket ticket);
        public Task<Ticket> RemoveTicket(int id);
        public Task<Ticket> GetTicket(int id);
        public Task<Ticket> UpdateTicket(Ticket ticket);
        public Task<ICollection<Ticket>> GetTicketByUser(int id);
        public Task<ICollection<Ticket>> GetAllTicket();
        public Task<Solution> AddSolution(Solution solution);
        public Task<Solution> RemoveSolution(int id);
        public Task<Solution> GetSolution(int id);
        public Task<ICollection<Solution>> GetSolutionByUser(int id);
        public Task<Solution> UpdateSolution(Solution solution);
        public Task<ICollection<Solution>> GetAllSolution();
    }
}
