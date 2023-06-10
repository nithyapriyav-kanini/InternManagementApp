namespace InternLogAndTicketManagement.Interfaces
{
    public interface ITicketRepo<T,I>
    {
        public Task<T> Add(T item);
        public Task<T> Remove(I key);
        public Task<T> Get(I key);
        public Task<ICollection<T>> GetById(I key);
        public Task<ICollection<T>> GetAll();
        public Task<T> Update(T item);
    }
}
