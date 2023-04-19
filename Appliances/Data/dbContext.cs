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
    public class dbContext
    {

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

    public class Model
    {
        [Key]
        public int Id { get; set; }
        [NotNull, MaxLength(50)]
        public string Name { get; set; }
        public ICollection<Passport> Passport { get; set; }
    }

    public class Passport
    {
        [Key]
        public int Id { get; set; }
        [NotNull, MaxLength(50)]
        public string Name { get; set; }
        public int ModelId { get; set; }
        public Model Model { get; set; }
        [NotNull]
        public int Type { get; set; }
        [NotNull]
        public int Cost { get; set; }
        [NotNull]
        public DateTime DateOfIssue { get; set; }
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
