using System.Data.Entity;
using PhoneProje.Entities;
namespace PhoneProje
{
    public class DataContext:DbContext
    {
        public DbSet<Person> Person { get; set; }
    }
}
