using Microsoft.AspNetCore.Identity;
using ApplicationPersistence.SeedData.Roles;
using Microsoft.EntityFrameworkCore;

namespace ApplicationPersistence.SeedData
{
    public static class SeedData
    {
        public static void InsertRoles(this ModelBuilder modelBuilder)
        {
            HashSet<IdentityRole> roles = [];

            roles.Add(new IdentityRole()
            {
                Name = AppRoles.ADMIN,
                NormalizedName = AppRoles.ADMIN.ToUpper()
            });

            roles.Add(new IdentityRole()
            {
                Name = AppRoles.CLIENT,
                NormalizedName = AppRoles.CLIENT.ToUpper()
            });

            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }

    }
}