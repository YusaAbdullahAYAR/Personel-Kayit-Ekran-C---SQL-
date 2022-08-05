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
    public partial class frmistatistik : Form
    {
        public frmistatistik()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source=DESKTOP-RBCL1FM\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        private void frmistatistik_Load(object sender, EventArgs e)
        {
            // Toplam Personel Sayısı


            baglantı.Open();
            SqlCommand komut1 = new SqlCommand("Select count(*) from Tbl_Personel ",baglantı);

            SqlDataReader dr1 = komut1.ExecuteReader();
                while(dr1.Read())
            {
                LblToplamPersonel.Text = dr1[0].ToString();
            }
            baglantı.Close();

            //Evli Personel Sayısı

            baglantı.Open();
            SqlCommand komut2 = new SqlCommand("Select count(*) from Tbl_Personel where PerDurum=1 ", baglantı);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                LblEvliPersonel.Text = dr2[0].ToString();
            }

            baglantı.Close();

            //Bekar Personel Sayısı

            baglantı.Open();

            SqlCommand komut3 = new SqlCommand("Select count(*) from Tbl_Personel where PerDurum=0 ", baglantı);

            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                LblBekarPersonel.Text = dr3[0].ToString();
            }


            baglantı.Close();

            //Şehir Sayısı

            baglantı.Open();

            SqlCommand komut4 = new SqlCommand("select count(distinct (Persehir)) from Tbl_Personel", baglantı);

            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                LblSehirSayisi.Text = dr4[0].ToString();
            }


            baglantı.Close();


            //toplam maaş

            baglantı.Open();

            SqlCommand komut5 = new SqlCommand("select sum(PerMaas) from Tbl_Personel ", baglantı);
            SqlDataReader dr5 =komut5.ExecuteReader();
            while(dr5.Read())
            {
                LblToplamMaas.Text = dr5[0].ToString();
            }
            baglantı.Close();



            //Ortalama maaş

            baglantı.Open();
            SqlCommand komut6 = new SqlCommand("select avg(PerMaas) from Tbl_Personel", baglantı);
            SqlDataReader dr6=komut6.ExecuteReader();
            while( dr6.Read())
            {
                LblOrtalamaMaas.Text = dr6[0].ToString();
            }

            baglantı.Close();










        }
    }
}
