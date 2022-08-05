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

namespace Personel_Kayit
{
    public partial class FrmGrafikler : Form
    {
        public FrmGrafikler()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-RBCL1FM\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        private void Sehirler_Click(object sender, EventArgs e)
        {
            
        }
       // Graphics 1
        private void FrmGrafikler_Load(object sender, EventArgs e)
        {
            baglantı.Open();

            SqlCommand komutg1 = new SqlCommand("select PerSehir,Count(*) from Tbl_Personel group by Persehir ", baglantı);
            SqlDataReader dr1 = komutg1.ExecuteReader();
            while (dr1.Read())
            {
                chart1.Series["Sehirler"].Points.AddXY(dr1[0], dr1[1]);
            }

            baglantı.Close();
            //    Graphics 2


            baglantı.Open();

            SqlCommand komutg2 = new SqlCommand("select PerMeslek,Avg(PerMaas) from Tbl_Personel group by PerMeslek ", baglantı);
            SqlDataReader dr2 = komutg2.ExecuteReader();
            while (dr2.Read())
            {
                chart2.Series["Meslek-Maas"].Points.AddXY(dr2[0], dr2[1]);
            }

            baglantı.Close();


        }
    }
}
