using Microsoft.AspNetCore.Identity;
using System;

namespace CleanArchitecture1.Infrastructure.Identity.Models
{
    public class ApplicationRole(string name) : IdentityRole<Guid>(name)
    {
    }
}
