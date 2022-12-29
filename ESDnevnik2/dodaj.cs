using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ESDnevnik2
{
    public partial class dodaj : Form
    {
        int slog;
        public dodaj(int s)
        {
            InitializeComponent();
            slog = s;
        }
        public string Dodaj = "";
        private void button1_Click(object sender, EventArgs e)
        {
            Dodaj = "INSERT INTO osoba VALUES('";
            Dodaj = Dodaj + textBox2.Text + "','";
            Dodaj = Dodaj + textBox3.Text + "','";
            Dodaj = Dodaj + textBox4.Text + "','";
            Dodaj = Dodaj + textBox5.Text + "','";
            Dodaj = Dodaj + textBox6.Text + "','";
            Dodaj = Dodaj + textBox7.Text + "',";
            if (comboBox1.Text == "Ucenik")
                Dodaj = Dodaj + "1)";
            else
                Dodaj = Dodaj + "2)";
            this.Close();
        }
    }
}
