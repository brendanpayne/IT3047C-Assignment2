using System.ComponentModel.DataAnnotations.Schema;

namespace Week2.Models
{
    [Table("Employee")]
    public class Employee
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
