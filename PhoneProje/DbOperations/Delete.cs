using System.Linq;

namespace PhoneProje.DbOperations
{
    class Delete
    {
        public void personDelete(int deleteId)
        {
            using (DataContext context = new DataContext())
            {
                var deleteData = context.Person.Where(w => w.personId == deleteId).FirstOrDefault();
                context.Person.Remove(deleteData);
                context.SaveChanges();
            }
        } 
    }
}
