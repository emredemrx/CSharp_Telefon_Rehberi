namespace PhoneProje
{
    class Controls
    {
        public bool valueControl(string name, string number)
        {
            if (name != "" && number != "")
                return true;
            else
                return false;
        }
        public bool ubdateControl(int id)
        {
            if (id != 0)
                return true;
            else
                return false;
        }
    }
}
