using Microsoft.EntityFrameworkCore;
using NamePicker.Entities;

namespace NamePicker.Api.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        public virtual DbSet<User> GetUsers {  get; set; }
    }
}
