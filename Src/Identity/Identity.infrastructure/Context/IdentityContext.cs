using Identity.Domain.Service.Role;
using Identity.Domain.Service.User;
using Microsoft.EntityFrameworkCore;

namespace Identity.infrastructure.Context;

public class IdentityContext(DbContextOptions<IdentityContext> options) : DbContext(options)
{
    public DbSet<Users> Users { get; set; }
    public DbSet<Roles> Roles { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new Roles.RoleConfiguration());
        modelBuilder.ApplyConfiguration(new Users.UserConfiguration());
    }
}