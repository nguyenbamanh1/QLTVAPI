using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLTVAPI.Models.DAO
{
    public class TheDangKIDAO
    {
        public static List<TheDangKy> getall()
        {
            List<TheDangKy> docGias = new List<TheDangKy>();
            MySqlConnection conn = DBService.GetDBConnection();
            MySqlDataReader reader = null;
            try
            {

                if (conn != null)
                {
                    var cmd = new MySqlCommand("SELECT * FROM `tb_thedangky`");
                    cmd.Connection = conn;
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        TheDangKy doc = new TheDangKy();
                        doc.MADK = reader.GetString(0);
                        doc.MALOP = reader.GetString(1);
                        doc.HOTEN = reader.GetString(2);
                        doc.NAMSINH = reader.GetString(3);
                        doc.GT = (byte)reader.GetInt32(4);
                        doc.CHUCDANH = reader.GetString(5);
                        doc.KHOAHOC = reader.GetString(6);
                        doc.SDT = reader.GetString(7);
                        doc.EMAIL = reader.GetString(8);

                        doc.LOAIDK = reader.GetString(9);
                        doc.NGAYDK = reader.GetString(10);
                        doc.LEPHI = reader.GetInt32(11);
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
                    var cmd = new MySqlCommand("delete from tb_thedangky where madk = @madg");
                    cmd.Parameters.AddWithValue("@madg", id);
                    cmd.Connection = conn;
                    conn.Open();
                    if(cmd.ExecuteNonQuery() > 0)
                    {
                        message.TYPE = 0;
                        message.MSG = "Xóa thành công thẻ đăng ký" + id;
                    }
                    else
                    {
                        message.TYPE = 1;
                        message.MSG = "Xóa thất bại thẻ đăng ký" + id;
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

        public static TheDangKy get(string id)
        {
            MySqlConnection conn = DBService.GetDBConnection();
            MySqlDataReader reader = null;
            TheDangKy doc = null;
            try
            {

                if (conn != null)
                {
                    var cmd = new MySqlCommand("SELECT * FROM `tb_thedangky` where madk = '" + id + "'");
                    cmd.Connection = conn;
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        doc = new TheDangKy();
                        doc.MADK = reader.GetString(0);
                        doc.MALOP = reader.GetString(1);
                        doc.HOTEN = reader.GetString(2);
                        doc.NAMSINH = reader.GetString(3);
                        doc.GT = (byte)reader.GetInt32(4);
                        doc.CHUCDANH = reader.GetString(5);
                        doc.KHOAHOC = reader.GetString(6);
                        doc.SDT = reader.GetString(7);
                        doc.EMAIL = reader.GetString(8);

                        doc.LOAIDK = reader.GetString(9);
                        doc.NGAYDK = reader.GetString(10);
                        doc.LEPHI = reader.GetInt32(11);
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

        public static Message put(TheDangKy doc)
        {
            MySqlConnection conn = DBService.GetDBConnection();
            MySqlDataReader reader = null;
            Message message = new Message();
            try
            {

                if (conn != null)
                {
                    var cmd = new MySqlCommand("INSERT INTO `tb_thedangky` (`malop`, `hoten`, `namsinh`, `gioitinh`, `chucdanh`, `khoahoc`, `sdt`, `email`, `loaidk`, `ngaydk`, `lephi`) " +
                        " VALUES (@malop, @hoten, @namsinh, @gioitinh, @chucdanh, @khoahoc, @sdt, @email, @loaidk, @ngaydk, @lephi)");
                    cmd.Parameters.AddWithValue("@malop", doc.MALOP);
                    cmd.Parameters.AddWithValue("@hoten", doc.HOTEN);
                    cmd.Parameters.AddWithValue("@namsinh", doc.NAMSINH);
                    cmd.Parameters.AddWithValue("@gioitinh", doc.GT);
                    cmd.Parameters.AddWithValue("@chucdanh", doc.CHUCDANH);
                    cmd.Parameters.AddWithValue("@khoahoc", doc.KHOAHOC);
                    cmd.Parameters.AddWithValue("@sdt", doc.SDT);
                    cmd.Parameters.AddWithValue("@email", doc.EMAIL);
                    cmd.Parameters.AddWithValue("@loaidk", doc.LOAIDK);
                    cmd.Parameters.AddWithValue("@ngaydk", DateTime.ParseExact(doc.NGAYDK, "dd/MM/yyyy", null));
                    cmd.Parameters.AddWithValue("@lephi", doc.LEPHI);
                    cmd.Connection = conn;
                    conn.Open();
                    if(cmd.ExecuteNonQuery() > 0)
                    {
                        message.TYPE = 0;
                        message.MSG = "Thêm thành công Phiếu mượn " + doc.HOTEN;
                    }
                    else {
                        message.TYPE = 1;
                        message.MSG = "Thêm thất bại Phiếu mượn " + doc.HOTEN;
                    }
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                message.TYPE = 1;
                message.MSG = "Có lỗi xảy ra " + ex.Message + " " + ex.StackTrace;
            }
            finally
            {
                if (conn != null) conn.Close();
                if (reader != null) reader.Close();
            }
            return message;
        }

        public static Message update(TheDangKy doc)
        {
            MySqlConnection conn = DBService.GetDBConnection();
            MySqlDataReader reader = null;
            Message message = new Message();
            try
            {

                if (conn != null)
                {
                    var cmd = new MySqlCommand("UPDATE `tb_thedangky` SET `malop`=@malop,`hoten`=@hoten,`namsinh`=@namsinh,`gioitinh`=@gioitinh,`chucdanh`=@chucdanh," +
                        "`khoahoc`=@khoahoc,`sdt`=@sdt,`email`=@email,`loaidk`=@loaidk,`ngaydk`=@ngaydk,`lephi`=@lephi WHERE madk = @madk");
                    cmd.Parameters.AddWithValue("@malop", doc.MALOP);
                    cmd.Parameters.AddWithValue("@hoten", doc.HOTEN);
                    cmd.Parameters.AddWithValue("@namsinh", doc.NAMSINH);
                    cmd.Parameters.AddWithValue("@gioitinh", doc.GT);
                    cmd.Parameters.AddWithValue("@chucdanh", doc.CHUCDANH);
                    cmd.Parameters.AddWithValue("@khoahoc", doc.KHOAHOC);
                    cmd.Parameters.AddWithValue("@sdt", doc.SDT);
                    cmd.Parameters.AddWithValue("@email", doc.EMAIL);
                    cmd.Parameters.AddWithValue("@loaidk", doc.LOAIDK);
                    cmd.Parameters.AddWithValue("@ngaydk", DateTime.ParseExact(doc.NGAYDK, "dd/MM/yyyy", null));
                    cmd.Parameters.AddWithValue("@lephi", doc.LEPHI);
                    cmd.Parameters.AddWithValue("@madk", doc.MADK);
                    cmd.Connection = conn;
                    conn.Open();
                    if(cmd.ExecuteNonQuery() > 0)
                    {
                        message.TYPE = 0;
                        message.MSG = "Cập nhật thành công thẻ đăng ký " + doc.HOTEN;
                    }
                    else
                    {
                        message.TYPE = 1;
                        message.MSG = "Cập nhật thất bại thẻ đăng ký " + doc.HOTEN;
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