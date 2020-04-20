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
    public class Adresler
    {
        public long Id { get; set; }
        public string Il { get; set; }
        public string Ilce { get; set; }
        public string Mahalle { get; set; }
        public string Cadde_Sokak { get; set; }
        public string Bina_No { get; set; }
        public string Kapi_No { get; set; }


        public bool RunInsertSQL()
        {
            try
            {
                string conString = ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString;
                SqlConnection baglanti = new SqlConnection(conString);
                baglanti.Open();
                SqlCommand com = new SqlCommand(CreateSQL<Adresler>(this), baglanti);
                com.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
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

    }
}