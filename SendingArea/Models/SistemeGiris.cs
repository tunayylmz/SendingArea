using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;

namespace SendingArea.Models

{
    public class SistemeGiris
    {
        public string E_Posta { get; set; }
        public string sifre { get; set; }
        public Musteri SistemeGirisIslemi()
        {
            //ArrayList Kullanici = new ArrayList();
            Musteri girisYapan = new Musteri();
            
            string conString = ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString;
            SqlConnection baglanti = new SqlConnection(conString);
            baglanti.Open();
            SqlCommand veriCek = new SqlCommand("select * from Musteri_Kayit Where E_Posta='"+E_Posta+ "' and sifre='" + sifre + "'",baglanti);
            SqlDataReader oku = veriCek.ExecuteReader();
            //System.Data.DataTable GirisVeri = new System.Data.DataTable();
            if (oku.HasRows)
            {
                while (oku.Read())
                {
                    girisYapan.E_Posta = oku["E_Posta"].ToString();
                }
                girisYapan.is_Login = "yes";
                //GirisVeri.Load(oku);
                //Session['s'] = '';

                // return true;
            }
            girisYapan.is_Login = "no";
            return girisYapan;
            //return false;
        }

    }
}