
using DepiMvcTask1.Data;

namespace DepiMvcTask1.Repository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly PortflioContext portflioContext;

        public ServiceRepository(PortflioContext portflioContext)
        {
            this.portflioContext = portflioContext;
        }
        public List<Services> GetAll()
        {
            return portflioContext.Services.ToList();
        }

        public Services GetById(int id)
        {
            return portflioContext.Services.FirstOrDefault(s => s.Id == id);
        }

        public void SaveChanges()
        {
            portflioContext.SaveChanges();
        }
    }
}
