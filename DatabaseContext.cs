using FinalWindow.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWindow.Database
{
    class DatabaseContext : DbContext
    {

        public DatabaseContext() : base("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=DSFinal;Integrated Security=True")
        {
        }

        public DbSet<Facility> Facilities { get; set; }
        public DbSet<BillFix> BillFixes { get; set; }
        public DbSet<Rule> Rules { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<FeeKeep> FeeKeeps { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Revenue> Revenues { get; set; }
        public DbSet<BaseSalary> BaseSalaries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Director>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Directors");
            });

            modelBuilder.Entity<Manager>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Managers");
            });

            modelBuilder.Entity<Customer>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Customers");
            });

            modelBuilder.Entity<FixWorker>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("FixWorkers");
            });

            modelBuilder.Entity<KeepWorker>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("KeepWorkers");
            });

            modelBuilder.Entity<DayKeepContract>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("DayKeepContracts");
            });



            modelBuilder.Entity<LoanContract>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("LoanContracts");
            });

            modelBuilder.Entity<LongTermKeepContract>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("LongTermKeepContracts");
            });


            modelBuilder.Entity<Car>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Cars");
            });

            modelBuilder.Entity<Motor>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Motors");
            });

            modelBuilder.Entity<Truck>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Trucks");
            });
        }



    }

}
