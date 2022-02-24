using PhoneProje.DbOperations;
using System;
using System.Windows.Forms;
namespace PhoneProje
{
    public partial class Form1 : Form
    {
        GetPerson getPerson = new GetPerson();
        public Form1()
        {
            InitializeComponent();
        }
        public int personid; //Kişi güncellemesinde kullanmak için global değişken
       
        private void Form1_Load(object sender, EventArgs e)
        {
            ListPerson();
        }
        private void addBtn_Click(object sender, EventArgs e)
        {
            AddData addData = new AddData();
            string name, number, incomingAddMessage;
            txtBoxValue(out name, out number);
            incomingAddMessage = addData.Add(name, number);
            StandOperations(incomingAddMessage);
        }
        private void updateBtn_Click(object sender, EventArgs e)
        {
            UpdateData update = new UpdateData();
            string name, number, incomingUbdateMessage;
            txtBoxValue(out name, out number); // textBox degerlerini getiriyorum
            incomingUbdateMessage = update.personUpdate(personid, name, number);
            StandOperations(incomingUbdateMessage);
        }
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            Delete delete = new Delete();
            int deleteId = DeleteDataValue();//silinecek data seçimini deleteId değişkenine atadım
            delete.personDelete(deleteId);
            StandOperations("Kişi Silindi");
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TxbName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            TxbNumber.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            personid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
        }
        private void TxbNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); 
        }
        private void StandOperations(string incomingAddMessage)
        {
            MessageBox.Show(incomingAddMessage);
            ListPerson();
            TextClean();
        }
        private int DeleteDataValue()
        {
            return Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);//seçim yapılan datayı return ediyoruz
        }
        private void txtBoxValue(out string name, out string number)
        {
            name = TxbName.Text;
            number = TxbNumber.Text;
        }
        private void TextClean()
        {
            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
            personid = 0;
        }
        private void ListPerson()
        {
            dataGridView1.DataSource = getPerson.GetAll(); //entity framework ile verilerin listelenmesi
        }

    }
}
