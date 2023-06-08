namespace InternUserManagement.Interfaces
{
    public interface IFunction<T>
    {
        public Task<T?> UpdatePassword(T item);
        public Task<T?> UpdateStatus(T item);
    }
}
