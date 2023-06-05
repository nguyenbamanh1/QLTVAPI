using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLTVAPI.Models.DAO
{
    public class TaiLieuDAO
    {
        public static List<TaiLieu> getall()
        {
            List<TaiLieu> TaiLieus = new List<TaiLieu>();
            MySqlConnection conn = DBService.GetDBConnection();
            MySqlDataReader reader = null;
            try
            {

                if (conn != null)
                {
                    var cmd = new MySqlCommand("SELECT * FROM `tb_tailieu` a join `tb_theloai` b on a.matheloai = b.matheloai");
                    cmd.Connection = conn;
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        TaiLieu doc = new TaiLieu();
                        doc.MATL = reader.GetString(0);
                        doc.TENTL = reader.GetString(1);
                        doc.MATHELOAI = reader.GetString(2);
                        doc.MATG = reader.GetString(3);
                        doc.MANXB = reader.GetString(4);
                        doc.NAMXB = reader.GetString(5);
                        doc.GIA = reader.GetInt32(6);
                        doc.SOLUONG = reader.GetInt32(7);
                        doc.THELOAI = reader.GetString("tentheloai");
                        TaiLieus.Add(doc);
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
            return TaiLieus;
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
                    var cmd = new MySqlCommand("delete from tb_tailieu where matl = @madg");
                    cmd.Parameters.AddWithValue("@madg", id);
                    cmd.Connection = conn;
                    conn.Open();
                    if(cmd.ExecuteNonQuery() > 0)
                    {
                        message.TYPE = 0;
                        message.MSG = "Xóa thành công tài liệu" + id;
                    }
                    else
                    {
                        message.TYPE = 1;
                        message.MSG = "Xóa thất bại tài liệu" + id;
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

        public static TaiLieu get(string id)
        {
            MySqlConnection conn = DBService.GetDBConnection();
            MySqlDataReader reader = null;
            TaiLieu doc = null;
            try
            {

                if (conn != null)
                {
                    var cmd = new MySqlCommand("SELECT * FROM `tb_tailieu` a join `tb_theloai` b on a.matheloai = b.matheloai where matl = '" + id + "'");
                    cmd.Connection = conn;
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        doc = new TaiLieu();
                        doc.MATL = reader.GetString(0);
                        doc.TENTL = reader.GetString(1);
                        doc.MATHELOAI = reader.GetString(2);
                        doc.MATG = reader.GetString(3);
                        doc.MANXB = reader.GetString(4);
                        doc.NAMXB = reader.GetString(5);
                        doc.GIA = reader.GetInt32(6);
                        doc.SOLUONG = reader.GetInt32(7);
                        doc.THELOAI = reader.GetString("tentheloai");
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

        public static Message put(TaiLieu doc)
        {
            MySqlConnection conn = DBService.GetDBConnection();
            MySqlDataReader reader = null;
            Message message = new Message();
            try
            {

                if (conn != null)
                {
                    var cmd = new MySqlCommand("INSERT INTO `tb_tailieu`(`tentl`, `matheloai`, `matg`, `manxb`, `namxb`, `giabia`, `soluong`) " +
                        "VALUES (@tentl,@matheloai,@matg,@manxb,@namxb,@giabia,@sl)");
                    cmd.Parameters.AddWithValue("@tentl", doc.TENTL);
                    cmd.Parameters.AddWithValue("@matheloai", doc.MATHELOAI);
                    cmd.Parameters.AddWithValue("@matg", doc.MATG);
                    cmd.Parameters.AddWithValue("@manxb", doc.MANXB);
                    cmd.Parameters.AddWithValue("@namxb", doc.NAMXB);
                    cmd.Parameters.AddWithValue("@giabia", doc.GIA);
                    cmd.Parameters.AddWithValue("@sl", doc.SOLUONG);
                    cmd.Connection = conn;
                    conn.Open();
                    if(cmd.ExecuteNonQuery() > 0)
                    {
                        message.TYPE = 0;
                        message.MSG = "Thêm thành công Phiếu mượn " + doc.TENTL;
                    }

                    else {
                        message.TYPE = 1;
                        message.MSG = "Thêm thất bại Phiếu mượn " + doc.TENTL;
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

        public static Message update(TaiLieu doc)
        {
            MySqlConnection conn = DBService.GetDBConnection();
            MySqlDataReader reader = null;
            Message message = new Message();
            try
            {

                if (conn != null)
                {
                    var cmd = new MySqlCommand("UPDATE `tb_tailieu` SET `tentl`= @tentl,`matheloai`= @matheloai,`matg`= @matg,`manxb`= @manxb,`namxb`=@namxb,`giabia`=@giabia,`soluong`=@sl WHERE `matl`=@matl");
                    cmd.Parameters.AddWithValue("@tentl", doc.TENTL);
                    cmd.Parameters.AddWithValue("@matheloai", doc.MATHELOAI);
                    cmd.Parameters.AddWithValue("@matg", doc.MATG);
                    cmd.Parameters.AddWithValue("@manxb", doc.MANXB);
                    cmd.Parameters.AddWithValue("@namxb", doc.NAMXB);
                    cmd.Parameters.AddWithValue("@giabia", doc.GIA);
                    cmd.Parameters.AddWithValue("@sl", doc.SOLUONG);
                    cmd.Parameters.AddWithValue("@matl", doc.MATL);
                    cmd.Connection = conn;
                    conn.Open();
                    if(cmd.ExecuteNonQuery() > 0)
                    {
                        message.TYPE = 0;
                        message.MSG = "Cập nhật thành công Phiếu mượn " + doc.TENTL;
                    }
                    else
                    {
                        message.TYPE = 1;
                        message.MSG = "Cập nhật thất bại Phiếu mượn " + doc.TENTL;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                message.TYPE = 1;
                message.MSG = "Có lỗi xảy ra " + ex.Message;
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