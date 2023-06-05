using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLTVAPI.Models.DAO
{
    public class NXBDAO
    {
        public static List<NXB> getall()
        {
            List<NXB> docGias = new List<NXB>();
            MySqlConnection conn = DBService.GetDBConnection();
            MySqlDataReader reader = null;
            try
            {

                if (conn != null)
                {
                    var cmd = new MySqlCommand("SELECT * FROM `tb_nhaxuatban`");
                    cmd.Connection = conn;
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        NXB doc = new NXB();
                        doc.ID = reader.GetString(0);
                        doc.NAME = reader.GetString(1);
                        doc.DIACHI = reader.GetString(2);
                        doc.SDT = reader.GetString(3);
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
                    var cmd = new MySqlCommand("delete from tb_nhaxuatban where manxb = @madg");
                    cmd.Parameters.AddWithValue("@madg", id);
                    cmd.Connection = conn;
                    conn.Open();
                    if(cmd.ExecuteNonQuery() > 0)
                    {
                        message.TYPE = 0;
                        message.MSG = "Xóa thành công nhà xuất bản " + id;
                    }
                    else
                    {
                        message.TYPE = 1;
                        message.MSG = "Xóa thất bại nhà xuất bản " + id;
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

        public static NXB get(string id)
        {
            MySqlConnection conn = DBService.GetDBConnection();
            MySqlDataReader reader = null;
            NXB doc = null;
            try
            {

                if (conn != null)
                {
                    var cmd = new MySqlCommand("SELECT * FROM `tb_nhaxuatban` where manxb = '" + id + "'");
                    cmd.Connection = conn;
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        doc = new NXB();
                        doc.ID = reader.GetString(0);
                        doc.NAME = reader.GetString(1);
                        doc.DIACHI = reader.GetString(2);
                        doc.SDT = reader.GetString(3);
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

        public static Message put(NXB doc)
        {
            MySqlConnection conn = DBService.GetDBConnection();
            MySqlDataReader reader = null;
            Message message = new Message();
            try
            {

                if (conn != null)
                {
                    var cmd = new MySqlCommand("insert into tb_nhaxuatban (tennxb, diachi, sdt) values(@madk, @diachi, @sdt)");
                    cmd.Parameters.AddWithValue("@madk", doc.NAME);
                    cmd.Parameters.AddWithValue("@diachi", doc.DIACHI);
                    cmd.Parameters.AddWithValue("@sdt", doc.SDT);
                    cmd.Connection = conn;
                    conn.Open();
                    if(cmd.ExecuteNonQuery() > 0)
                    {
                        message.TYPE = 0;
                        message.MSG = "Thêm thành công nhà xuất bản " + doc.NAME;
                    }
                    else
                    {
                        message.TYPE = 1;
                        message.MSG = "Thêm thất bại nhà xuất bản " + doc.NAME;
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
        public static Message update(NXB doc)
        {
            MySqlConnection conn = DBService.GetDBConnection();
            MySqlDataReader reader = null;
            Message message = new Message();
            try
            {

                if (conn != null)
                {
                    var cmd = new MySqlCommand("UPDATE `tb_nhaxuatban` SET `tennxb`=@madk, diachi = @diachi, sdt = @sdt WHERE `manxb`=@makhoa");
                    cmd.Parameters.AddWithValue("@madk", doc.NAME);
                    cmd.Parameters.AddWithValue("@makhoa", doc.ID);
                    cmd.Parameters.AddWithValue("@diachi", doc.DIACHI);
                    cmd.Parameters.AddWithValue("@sdt", doc.SDT);
                    cmd.Connection = conn;
                    conn.Open();
                    if(cmd.ExecuteNonQuery() > 0)
                    {
                        message.TYPE = 0;
                        message.MSG = "Cập nhật thành công nhà xuất bản " + doc.NAME;
                    }
                    else
                    {
                        message.TYPE = 1;
                        message.MSG = "Cập nhật thất bại nhà xuất bản " + doc.NAME;
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