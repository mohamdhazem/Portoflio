namespace DepiMvcTask1.Repository
{
    public interface IRepository<T>
    {
        public List<T> GetAll();
        public T GetById(int id);
        public void SaveChanges();

    }
}
