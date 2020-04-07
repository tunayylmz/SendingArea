using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
namespace SendingArea.Models

{
    public class SistemeGiris
    {
        public string E_Posta { get; set; }
        public string sifre { get; set; }
        public bool SistemeGirisIslemi()
        {
            string conString = ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString;
            SqlConnection baglanti = new SqlConnection(conString);
            baglanti.Open();
            SqlCommand veriCek = new SqlCommand("select * from Musteri_Kayit Where E_Posta='"+E_Posta+ "' and sifre='" + sifre + "'");
            SqlDataReader oku = veriCek.ExecuteReader();
            //System.Data.DataTable GirisVeri = new System.Data.DataTable();
            if (oku.HasRows)
            {
                //GirisVeri.Load(oku);
                return true;
            }
            return false;
        }

    }
}