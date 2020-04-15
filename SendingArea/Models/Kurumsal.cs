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
    public class Kurumsal
    {
        public long Id { get; set; }
        public string Firma_Adi { get; set; }
        public long Vergi_No { get; set; }
        public string Vergi_Dairesi { get; set; }
        public string Fatura_Adresi { get; set; }
        public long Tel { get; set; }
        public long Faks { get; set; }
        public string Yetkili_E_Posta { get; set; }


        public bool RunInsertSQL()
        {
            string conString = ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString;
            SqlConnection baglanti = new SqlConnection(conString);
            baglanti.Open();
            SqlCommand com = new SqlCommand(CreateSQL<Kurumsal>(this), baglanti);
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
                if (item.PropertyType == typeof(string)) q.Append("'");
                q.Append(item.GetValue(entity, null));
                if (item.PropertyType == typeof(string)) q.Append("'");
                q.Append(",");
            }
            q.Remove(q.Length - 1, 1);
            q.Append(")");

            return q.ToString();
        }
    }
}