namespace InternLogAndTicketManagement.Interfaces
{
    public interface ILogRepo<L,K>
    {
        Task<L> Add(L item);
        Task<ICollection<L>> GetAll();
        Task<ICollection<L>> GetByUser(K key);
    }
}
