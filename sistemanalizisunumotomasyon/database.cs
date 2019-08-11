using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace sistemanalizisunumotomasyon
{
    class database
    {
        
        
        public static string constr = ConfigurationManager.ConnectionStrings["MySQL"].ToString();
        public MySqlConnection connection = new MySqlConnection(constr);
        public string control()
        {
            try
            {
                connection.Open();
                return "true";
            }
            catch (MySqlException ex)
            {
                return ex.Message;
            }
        }
    }
}
