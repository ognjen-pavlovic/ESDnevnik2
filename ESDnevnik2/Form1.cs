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
    public partial class Form1 : Form
    {
        int slog = 0;
        DataTable tabela;
        public Form1()
        {
            InitializeComponent();
        }
        private void DataLoad()
        {
            SqlConnection veza = Konekcija.Connect();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM osoba", veza);
            tabela = new DataTable();
            adapter.Fill(tabela);
        }
        private void Loader()
        {
            textBox1.Text = tabela.Rows[slog]["id"].ToString();
            textBox2.Text = tabela.Rows[slog]["ime"].ToString();
            textBox3.Text = tabela.Rows[slog]["prezime"].ToString();
            textBox4.Text = tabela.Rows[slog]["adresa"].ToString();
            textBox5.Text = tabela.Rows[slog]["jmbg"].ToString();
            textBox6.Text = tabela.Rows[slog]["email"].ToString();
            textBox7.Text = tabela.Rows[slog]["pass"].ToString();
            if (tabela.Rows[slog]["uloga"].ToString() == "1")
            {
                textBox8.Text = "Ucenik";
            }
            else
            {
                textBox8.Text = "Profesor";
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DataLoad();
            Loader();
            button6.Enabled = false;
            button7.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            slog++;
            DataLoad();
            Loader();
            if (slog == tabela.Rows.Count - 1)
            {
                button2.Enabled = false;
                button3.Enabled = false;
            }
            button6.Enabled = true;
            button7.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            slog = tabela.Rows.Count - 1;
            DataLoad();
            Loader();
            button2.Enabled = false;
            button3.Enabled = false;
            button6.Enabled = true;
            button7.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            slog--;
            DataLoad();
            Loader();
            if (slog == 0)
            {
                button6.Enabled = false;
                button7.Enabled = false;
            }
            button2.Enabled = true;
            button3.Enabled = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            slog = 0;
            DataLoad();
            Loader();
            button2.Enabled = true;
            button3.Enabled = true;
            button6.Enabled = false;
            button7.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string update = "UPDATE osoba SET ";
            update = update + "ime = '" + textBox2.Text + "', ";
            update = update + "prezime = '" + textBox3.Text + "', ";
            update = update + "adresa = '" + textBox4.Text + "', ";
            update = update + "jmbg = '" + textBox5.Text + "', ";
            update = update + "email = '" + textBox6.Text + "', ";
            update = update + "pass = '" + textBox7.Text + "' ";
            update = update + "WHERE id = " + textBox1.Text;
            SqlConnection veza = Konekcija.Connect();
            SqlCommand komanda = new SqlCommand(update, veza);
            try
            {
                veza.Open();
                komanda.ExecuteNonQuery();
                veza.Close();
            }
            catch(Exception Greska)
            {
                MessageBox.Show(Greska.Message);
                DataLoad();
                slog = tabela.Rows.Count - 1;
                Loader();
            }
        }
    }
}
