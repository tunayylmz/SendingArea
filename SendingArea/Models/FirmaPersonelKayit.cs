using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace SendingArea.Models
{
    public class FirmaPersonelKayit
    {
        public long Id { get; set; }
        public long Firma_Kayit_Id { get; set; }
        public string Ad_Soyad { get; set; }
        public long Cep_Tel { get; set; }
        public long TC_No { get; set; }
        public string E_Posta { get; set; }
        public string Motor_Plaka { get; set; }
        public string Motor_Marka { get; set; }
        public string Motor_Model { get; set; }
        public long Motor_Model_Yili { get; set; }
        public long Motor_Tasima_Hacim { get; set; }
        public long Motor_Tasima_Agirlik { get; set; }

        public bool FirmaPersonelKaydiOlusturma()
        {
            string conString = ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString;
            SqlConnection baglanti = new SqlConnection(conString);
            baglanti.Open();
            string q = "insert into Kurye_Kayit(Firma_Kayit_Id,Ad_Soyad,Cep_Tel,TC_No,E_Posta,Motor_Plaka,Motor_Marka,Motor_Model,Motor_Model_Yili,Motor_Tasima_Hacim,Motor_Tasima_Agirlik)values(" + Firma_Kayit_Id + ",'" + Ad_Soyad + "'," + Cep_Tel + "," + TC_No + ",'" + E_Posta + "','" + Motor_Plaka + "','" + Motor_Marka + "','" + Motor_Model + "'," + Motor_Model_Yili + "," + Motor_Tasima_Hacim + "," + Motor_Tasima_Agirlik + ")";
            SqlCommand com = new SqlCommand(q, baglanti);
            com.ExecuteNonQuery();
            return false;
        }

    }
}