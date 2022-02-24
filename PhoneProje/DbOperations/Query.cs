using System.Linq;
namespace PhoneProje.DbOperations
{
    public class Query
    {
        public object EntityQuery( string queryNumber)
        {
            using (DataContext context = new DataContext())
            {
                var queryBlog = context.Person.Where(w => w.personNumber == queryNumber)
                                             .FirstOrDefault();
                return queryBlog;
                                    
            }
        }
    }
}
