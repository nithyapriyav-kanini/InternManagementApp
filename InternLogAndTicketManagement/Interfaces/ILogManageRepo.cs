using InternLogAndTicketManagement.Models;

namespace InternLogAndTicketManagement.Interfaces
{
    public interface ILogManageRepo
    {
        Task<Log> InAndOut(Log item);
        Task<Log> OutTime(Log item);
        Task<ICollection<Log>> GetByUser(int key);
        Task<ICollection<Log>> GetAll();
    }
}
