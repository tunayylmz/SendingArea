using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Drawing.Printing;
using System.Reflection;
using SendingArea.Models.ORM;

namespace SendingArea.Models
{
    public class TasiyiciFirma
    {
        public long Id { get; set; }
        public long KurumsalId { get; set; }
        public string Yetkili_AdSoyad { get; set; }
        public string Yetkili_E_Posta { get; set; }
        public string sifre { get; set; }


        public Kurumsal FirmaBilgileri = new Kurumsal();
        public string HataMesaji = "";

        public bool RunInsertSQL()
        {
            try
            {
                string conString = ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString;
                SqlConnection baglanti = new SqlConnection(conString);
                baglanti.Open();

                string sqlstr = "select * from Kurumsal where Yetkili_E_Posta = '" + Yetkili_E_Posta + "'";
                SqlCommand com = new SqlCommand(sqlstr, baglanti);
                DataTable dt = new DataTable();
                dt.Load(com.ExecuteReader());

                if (dt.Rows.Count > 0)
                {
                    HataMesaji = "Girmiş olduğunuz E-Posta adresi kullanılmaktadır. Lütfen farklı bir E-Posta adresi giriniz.";
                    return false;
                }
                    

                this.KurumsalId = FirmaBilgileri.RunInsertSQLAndReturnId();

                if (this.Id == -1)
                {
                    HataMesaji = "Sistemsel bir hata oluştu. Lütfen Sending Area yetkilisi ile iletişime geçin.";
                    return false;
                }

                com = new SqlCommand(CreateSQL<TasiyiciFirma>(this), baglanti);
                com.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                HataMesaji = "Sistemsel bir hata oluştu. Lütfen Sending Area yetkilisi ile iletişime geçin.";
                return false;
            }
        }

        private string CreateSQL<T>(T entity)
        {
            Type tip = typeof(T);
            System.Text.StringBuilder q = new System.Text.StringBuilder();
            q.Append("Insert Into ");
            q.Append(tip.Name);
            q.Append(" (");
            foreach (PropertyInfo item in tip.GetProperties())
            {
                if (item.GetCustomAttributes(typeof(IsIdentity), true).Count() > 0) continue;
                q.Append(item.Name + ",");
            }
            q.Remove(q.Length - 1, 1);
            q.Append(") Values(");
            foreach (PropertyInfo item in tip.GetProperties())
            {
                if (item.GetCustomAttributes(typeof(IsIdentity), true).Count() > 0) continue;
                if (item.PropertyType == typeof(string)) q.Append("'");
                q.Append(item.GetValue(entity, null));
                if (item.PropertyType == typeof(string)) q.Append("'");
                q.Append(",");
            }
            q.Remove(q.Length - 1, 1);
            q.Append(")");

            return q.ToString();
        }

        public bool FirmaKaydiOlusturma()
        {
            string conString = ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString;
            //SqlConnection baglanti = new SqlConnection(conString);
            //baglanti.Open();
            //string q = "insert into Firma_Kayit(Sirket_Adi,Yetkili_AdSoyad,Telefon_No,Firma_Mail,Fatura_Adresi, Vergi_No,Vergi_Dairesi,sifre)values('" + Sirket_Adi + "','" + Yetkili_AdSoyad + "'," + Telefon_No + ",'" + Firma_Mail + "','" + Fatura_Adresi + "'," + Vergi_No + ",'" + Vergi_Dairesi + "','" + sifre + "')";
            //SqlCommand com = new SqlCommand(q, baglanti);
            //com.ExecuteNonQuery();
            //SqlDataReader a = com.ExecuteReader();
            //DataTable b = new DataTable();
            //if (a.HasRows)
            //    b.Load(a);
            
            return false;
        }
    }
}