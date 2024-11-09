namespace DepiMvcTask1.Repository
{
    public interface IProjectRepository : IRepository<Project>
    {
        public void Add(Project project);

    }
}
