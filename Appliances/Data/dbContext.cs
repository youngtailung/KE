using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appliances.Data
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Passport> Passports { get; set; }
        public DbSet<MainContract> MainContracts { get; set; }
        public DbSet<ExtensionContract> ExtensionContracts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasData(GetPosts());
            modelBuilder.Entity<Employee>().HasData(GetEmployees());
            modelBuilder.Entity<Type>().HasData(GetTypes());
            modelBuilder.Entity<Passport>().HasData(GetPassports());
            modelBuilder.Entity<Customer>().HasData(GetCustomers());
            modelBuilder.Entity<MainContract>().HasData(GetMainContracts());
            base.OnModelCreating(modelBuilder);
        }
        private Post[] GetPosts()
        {
            return new Post[]
            {
                new Post { Id = 1, Name = "Руководитель фирмы" },
                new Post { Id = 2, Name = "Руководитель отдела" },
                new Post { Id = 3, Name = "Сотрудник технического отдела" },
                new Post { Id = 4, Name = "Сотрудник отдела по работе с клиентами" }
            };
        }
        private Employee[] GetEmployees()
        {
            return new Employee[]
            {
                new Employee { Id = 1, FirstName = "Давид", LastName = "Градинарь", Login = "admin", Password = "admin", PostId = 1 },
                new Employee { Id = 2, FirstName = "Роман", LastName = "Воробьёв", Login = "emp", Password = "emo", PostId = 2 },
                new Employee { Id = 3, FirstName = "dadasd", LastName = "sdger", Login = "to", Password = "to", PostId = 3 },
                new Employee { Id = 4, FirstName = "gfddcv", LastName = "nfg", Login = "cs", Password = "cs", PostId = 4 },
            };
        }
        private Type[] GetTypes()
        {
            return new Type[]
            {
                new Type { Id = 1, Name = "Стиральная машина" },
                new Type { Id = 2, Name = "Холодильник" },
                new Type { Id = 3, Name = "Морозильная камера" },
            };
        }
        private Passport[] GetPassports()
        {
            return new Passport[]
            {
                new Passport { Id = 1, Name = "Calgon 12", Model = "IX-1C21", TypeId = 1, Cost = 43000, DateOfIssue = new DateTime(2008, 5, 1, 8, 30, 52) },
            };
        }
        private Customer[] GetCustomers()
        {
            return new Customer[]
            {
                new Customer { Id = 1, FirstName = "Витя", LastName = "Жгутин", PassportSerial = "5612", PassportNumber = "352312", Address = "Челябинская область, город Пушкино, пл. Бухарестская, 34" },
            };
        }
        private MainContract[] GetMainContracts()
        {
            return new MainContract[]
            {
                new MainContract { Id = 1, EmployeeId = 2, CustomerId = 1, PassportId = 1, DateOfConfirmation = new DateTime(2010, 2, 3, 8, 30, 52), DateOfBeginning = new DateTime(2010, 2, 6, 10, 30, 00), DateOfEnding = new DateTime(2010, 8, 6, 10, 30, 00)},
            };
        }
    }


    public class Post
    {
        [Key]
        public int Id { get; set; }
        [NotNull, MaxLength(50)]
        public string Name { get; set; }
        public ICollection<Employee> Employee { get; set; }
    }
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [NotNull, MaxLength(50)]
        public string FirstName { get; set; }
        [NotNull, MaxLength(50)]
        public string LastName { get; set; }
        [NotNull, MaxLength(50)]
        public string Login { get; set; }
        public string Password { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
        public ICollection<MainContract> Contracts { get; set; }
        public ICollection<ExtensionContract> ExtensionContracts { get; set; }
    }
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [NotNull, MaxLength(50)]
        public string FirstName { get; set; }
        [NotNull, MaxLength(50)]
        public string LastName { get; set; }
        [NotNull, MaxLength(4)]
        public string PassportSerial { get; set; }
        [NotNull, MaxLength(6)]
        public string PassportNumber { get; set; }
        [NotNull, MaxLength(150)]
        public string Address { get; set; }
        public ICollection<MainContract> Contracts { get; set; }
        public ICollection<ExtensionContract> ExtensionContracts { get; set; }

    }
    public class Type
    {
        [Key]
        public int Id { get; set; }
        [NotNull, MaxLength(50)]
        public string Name { get; set; }
        public ICollection<Passport> Passports { get; set; }
    }
    public class Passport
    {
        [Key]
        public int Id { get; set; }
        [NotNull, MaxLength(50)]
        public string Name { get; set; }
        [NotNull, MaxLength(50)]
        public string Model { get; set; }
        public int TypeId { get; set; }
        public virtual Type Type { get; set; }
        [NotNull]
        public int Cost { get; set; }
        [NotNull]
        public DateTime DateOfIssue { get; set; }
        public ICollection<MainContract> MainContracts { get; set; }
    }
    public class MainContract
    {
        [Key]
        public int Id { get; set; }
        [NotNull]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        [NotNull]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }  
        public int PassportId { get; set; }
        public virtual Passport Passport { get; set; }
        [NotNull]
        public DateTime DateOfConfirmation { get; set; }
        [NotNull]
        public DateTime DateOfBeginning { get; set; }
        [NotNull]
        public DateTime DateOfEnding { get; set; }
    }
    public class ExtensionContract
    {
        [Key]
        public int Id { get; set; }
        [NotNull]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        [NotNull]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        [NotNull]
        public DateTime DateOfConfirmation { get; set; }
    }
    
}
