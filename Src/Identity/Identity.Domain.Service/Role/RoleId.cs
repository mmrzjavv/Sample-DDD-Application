using System.ComponentModel.DataAnnotations;
using Identity.Domain.Core.Bases.SeedWork;

namespace Identity.Domain.Service.Role;

public class RoleId(Guid value) : StronglyTypedId<RoleId>(value);
    
