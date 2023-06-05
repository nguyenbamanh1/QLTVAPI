using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
namespace QLTVAPI.Models.DAO
{
    public class DBService
    {
        public static MySqlConnection GetDBConnection()
        {
            try
            {

                MySqlConnection conn = new MySqlConnection("server=localhost;database=quanlythuvien;uid=root;password=nguyenbamanh1;");
                return conn;
            }catch(Exception ex)
            {
                
                return null;
            }
        }
    }
}