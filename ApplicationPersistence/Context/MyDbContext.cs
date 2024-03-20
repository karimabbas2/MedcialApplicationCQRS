using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationDomain;
using ApplicationDomain.Concrets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
namespace ApplicationPersistence.Context
{
    public class MyDbContext(DbContextOptions<MyDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>(doctor =>
            {
                doctor.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Department>(dept =>
           {
               dept.Property(e => e.Id).ValueGeneratedOnAdd();
           });

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyDbContext).Assembly);

            modelBuilder.Entity<Department>().HasQueryFilter(d => d.DeletedBy == null);
            modelBuilder.Entity<Doctor>().HasQueryFilter(d => d.DeletedBy == null);
            modelBuilder.Entity<DoctorDepartment>().HasQueryFilter(d => d.DeletedBy == null);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorDepartment> DoctorDepartments { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Invoice> Invoices { get; set; }

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