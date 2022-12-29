using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ESDnevnik2
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Morate uneti ime i lozinku");
            }
            else
            {
                SqlCommand komanda = new SqlCommand("SELECT * FROM osoba WHERE email='" + textBox1.Text + "'", Konekcija.Connect());
                SqlDataAdapter adapter = new SqlDataAdapter(komanda);
                DataTable tabela = new DataTable();
                adapter.Fill(tabela);
                int count = tabela.Rows.Count;
                if (count == 1)
                {
                    if (string.Compare(textBox2.Text, tabela.Rows[0]["pass"].ToString()) == 0)
                    {
                        MessageBox.Show("Dobrodosli!");
                        Main forma = new Main();
                        forma.Show();
                        if (Application.OpenForms.OfType<Main>().Count() == 1)
                            this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Dobar username, ali los password");
                    }
                }
                else
                {
                    MessageBox.Show("Nepostojeci username");
                }
            }
        }
    }
}
