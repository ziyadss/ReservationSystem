using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ReservationSystem.Data.Users;

public class Role : IdentityRole
{
    internal static Role AdminRole = new() { Id = "Admin", Name = "Admin", NormalizedName = "ADMIN" };

    internal static Role UserRole = new() { Id = "User", Name = "User", NormalizedName = "USER" };

    internal static Role ManagerRole = new() { Id = "Manager", Name = "Manager", NormalizedName = "MANAGER" };

    internal static IReadOnlyList<Role> Roles => new List<Role> { AdminRole, UserRole, ManagerRole };

    private Role()
    {
    }
}
