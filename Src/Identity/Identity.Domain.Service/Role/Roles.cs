using System.Data;
using Identity.Domain.Core.Bases.SeedWork;
using Identity.Domain.Service.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Domain.Service.Role;

public class Roles : AggregateRoot<Guid>
{
    public string RoleDisplayName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    
    private readonly List<Users> _users = [];
    // public IReadOnlyList<Users> Users => _users;

    private Roles(Guid id , string roleDisplayName, string description)
    {
        //validation 
        Id = id;
        RoleDisplayName = roleDisplayName;
        Description = description;
    }

    private Roles(Guid id)
    {
        Id = id;
    }

    public static Roles CreateRoles(string roleDisplayName, string description)
    {
        var roleId = Guid.NewGuid();
        return new Roles(roleId, roleDisplayName, description);
    }

    public static Roles UpdateRole(Guid id, string roleDisplayName, string description)
    {
        return new Roles(id, roleDisplayName, description);  
    }

    public static Roles DeleteRole(Guid roleId)
    {
        return new Roles(roleId);
    }

    private Roles()
    {
        
    }
    
    public class  RoleConfiguration : IEntityTypeConfiguration<Role.Roles>
    {
        public void Configure(EntityTypeBuilder<Roles> builder)
        {
            builder.Property(x => x.Id).IsRequired();
        }
    }
}