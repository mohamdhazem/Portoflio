
using DepiMvcTask1.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DepiMvcTask1.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly PortflioContext portflioContext;

        public ProjectRepository(PortflioContext portflioContext) 
        {
            this.portflioContext = portflioContext;
        }
        public List<Project> GetAll()
        {
            return portflioContext.projects.ToList();
        }

        public Project GetById(int id)
        {
            return portflioContext.projects.FirstOrDefault(p => p.id == id);
        }

        public void Add(Project project) 
        {
            portflioContext.Add(project);
        }

        public void SaveChanges()
        {
            portflioContext.SaveChanges();
        }
    }
}
