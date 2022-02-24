using PhoneProje.Entities;

namespace PhoneProje.DbOperations
{
    class AddData
    {
        Controls controls = new Controls();
        Query query = new Query();
        Decision decision = new Decision();

        public string Add(string name, string number)
        {
           
            bool addControl = controls.valueControl(name,number); //degerlerin boş olup olmadığının kontrolü

            object decisionValue = query.EntityQuery(number); // veri tabanı sorgusuna verileri gönderiyorum

            string decisionMessage = decision.AddUpdateDecision(name,number,(Person)decisionValue).ToString(); // add veya update kararı için AddUpdateDecision methoduna verileri gönderiyorum
            
            return PersonAdd(name, number, decisionMessage, addControl);
        }

        Person adding = new Person();
        private string PersonAdd(string name, string number, string decisionMessage, bool addControl)
        {
            if (decisionMessage == "add")
            {
                if (addControl == true)
                {
                    using (DataContext context = new DataContext())
                    {
                        adding.personName = name;
                        adding.personNumber = number;
                        context.Person.Add(adding);
                        context.SaveChanges();
                    }
                    return "Eklendi";
                }
                else
                {
                    return "Ad ve Numara Giriniz";
                }
            }
            else
            {
                return "Var Olan Kayıt Güncellendi";
            }
        }
    }
}
