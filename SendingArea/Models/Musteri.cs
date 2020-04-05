using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SendingArea.Models
{
    public class Musteri
    {
        public int Id { get; set; }
        public string Ad_Soyad { get; set; }
        public int Cep_Tel { get; set; }
        public int TC_No { get; set; }
        public string E_Posta { get; set; }
        public string sifre { get; set; }

        public bool MusteriKaydiOlusturma()
        {
            string conString = ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString;
            SqlConnection baglanti = new SqlConnection(conString);
            baglanti.Open();
            string q = "insert into Musteri_Kayit(Ad_Soyad,Cep_Tel,TC_No,E_Posta,sifre)values('" + Ad_Soyad + "'," + Cep_Tel + "," + TC_No + ",'" + E_Posta + "','" + sifre + "')";
            SqlCommand com = new SqlCommand(q, baglanti);
            com.ExecuteNonQuery();
            return false;
        }
    }
}