using Microsoft.EntityFrameworkCore;
using Pomelo.Template.API.Database.Entities;

namespace Pomelo.Template.API.Database;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
}