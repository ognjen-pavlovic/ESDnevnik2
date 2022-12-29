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
    public partial class Sifarnik : Form
    {
        DataTable dtPodaci;
        SqlDataAdapter adapter;
        string odakle;
        public Sifarnik(string pull)
        {
            InitializeComponent();
            odakle = pull;
        }
        private void Sifarnik_Load(object sender, EventArgs e)
        {
            this.Text = odakle;
            adapter = new SqlDataAdapter("SELECT * FROM " + odakle, Konekcija.Connect());
            dtPodaci = new DataTable();
            adapter.Fill(dtPodaci);
            dataGridView1.DataSource = dtPodaci;
            dataGridView1.Columns["Id"].ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable nova = new DataTable();
            nova = dtPodaci.GetChanges();
            dataGridView2.DataSource = nova;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable menjano = dtPodaci.GetChanges();
            adapter.UpdateCommand = new SqlCommandBuilder(adapter).GetUpdateCommand();
            if (menjano != null)
            {
                adapter.Update(menjano);
                this.Close();
            }
        }
    }
}
