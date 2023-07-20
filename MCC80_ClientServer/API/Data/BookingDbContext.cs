using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class BookingDbContext : DbContext
    {
        public BookingDbContext(DbContextOptions<BookingDbContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountRole> AccountRole { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<University> Universities { get; set; }

        //menambahkan uniq 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>()
                        .HasIndex(e => new
                        {
                            e.Nik,
                            e.Email,
                            e.PhoneNumber
                        }).IsUnique();

            //Many education with one university (N:1) / Manggil Class
            /*modelBuilder.Entity<Education>()
                        .HasOne(e => e.University)
                        .WithMany(u => u.Educations)
                        .HasForeignKey(u => u.UniversityGuid);*/
            //Cardinality
            // University with many education (1:N) / ICollection
            modelBuilder.Entity<University>()
                        .HasMany(u => u.Educations)
                        .WithOne(e => e.University)
                        .HasForeignKey(e => e.UniversityGuid);

            //Many booking with one room (N:1)
            modelBuilder.Entity<Booking>()
                        .HasOne(b => b.Room)
                        .WithMany(r => r.Bookings)
                        .HasForeignKey(b => b.RoomGuid);

            //Many booking with one employee (N:1)
            modelBuilder.Entity<Booking>()
                        .HasOne(b => b.Employee)
                        .WithMany(e => e.Bookings)
                        .HasForeignKey(b => b.EmployeeGuid);

            //One education with one employee (1:1)
            modelBuilder.Entity<Education>()
                        .HasOne(em => em.Employee)
                        .WithOne(ed => ed.Education)
                        .HasForeignKey<Education>(ed => ed.Guid);

            //One Employee with one accounts (1:1)
            modelBuilder.Entity<Employee>()
                        .HasOne(a => a.Account)
                        .WithOne(e => e.Employee)
                        .HasForeignKey<Account>(a => a.Guid);

            //Many accountrole with one role(N:1)
            modelBuilder.Entity<AccountRole>()
                        .HasOne(a => a.Role)
                        .WithMany(r => r.AccountRoles)
                        .HasForeignKey(a => a.RoleGuid);

            //Many accountrole with one account (N:1)
            modelBuilder.Entity<AccountRole>()
                        .HasOne(a => a.Account)
                        .WithMany(ar => ar.AccountRoles)
                        .HasForeignKey(ar => ar.AccountGuid);
        }
    }    
}