using API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class DataContext  : IdentityDbContext<User, Role, int,IdentityUserClaim<int>,
        UserRole,IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DataContext (DbContextOptions <DataContext> options) :
            base (options) { }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            base.OnModelCreating(builder);

            builder.Entity<User>()
                .HasMany(ur => ur.userRoles)
                .WithOne(u => u.user)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

            builder.Entity<Role>()
                .HasMany(ur => ur.userRoles)
                .WithOne(u => u.role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();
        }


     }
}
