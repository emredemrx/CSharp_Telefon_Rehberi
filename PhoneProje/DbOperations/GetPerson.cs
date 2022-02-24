using PhoneProje.Entities;
using System.Collections.Generic;
using System.Linq;

namespace PhoneProje.DbOperations
{
    public class GetPerson
    {
        public List<Person> GetAll()
        {
            using (DataContext context = new DataContext())
            {
               return context.Person.ToList();
            }
        }
    }
}
