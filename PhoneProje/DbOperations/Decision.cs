using PhoneProje.Entities;
namespace PhoneProje.DbOperations
{
    public class Decision
    {
        UpdateData update = new UpdateData();
        public string AddUpdateDecision(string name, string number, Person queryBlog)
        {
            if (queryBlog != null)
            {
                update.personUpdate(queryBlog.personId, name, number);
                return "update";
            }
            else
            {
                return "add";
            }
        }
    }
}
