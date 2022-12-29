using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;


namespace ESDnevnik2
{
    class Konekcija
    {
        public static SqlConnection Connect()
        {
            SqlConnection veza = new SqlConnection("Data Source=INF_4_05\\SQLPBG;Initial Catalog=ednevnik;Integrated Security=true");
            return veza;
        }

    }
}
