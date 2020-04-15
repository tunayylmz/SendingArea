using SendingArea.Models.ORM;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace SendingArea.Models
{
    public class Musteri
    {
        [IsIdentity]
        public long Id { get; set; }
        public string Bireysel_Kurumsal { get; set; }
        public long Bireysel_Kurumsal_Id { get; set; }
        public string E_Posta { get; set; }
        public string Sifre { get; set; }

        public bool RunInsertSQL()
        {
            string conString = ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString;
            SqlConnection baglanti = new SqlConnection(conString);
            baglanti.Open();
            SqlCommand com;
            System.Data.DataTable dt;
            string sqlstr;
            if (Bireysel_Kurumsal == "Bireysel")
            {
                bireysel_musteri.RunInsertSQL();
                sqlstr = "SELECT * FROM Bireysel WHERE E_Posta = '" + this.E_Posta + "'";
                com = new SqlCommand(sqlstr, baglanti);
                dt = new System.Data.DataTable();
                dt.Load(com.ExecuteReader());
                if (dt.Rows.Count > 0)
                {
                    bireysel_musteri.Id = (long)dt.Rows[0]["Id"];
                    Bireysel_Kurumsal_Id = bireysel_musteri.Id;
                }
                else
                {
                    sqlstr = "DELETE FROM Bireysel WHERE E_Posta = '" + this.E_Posta + "'";
                    com = new SqlCommand(sqlstr, baglanti);
                    com.ExecuteNonQuery();
                    sqlstr = "DELETE FROM Musteri WHERE E_Posta = '" + this.E_Posta + "'";
                    com = new SqlCommand(sqlstr, baglanti);
                    com.ExecuteNonQuery();
                    return false;
                }
            }
            else if (Bireysel_Kurumsal == "Kurumsal")
            {
                kurumsal_musteri.RunInsertSQL();
                sqlstr = "SELECT * FROM Kurumsal WHERE Yetkili_E_Posta = '" + this.E_Posta + "'";
                com = new SqlCommand(sqlstr, baglanti);
                dt = new System.Data.DataTable();
                dt.Load(com.ExecuteReader());
                if (dt.Rows.Count > 0)
                {
                    kurumsal_musteri.Id = (long)dt.Rows[0]["Id"];
                    Bireysel_Kurumsal_Id = bireysel_musteri.Id;
                }
                else
                {
                    sqlstr = "DELETE FROM Kurumsal WHERE Yetkili_E_Posta = '" + this.E_Posta + "'";
                    com = new SqlCommand(sqlstr, baglanti);
                    com.ExecuteNonQuery();
                    sqlstr = "DELETE FROM Musteri WHERE E_Posta = '" + this.E_Posta + "'";
                    com = new SqlCommand(sqlstr, baglanti);
                    com.ExecuteNonQuery();
                    return false;
                }
            }

            com = new SqlCommand(CreateSQL<Musteri>(this), baglanti);
            com.ExecuteNonQuery();

            sqlstr = "SELECT * FROM Musteri WHERE E_Posta = '" + this.E_Posta + "'";
            com = new SqlCommand(sqlstr, baglanti);
            dt = new System.Data.DataTable();
            dt.Load(com.ExecuteReader());
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                sqlstr = "DELETE FROM Bireysel WHERE E_Posta = '" + this.E_Posta + "'";
                com = new SqlCommand(sqlstr, baglanti);
                com.ExecuteNonQuery();
                sqlstr = "DELETE FROM Kurumsal WHERE Yetkili_E_Posta = '" + this.E_Posta + "'";
                com = new SqlCommand(sqlstr, baglanti);
                com.ExecuteNonQuery();
                sqlstr = "DELETE FROM Musteri WHERE E_Posta = '" + this.E_Posta + "'";
                com = new SqlCommand(sqlstr, baglanti);
                com.ExecuteNonQuery();
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

        public bool giris_yapildi = false;
        public bool musteri_turu_bireysel_mi = true;
        public Bireysel bireysel_musteri = new Bireysel();
        public Kurumsal kurumsal_musteri = new Kurumsal();

        public bool Kullanıcı_Girisi()
        {
            string conString = ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString;
            SqlConnection baglanti = new SqlConnection(conString);
            baglanti.Open();

            string sqlstr = "";
            sqlstr += "SELECT * FROM Musteri WHERE E_Posta = '" + this.E_Posta;
            sqlstr += "' AND Sifre = '" + this.Sifre +"'";

            SqlCommand com = new SqlCommand(sqlstr, baglanti);
            SqlDataReader reader = com.ExecuteReader();
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Load(reader);

            if (dt.Rows.Count>0)
            {
                this.Id = (long)dt.Rows[0]["Id"];
                this.Bireysel_Kurumsal = (string)dt.Rows[0]["Bireysel_Kurumsal"];
                this.Bireysel_Kurumsal_Id = (long)dt.Rows[0]["Bireysel_Kurumsal_Id"];

                if (this.Bireysel_Kurumsal == "Bireysel")
                    sqlstr = "select * from Bireysel where Id = " + Bireysel_Kurumsal_Id;
                else if (this.Bireysel_Kurumsal == "Kurumsal")
                    sqlstr = "select * from Kurumsal where Id = " + Bireysel_Kurumsal_Id;
                else
                    return false;

                com = new SqlCommand(sqlstr, baglanti);
                reader = com.ExecuteReader();
                dt = new System.Data.DataTable();
                dt.Load(reader);

                if (this.Bireysel_Kurumsal == "Bireysel")
                {
                    ConvertTableToClass<Bireysel>(dt, ref bireysel_musteri);
                    musteri_turu_bireysel_mi = true;
                }
                else if (this.Bireysel_Kurumsal == "Kurumsal")
                    ConvertTableToClass<Kurumsal>(dt, ref kurumsal_musteri);
                giris_yapildi = true;
                return true;
            }
            giris_yapildi = false;
            return false;
        }

        private void ConvertTableToClass<T>(System.Data.DataTable dt, ref T entity)
        {
            foreach (PropertyInfo prop in entity.GetType().GetProperties())
            {
                prop.SetValue(entity, dt.Rows[0][prop.Name], null);
            }
        }

    }
}