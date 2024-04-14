using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationDomain;
using ApplicationDomain.Concrets;
using ApplicationPersistence.SeedData;
using ApplicationPersistence.SeedData.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
namespace ApplicationPersistence.Context
{
    public class MyDbContext(DbContextOptions<MyDbContext> options) : IdentityDbContext<User, IdentityRole, string>(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyDbContext).Assembly);

            modelBuilder.InsertRoles();

            modelBuilder.Entity<Department>().HasQueryFilter(d => d.DeletedBy == null)
            .HasMany(D => D.DoctorDepartments)
            .WithOne(d => d.Department)
            .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Doctor>().HasQueryFilter(d => d.DeletedBy == null)
            .HasMany(D => D.DoctorDepartments)
            .WithOne(d => d.Doctor)
            .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
        public override DbSet<User> Users { get; set; }
        public override DbSet<IdentityRole> Roles { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorDepartment> DoctorDepartments { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentInovice> AppointmentInovice { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>())
            {

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.Now;
                }
                if (entry.State == EntityState.Deleted)
                {
                    entry.Entity.DeletedAt = DateTime.Now;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

    }
}