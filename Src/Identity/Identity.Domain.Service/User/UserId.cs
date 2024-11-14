using Identity.Domain.Core.Bases.SeedWork;

namespace Identity.Domain.Service.User;

public class UserId(Guid value) : StronglyTypedId<UserId>(value);