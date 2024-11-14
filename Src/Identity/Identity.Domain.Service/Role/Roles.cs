using System.Data;
using Identity.Domain.Core.Bases.SeedWork;
using Identity.Domain.Service.User;

namespace Identity.Domain.Service.Role;

public class Roles : AggregateRoot<RoleId>
{
    public string RoleDisplayName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    
    private readonly List<Users> _users = [];
    public IReadOnlyList<Users> Users => _users;

    private Roles(RoleId id , string roleDisplayName, string description)
    {
        //validation 
        Id = id;
        RoleDisplayName = roleDisplayName;
        Description = description;
    }

    private Roles(RoleId id)
    {
        Id = id;
    }

    public static Roles CreateRoles(string roleDisplayName, string description)
    {
        var roleId = new RoleId(Guid.NewGuid());
        return new Roles(roleId, roleDisplayName, description);
    }

    public static Roles UpdateRole(Guid id, string roleDisplayName, string description)
    {
        var roleId = new RoleId(id);
        return new Roles(roleId, roleDisplayName, description);  
    }

    public static Roles DeleteRole(RoleId roleId)
    {
        return new Roles(roleId);
    }

    private Roles()
    {
        
    }
}