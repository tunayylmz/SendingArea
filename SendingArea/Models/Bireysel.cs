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
    public class Bireysel
    {
        [IsIdentity]
        public long Id { get; set; }
        public string Ad_Soyad { get; set; }
        public long Cep_Tel { get; set; }
        public long TC_No { get; set; }
        public string E_Posta { get; set; }
        public int Dogum_Tarihi_Gun { get; set; }
        public int Dogum_Tarihi_Ay { get; set; }
        public int Dogum_Tarihi_Yil { get; set; }
        public int Cinsiyet { get; set; }


        public bool RunInsertSQL()
        {
            string conString = ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString;
            SqlConnection baglanti = new SqlConnection(conString);
            baglanti.Open();
            SqlCommand com = new SqlCommand(CreateSQL<Bireysel>(this), baglanti);
            com.ExecuteNonQuery();
            return false;
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
                q.Append(item.GetValue(entity, null));
                q.Append(",");
            }
            q.Remove(q.Length - 1, 1);
            q.Append(")");

            return q.ToString();
        }
    }
}