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
                MessageBox.Show("Unesite email i/ili lozinku!");
            else
            {
                try
                {
                    SqlConnection veza = Konekcija.Connect();
                    string loginemail = "SELECT * FROM osoba WHERE email = " + textBox1.Text;
                    SqlCommand komanda = new SqlCommand(loginemail, veza);
                    SqlDataAdapter adapter = new SqlDataAdapter(komanda);
                    DataTable tabela = new DataTable();
                    adapter.Fill(tabela);
                    int brojac = tabela.Rows.Count;
                    if (brojac == 1)
                    {
                        if (String.Compare(tabela.Rows[0]["pass"].ToString(), textBox2.Text) == 0)
                        {
                            MessageBox.Show("Login Successful!");
                        }
                        else
                            MessageBox.Show("Netacan email i/ili sifra!");
                    }
                    else
                        MessageBox.Show("Netacan email i/ili sifra!");
                }
                catch (Exception Greska)
                {
                    MessageBox.Show(Greska.Message);
                }
            }
        }
    }
}
