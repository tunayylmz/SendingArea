using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace SendingArea.Models
{
    public class TasiyiciFirma
    {
        public int Id { get; set; }
        public string Sirket_Adi { get; set; }
        public string Yetkili_AdSoyad { get; set; }
        public int Telefon_No { get; set; }
        public string Firma_Mail { get; set; }
        public string Fatura_Adresi { get; set; }
        public int Vergi_No { get; set; }
        public string Vergi_Dairesi { get; set; }
        public string sifre { get; set; }

        public bool FirmaKaydiOlusturma()
        {
            string conString = ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString;
            SqlConnection baglanti = new SqlConnection(conString);
            baglanti.Open();
            string q = "insert into Firma_Kayit(Sirket_Adi,Yetkili_AdSoyad,Telefon_No,Firma_Mail,Fatura_Adresi, Vergi_No,Vergi_Dairesi,sifre)values('" + Sirket_Adi + "','" + Yetkili_AdSoyad + "'," + Telefon_No + ",'" + Firma_Mail + "','" + Fatura_Adresi + "'," + Vergi_No + ",'" + Vergi_Dairesi + "','" + sifre + "')";
            SqlCommand com = new SqlCommand(q, baglanti);
            com.ExecuteNonQuery();
            return false;
        }
    }
}