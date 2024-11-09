
using DepiMvcTask1.Data;

namespace DepiMvcTask1.Repository
{
    public class MyInfoRepository : IMyInfoRepository
    {
        private readonly PortflioContext portflioContext;
        public MyInfoRepository(PortflioContext portflioContext) 
        {
            this.portflioContext = portflioContext;
        }
        public List<MyInfo> GetAll()
        {
            return portflioContext.MyInfo.ToList();
        }

        public MyInfo GetById(int id)
        {
            return portflioContext.MyInfo.FirstOrDefault(i => i.Id == id);
        }

        public void SaveChanges()
        {
            portflioContext.SaveChanges();
        }
    }
}
