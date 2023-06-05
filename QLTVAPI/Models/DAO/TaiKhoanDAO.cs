using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLTVAPI.Models.DAO
{
    public class TaiKhoanDAO
    {
        public static List<TaiKhoan> getall()
        {
            List<TaiKhoan> docGias = new List<TaiKhoan>();
            MySqlConnection conn = DBService.GetDBConnection();
            MySqlDataReader reader = null;
            try
            {

                if (conn != null)
                {
                    var cmd = new MySqlCommand("SELECT * FROM `tb_taikhoan`");
                    cmd.Connection = conn;
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        TaiKhoan doc = new TaiKhoan();
                        doc.MATT = reader.GetString(0);
                        doc.TAIKHOAN = reader.GetString(1);
                        doc.MATKHAU = reader.GetString(2);
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
                    var cmd = new MySqlCommand("delete from tb_taikhoan where taikhoan = @madg");
                    cmd.Parameters.AddWithValue("@madg", id);
                    cmd.Connection = conn;
                    conn.Open();
                    int c = cmd.ExecuteNonQuery();
                    if(c > 0)
                    {
                        message.TYPE = 0;
                        message.MSG = "Xóa thành công tài khoản";
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

        public static TaiKhoan get(string id)
        {
            MySqlConnection conn = DBService.GetDBConnection();
            MySqlDataReader reader = null;
            TaiKhoan doc = null;
            try
            {

                if (conn != null)
                {
                    var cmd = new MySqlCommand("SELECT * FROM `tb_taikhoan` where taikhoan = '" + id + "'");
                    cmd.Connection = conn;
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        doc = new TaiKhoan();
                        doc.MATT = reader.GetString(0);
                        doc.TAIKHOAN = reader.GetString(1);
                        doc.MATKHAU = reader.GetString(2);
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

        public static Message put(TaiKhoan doc)
        {
            MySqlConnection conn = DBService.GetDBConnection();
            MySqlDataReader reader = null;
            Message message = new Message();
            try
            {
                if(  string.IsNullOrEmpty(doc.TAIKHOAN.Trim()) || string.IsNullOrEmpty(doc.MATKHAU.Trim()) || string.IsNullOrEmpty(doc.MATT.Trim())|| doc.TAIKHOAN.Trim().Length < 5 || doc.MATKHAU.Trim().Length < 5)
                {
                    message.TYPE = 1;
                    message.MSG = "Tài khoản và mật khẩu phải hơn 5 ký tự";
                    return message;
                }


                if (conn != null)
                {
                    var cmd = new MySqlCommand("insert into tb_taikhoan (maTT,taikhoan, matkhau) values(@matt, @tk, @mk)");
                    cmd.Parameters.AddWithValue("@matt", doc.MATT);
                    cmd.Parameters.AddWithValue("@tk", doc.TAIKHOAN);
                    cmd.Parameters.AddWithValue("@mk", doc.MATKHAU);
                    cmd.Connection = conn;
                    conn.Open();
                    if(cmd.ExecuteNonQuery() >= 1)
                    {
                        message.TYPE = 0;
                        message.MSG = "Thêm thành công tài khoản";
                    }
                    else
                    {
                        message.TYPE = 1;
                        message.MSG = "Thêm thất bại tài khoản";
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

        public static Message update(TaiKhoan doc)
        {
            MySqlConnection conn = DBService.GetDBConnection();
            MySqlDataReader reader = null;
            Message message = new Message();
            try
            {

                if (conn != null)
                {
                    var cmd = new MySqlCommand("update tb_taikhoan set matkhau = @mk where taikhoan = @tk");
                    cmd.Parameters.AddWithValue("@tk", doc.TAIKHOAN);
                    cmd.Parameters.AddWithValue("@mk", doc.MATKHAU);
                    cmd.Connection = conn;
                    conn.Open();
                    if(cmd.ExecuteNonQuery() >= 1)
                    {
                        message.TYPE = 0;
                        message.MSG = "Cập nhật thành công tài khoản";
                    }
                    else
                    {
                        message.TYPE = 1;
                        message.MSG = "Cập nhật thất bại tài khoản";
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


        public static bool login(TaiKhoan taiKhoan)
        {
            MySqlConnection conn = DBService.GetDBConnection();
            MySqlDataReader reader = null;
            TaiKhoan doc = null;
            bool ok = false;
            try
            {

                if (conn != null)
                {
                    var cmd = new MySqlCommand("SELECT * FROM `tb_taikhoan` where taikhoan = @tk and matkhau = @mk ");
                    cmd.Parameters.AddWithValue("@tk", taiKhoan.TAIKHOAN);
                    cmd.Parameters.AddWithValue("@mk", taiKhoan.MATKHAU);
                    cmd.Connection = conn;
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        doc = new TaiKhoan();
                        doc.MATT = reader.GetString(0);
                        doc.TAIKHOAN = reader.GetString(1);
                        doc.MATKHAU = reader.GetString(2);
                        ok = true;
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
            return ok;
        }
    }
}