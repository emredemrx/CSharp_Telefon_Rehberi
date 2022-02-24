using PhoneProje.Entities;
using System.Linq;

namespace PhoneProje.DbOperations
{
    class UpdateData
    {
        Controls controls = new Controls();
        public string personUpdate(int personid, string name, string number)
        {
            bool updateControl = controls.ubdateControl(personid);
            string updateMessage = UpdateQuery(personid, name, number, updateControl);
            return updateMessage;
        }

        private string UpdateQuery(int personid, string name, string number, bool updateControl)
        {
            if (updateControl == true)
            {
                using (DataContext context = new DataContext())
                {
                    var upd = context.Person.Where(w => w.personId == personid).FirstOrDefault();
                    upd.personName = name;
                    upd.personNumber = number;
                    context.SaveChanges();
                }
                return "Kişi Güncellendi";
            }
            else
            {
                return "Kişi Seçmelisin";
            }
        }
    }
}
