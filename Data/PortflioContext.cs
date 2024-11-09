using DepiMvcTask1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DepiMvcTask1.Data
{
    public class PortflioContext : IdentityDbContext
    {
        private readonly DbContextOptions<PortflioContext> options;

        public PortflioContext(DbContextOptions<PortflioContext> options) : base(options) 
        {
            this.options = options;
        }

        public DbSet<MyInfo> MyInfo { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<ContactData> contactData { get; set; }
        public DbSet<Project> projects { get; set; }

    }
}
