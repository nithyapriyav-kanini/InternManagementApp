using InternLogAndTicketManagement.Interfaces;
using InternLogAndTicketManagement.Models;

namespace InternLogAndTicketManagement.Services
{
    public class LogAndTicketService : ILogManageRepo
    {
        private readonly ILogRepo<Log,int> _repo;

        public LogAndTicketService(ILogRepo<Log,int> repo)
        {
            _repo = repo;
        }
        public async Task<ICollection<Log>> GetAll()
        {
            return await _repo.GetAll();
        }

        public async Task<ICollection<Log>> GetByUser(int key)
        {
            return await _repo.GetByUser(key);
        }

        public Task<Log> InAndOut(Log item)
        {
            return _repo.Add(item);
        }
    }
}
