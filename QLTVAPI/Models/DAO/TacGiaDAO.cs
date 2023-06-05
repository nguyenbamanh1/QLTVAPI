using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLTVAPI.Models.DAO
{
    public class TacGiaDAO
    {
        public static List<TACGIA> getall()
        {
            List<TACGIA> docGias = new List<TACGIA>();
            MySqlConnection conn = DBService.GetDBConnection();
            MySqlDataReader reader = null;
            try
            {

                if (conn != null)
                {
                    var cmd = new MySqlCommand("SELECT * FROM `tb_tacgia`");
                    cmd.Connection = conn;
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        TACGIA doc = new TACGIA();
                        doc.ID = reader.GetString(0);
                        doc.NAME = reader.GetString(1);
                        doc.GT = (byte)reader.GetInt32(2);
                        doc.QUEQUAN = reader.GetString(3);
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
                    var cmd = new MySqlCommand("delete from tb_tacgia where matg = @madg");
                    cmd.Parameters.AddWithValue("@madg", id);
                    cmd.Connection = conn;
                    conn.Open();
                    if(cmd.ExecuteNonQuery() > 0)
                    {
                        message.TYPE = 0;
                        message.MSG = "Xóa thành công tác giả" + id;
                    }
                    else
                    {
                        message.TYPE = 1;
                        message.MSG = "Xóa thất bại tác giả" + id;
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

        public static TACGIA get(string id)
        {
            MySqlConnection conn = DBService.GetDBConnection();
            MySqlDataReader reader = null;
            TACGIA doc = null;
            try
            {

                if (conn != null)
                {
                    var cmd = new MySqlCommand("SELECT * FROM `tb_tacgia` where matg = '" + id + "'");
                    cmd.Connection = conn;
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        doc = new TACGIA();
                        doc.ID = reader.GetString(0);
                        doc.NAME = reader.GetString(1);
                        doc.GT = (byte)reader.GetInt32(2);
                        doc.QUEQUAN = reader.GetString(3);
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

        public static Message put(TACGIA doc)
        {
            MySqlConnection conn = DBService.GetDBConnection();
            MySqlDataReader reader = null;
            Message message = new Message();
            try
            {

                if (conn != null)
                {
                    var cmd = new MySqlCommand("insert into tb_tacgia (tentg, gioitinh, quequan) values(@madk, @gt, @quequan)");
                    cmd.Parameters.AddWithValue("@madk", doc.NAME);
                    cmd.Parameters.AddWithValue("@gt", doc.GT);
                    cmd.Parameters.AddWithValue("@quequan", doc.QUEQUAN);
                    cmd.Connection = conn;
                    conn.Open();
                    if(cmd.ExecuteNonQuery() > 0)
                    {
                        message.TYPE = 0;
                        message.MSG = "Thêm thành công tác giả " + doc.NAME;
                    }
                    else
                    {
                        message.TYPE = 1;
                        message.MSG = "Thêm thất bại tác giả " + doc.NAME;
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

        public static Message update(TACGIA doc)
        {
            MySqlConnection conn = DBService.GetDBConnection();
            MySqlDataReader reader = null;
            Message message = new Message();
            try
            {

                if (conn != null)
                {
                    var cmd = new MySqlCommand("UPDATE `tb_tacgia` SET `tentg`=@madk, gioitinh = @gt, quequan = @quequan WHERE `matg`=@makhoa");
                    cmd.Parameters.AddWithValue("@madk", doc.NAME);
                    cmd.Parameters.AddWithValue("@makhoa", doc.ID);
                    cmd.Parameters.AddWithValue("@gt", doc.GT);
                    cmd.Parameters.AddWithValue("@quequan", doc.QUEQUAN);
                    cmd.Connection = conn;
                    conn.Open();
                    if(cmd.ExecuteNonQuery() > 0)
                    {
                        message.TYPE = 0;
                        message.MSG = "Cập nhật thành công Phiếu mượn " + doc.NAME;
                    }
                    else
                    {
                        message.TYPE = 1;
                        message.MSG = "Cập nhật thất bại Phiếu mượn " + doc.NAME;
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