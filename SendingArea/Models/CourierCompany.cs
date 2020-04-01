using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace SendingArea.Models
{
    public class CourierCompany
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string TaxNo { get; set; }
        public string TaxOffice { get; set; }

        public bool WriteClass()
        {
            string conString = ConfigurationManager.ConnectionStrings["Baglanti"].ConnectionString;
            SqlConnection baglanti = new SqlConnection(conString);
            baglanti.Open();
            string q = "insert into CourierCompany(Name,Phone,Address,TaxNo, TaxOffice)values('"+Name+"',"+ Phone+",'"+Address+"',"+TaxNo+",'"+TaxOffice+"')";
            SqlCommand com = new SqlCommand(q, baglanti);
            com.ExecuteNonQuery();
            return false;
        }
    }
}