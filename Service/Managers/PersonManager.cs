using Service.Database;
using Service.Types;

namespace Service.Managers
{
    public class PersonManager
    {
        public static List<Person> Load()
        {
            using var context = new MyDbContext();
            return [.. context.Persons];
        }

        public static Person? Load(Guid id)
        {
            using var context = new MyDbContext();
            return context.Persons.FirstOrDefault(person => person.Id == id);
        }

        public static bool Exists(Guid id)
        {
            using var context = new MyDbContext();
            // Convert the Guid to string before comparison due to sqlite database TEXT column.
            return context.Persons.Any(person => person.Id == id);
        }

        public static Person Save(Person person)
        {
            Person result = person;

            using var context = new MyDbContext();
            var existingPerson = context.Persons.Find(person.Id);
            if (existingPerson != null)
            {
                existingPerson.FirstName = person.FirstName;
                existingPerson.LastName = person.LastName;
                result = existingPerson;
            }
            else
            {
                context.Persons.Add(person);
            }

            context.SaveChanges();

            return result;
        }
    }
}