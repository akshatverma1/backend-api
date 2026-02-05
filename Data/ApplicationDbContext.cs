using Microsoft.EntityFrameworkCore;
using StudioBackendAPI.Models;

namespace StudioBackendAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<ContactMessage> ContactMessages { get; set; }

        public DbSet<ProjectApplication> ProjectApplications { get; set; }
    }
}
