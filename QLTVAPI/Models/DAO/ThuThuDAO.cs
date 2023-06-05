using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLTVAPI.Models.DAO
{
    public class ThuThuDAO
    {
        public static List<ThuThu> getall()
        {
            List<ThuThu> docGias = new List<ThuThu>();
            MySqlConnection conn = DBService.GetDBConnection();
            MySqlDataReader reader = null;
            try
            {

                if (conn != null)
                {
                    var cmd = new MySqlCommand("SELECT * FROM `tb_thuthu`");
                    cmd.Connection = conn;
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ThuThu doc = new ThuThu();
                        doc.MATT = reader.GetString(0);
                        doc.TENTT = reader.GetString(1);
                        doc.GT = (byte)reader.GetInt32(2);
                        doc.SDT = reader.GetString(3);
                        doc.DIACHI = reader.GetString(4);
                        doc.EMAIL = reader.GetString(5);
                        docGias.Add(doc);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (conn != null) conn.Close();
                if (reader != null) reader.Close();
            }
            return docGias;
        }

        public static Message delete(string id)
        {
            MySqlConnection conn = DBService.GetDBConnection();
            MySqlDataReader reader = null;
            Message message = new Message();
            try
            {

                if (conn != null)
                {
                    var cmd = new MySqlCommand("delete from tb_thuthu where matt = @madg");
                    cmd.Parameters.AddWithValue("@madg", id);
                    cmd.Connection = conn;
                    conn.Open();
                    if(cmd.ExecuteNonQuery() > 0)
                    {

                        message.TYPE = 0;
                        message.MSG = "Xóa thành công thủ thư " + id;
                    }
                    else
                    {

                        message.TYPE = 1;
                        message.MSG = "Xóa thất bại thủ thư " + id;
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                message.TYPE = 1;
                message.MSG = "Có lỗi xảy ra" + ex.Message;
            }
            finally
            {
                if (conn != null) conn.Close();
                if (reader != null) reader.Close();
            }
            return message;
        }

        public static ThuThu get(string id)
        {
            MySqlConnection conn = DBService.GetDBConnection();
            MySqlDataReader reader = null;
            ThuThu doc = null;
            try
            {

                if (conn != null)
                {
                    var cmd = new MySqlCommand("SELECT * FROM `tb_thuthu` where matt = '" + id + "'");
                    cmd.Connection = conn;
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        doc = new ThuThu();
                        doc.MATT = reader.GetString(0);
                        doc.TENTT = reader.GetString(1);
                        doc.GT = (byte)reader.GetInt32(2);
                        doc.SDT = reader.GetString(3);
                        doc.DIACHI = reader.GetString(4);
                        doc.EMAIL = reader.GetString(5);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (conn != null) conn.Close();
                if (reader != null) reader.Close();
            }
            return doc;
        }

        public static Message put(ThuThu doc)
        {
            MySqlConnection conn = DBService.GetDBConnection();
            MySqlDataReader reader = null;
            Message message = new Message();
            try
            {

                if (conn != null)
                {
                    var cmd = new MySqlCommand("insert into tb_thuthu (tentt, gioitinh, sdt, diachi, email) values(@madk, @gt, @sdt, @diachi, @email)");
                    cmd.Parameters.AddWithValue("@madk", doc.TENTT);
                    cmd.Parameters.AddWithValue("@gt", doc.GT);
                    cmd.Parameters.AddWithValue("@sdt", doc.SDT);
                    cmd.Parameters.AddWithValue("@diachi", doc.DIACHI);
                    cmd.Parameters.AddWithValue("@email", doc.EMAIL);
                    cmd.Connection = conn;
                    conn.Open();
                    if(cmd.ExecuteNonQuery() > 0)
                    {
                        message.TYPE = 0;
                        message.MSG = "Thêm thành công thủ thư " + doc.TENTT;
                    }
                    else
                    {
                        message.TYPE = 1;
                        message.MSG = "Thêm thất bại thủ thư " + doc.TENTT;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                message.TYPE = 1;
                message.MSG = "Có lỗi xảy ra" + ex.Message;
            }
            finally
            {
                if (conn != null) conn.Close();
                if (reader != null) reader.Close();
            }
            return message;
        }

        public static Message update(ThuThu doc)
        {
            MySqlConnection conn = DBService.GetDBConnection();
            MySqlDataReader reader = null;
            Message message = new Message();
            try
            {

                if (conn != null)
                {
                    var cmd = new MySqlCommand("update tb_thuthu set tentt = @tentl, gioitinh = @gt, sdt = @sdt, diachi = @diachi, email = @email where matt = @matt");
                    cmd.Parameters.AddWithValue("@tentl", doc.TENTT);
                    cmd.Parameters.AddWithValue("@gt", doc.GT);
                    cmd.Parameters.AddWithValue("@sdt", doc.SDT);
                    cmd.Parameters.AddWithValue("@matt", doc.MATT);
                    cmd.Parameters.AddWithValue("@diachi", doc.DIACHI);
                    cmd.Parameters.AddWithValue("@email", doc.EMAIL);
                    cmd.Connection = conn;
                    conn.Open();
                    if(cmd.ExecuteNonQuery() >0)
                    {
                        message.TYPE = 0;
                        message.MSG = "Cập nhật thành công thủ thư " + doc.TENTT;
                    }

                    else 
                    {
                        message.TYPE = 1;
                        message.MSG = "Cập nhật thất bại thủ thư " + doc.TENTT;
                    }

                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                message.TYPE = 1;
                message.MSG = "Có lỗi xảy ra" + ex.Message;
            }
            finally
            {
                if (conn != null) conn.Close();
                if (reader != null) reader.Close();
            }
            return message;
        }
    }
}