using System.ComponentModel.DataAnnotations;

namespace Service.Types
{
    public class Person
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }

        public Person()
        {
            Id = Guid.NewGuid();
            CreateDate = DateTime.Now;
        }

        public Person(string firstName, string lastName)
            : this()
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString()
        {
            return $"{Id} | {LastName}, {FirstName}";
        }
    }
}