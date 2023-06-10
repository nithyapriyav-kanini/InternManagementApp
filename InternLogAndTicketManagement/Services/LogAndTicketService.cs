using InternLogAndTicketManagement.Interfaces;
using InternLogAndTicketManagement.Models;

namespace InternLogAndTicketManagement.Services
{
    public class LogAndTicketService : ILogManageRepo, ITicketAndSolutionRepo
    {
        private readonly ILogRepo<Log,int> _repo;
        private readonly ITicketRepo<Ticket, int> _ticketrepo;
        private readonly ITicketRepo<Solution, int> _solutionrepo;

        public LogAndTicketService(ILogRepo<Log,int> repo, ITicketRepo<Ticket, int> ticketrepo, ITicketRepo<Solution, int> solutionrepo)
        {
            _repo = repo;
            _ticketrepo = ticketrepo;
            _solutionrepo = solutionrepo;
        }

        //solution
        public async Task<Solution> AddSolution(Solution solution)
        {
            return await _solutionrepo.Add(solution);
        }
        public async Task<Solution> GetSolution(int id)
        {
            return await _solutionrepo.Get(id);
        }
        public async Task<ICollection<Solution>> GetSolutionByUser(int id)
        {
            return await _solutionrepo.GetById(id);
        }
        public async Task<Solution> RemoveSolution(int id)
        {
            return await _solutionrepo.Remove(id);
        }
        public async Task<Solution> UpdateSolution(Solution solution)
        {
            return await _solutionrepo.Update(solution);
        }
        public async Task<ICollection<Solution>> GetAllSolution()
        {
            return await _solutionrepo.GetAll();
        }

        //ticket
        public async Task<Ticket> AddTicket(Ticket ticket)
        {
            return await _ticketrepo.Add(ticket);
        }

        public async Task<ICollection<Ticket>> GetAllTicket()
        {
            return await _ticketrepo.GetAll();
        }
        public async Task<Ticket> GetTicket(int id)
        {
            return await _ticketrepo.Get(id);
        }

        public async Task<ICollection<Ticket>> GetTicketByUser(int id)
        {
            return await _ticketrepo.GetById(id);
        }
        public async Task<Ticket> RemoveTicket(int id)
        {
            return await _ticketrepo.Remove(id);
        }

        public async Task<Ticket> UpdateTicket(Ticket ticket)
        {
            return await _ticketrepo.Update(ticket);
        }

        //Log
        public Task<Log> InAndOut(Log item)
        {
            return _repo.Add(item);
        }
        public async Task<ICollection<Log>> GetAll()
        {
            return await _repo.GetAll();
        }
        public async Task<ICollection<Log>> GetByUser(int key)
        {
            return await _repo.GetByUser(key);
        }
    }
}
