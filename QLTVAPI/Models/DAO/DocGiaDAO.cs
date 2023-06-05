using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
namespace QLTVAPI.Models.DAO
{
    public class DocGiaDAO
    {
        public static List<DocGia> getall()
        {
            List<DocGia> docGias = new List<DocGia>();
            MySqlConnection conn = DBService.GetDBConnection();
            MySqlDataReader reader = null;
            try
            {
                
                if(conn != null)
                {
                    var cmd = new MySqlCommand("SELECT * FROM `tb_docgia` a join `tb_thedangky` b on a.madk = b.madk");
                    cmd.Connection = conn;
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        DocGia doc = new DocGia();
                        doc.MADG = reader.GetString("madg");
                        doc.MADK = reader.GetString("madk");
                        doc.NGAYDK = DateTime.Parse(reader.GetString("ngaycap")).ToString("dd/MM/yyyy");
                        doc.HSD = DateTime.Parse(reader.GetString("hansudung")).ToString("dd/MM/yyyy");
                        doc.TINHTRANG = reader.GetString("tinhtrang");
                        doc.HOTEN = reader.GetString("hoten");
                        doc.GT = (byte)reader.GetInt32("gioitinh");
                        docGias.Add(doc);
                    }
                }
            }
            catch(Exception ex)
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
                    var cmd = new MySqlCommand("delete from tb_docgia where madg = @madg");
                    cmd.Parameters.AddWithValue("@madg", id);
                    cmd.Connection = conn;
                    conn.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        message.TYPE = 0;
                        message.MSG = "Xóa thành công độc giả " + id;
                    }
                    else
                    {
                        message.TYPE = 1;
                        message.MSG = "Xóa thất bại độc giả " + id;
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

        public static DocGia get(string id)
        {
            MySqlConnection conn = DBService.GetDBConnection();
            MySqlDataReader reader = null;
            DocGia doc = null;
            try
            {

                if (conn != null)
                {
                    var cmd = new MySqlCommand("SELECT * FROM `tb_docgia` a join `tb_thedangky` b on a.madk = b.madk where madg = '"+id+"'");
                    cmd.Connection = conn;
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        doc = new DocGia();
                        doc.MADG = reader.GetString("madg");
                        doc.MADK = reader.GetString("madk");
                        doc.NGAYDK = DateTime.Parse(reader.GetString("ngaycap")).ToString("dd/MM/yyyy");
                        doc.HSD = DateTime.Parse(reader.GetString("hansudung")).ToString("dd/MM/yyyy");
                        doc.TINHTRANG = reader.GetString("tinhtrang");
                        doc.HOTEN = reader.GetString("hoten");
                        doc.GT = (byte)reader.GetInt32("gioitinh");
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

        public static Message put(DocGia doc)
        {
            MySqlConnection conn = DBService.GetDBConnection();
            MySqlDataReader reader = null;
            Message message = new Message();
            try
            {

                if (conn != null)
                {
                    var cmd = new MySqlCommand("insert into tb_docgia (madk, ngaycap, hansudung, tinhtrang) values(@madk, @ngaycap, @hsd, @tinhtrang)");
                    cmd.Parameters.AddWithValue("@madk", doc.MADK);
                    cmd.Parameters.AddWithValue("@ngaycap", DateTime.UtcNow);
                    
                    cmd.Parameters.AddWithValue("@hsd", DateTime.ParseExact(doc.HSD, "dd/MM/yyyy", null));
                    cmd.Parameters.AddWithValue("@tinhtrang", doc.TINHTRANG);
                    cmd.Connection = conn;
                    conn.Open();
                    if(cmd.ExecuteNonQuery() > 0)
                    {
                        message.TYPE = 0;
                        message.MSG = "Thêm thành công độc giả " + doc.MADG;
                    }
                    else
                    {
                        message.TYPE = 1;
                        message.MSG = "Thêm thất bại độc giả " + doc.MADG;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                message.TYPE = 1;
                message.MSG = "Có lỗi xảy ra " + doc.HSD;
            }
            finally
            {
                if (conn != null) conn.Close();
                if (reader != null) reader.Close();
            }
            return message;
        }

        public static Message update(DocGia doc)
        {
            MySqlConnection conn = DBService.GetDBConnection();
            MySqlDataReader reader = null;
            Message message = new Message();
            try
            {

                if (conn != null)
                {
                    var cmd = new MySqlCommand("UPDATE `tb_docgia` SET `madk`=@madk,`ngaycap`= @ngaycap,`hansudung`= @hsd,`tinhtrang`=@tinhtrang WHERE `madg`=@madg");
                    cmd.Parameters.AddWithValue("@madk", doc.MADK);
                    cmd.Parameters.AddWithValue("@ngaycap", DateTime.ParseExact(doc.NGAYDK, "dd/MM/yyyy", null));
                    cmd.Parameters.AddWithValue("@hsd", DateTime.ParseExact(doc.HSD, "dd/MM/yyyy", null));
                    cmd.Parameters.AddWithValue("@tinhtrang", doc.TINHTRANG);
                    cmd.Parameters.AddWithValue("@madg", doc.MADG);
                    cmd.Connection = conn;
                    conn.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        message.TYPE = 0;
                        message.MSG = "Cập nhật thành công độc giả " + doc.MADG;
                    }
                    else
                    {
                        message.TYPE = 1;
                        message.MSG = "Cập nhật thất bại độc giả " + doc.MADG;
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