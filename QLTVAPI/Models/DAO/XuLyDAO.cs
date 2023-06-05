using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLTVAPI.Models.DAO
{
    public class XuLyDAO
    {
        public static List<XuLy> getall()
        {
            List<XuLy> docGias = new List<XuLy>();
            MySqlConnection conn = DBService.GetDBConnection();
            MySqlDataReader reader = null;
            try
            {

                if (conn != null)
                {
                    var cmd = new MySqlCommand("SELECT * FROM `tb_xulyvipham` a join `tb_phieumuontra` b on a.mamt = b.mamt join `tb_docgia` c on b.madg = c.madg join `tb_thedangky` d on c.madk = d.madk;");
                    cmd.Connection = conn;
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        XuLy doc = new XuLy();
                        doc.MAMT = reader.GetString(0);
                        doc.HINHTHUCXL = reader.GetString(1);
                        doc.NGAYXL = reader.GetString(2);
                        doc.NGAYMOTHE = reader.GetString(3);
                        doc.PHAT = reader.GetInt32(4);
                        doc.HOTEN = reader.GetString("hoten");
                        doc.NGUYENNHAN = reader.GetString("tinhtrang");
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
                    var cmd = new MySqlCommand("delete from tb_xulyvipham where mamt = @madg");
                    cmd.Parameters.AddWithValue("@madg", id);
                    cmd.Connection = conn;
                    conn.Open();
                    if(cmd.ExecuteNonQuery() > 0)
                    {
                        message.TYPE = 0;
                        message.MSG = "Xóa thành công xử lý vi phạm " + id;
                    }
                    else
                    {
                        message.TYPE = 1;
                        message.MSG = "Xóa thất bại xử lý vi phạm " + id;
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

        public static XuLy get(string id)
        {
            MySqlConnection conn = DBService.GetDBConnection();
            MySqlDataReader reader = null;
            XuLy doc = null;
            try
            {

                if (conn != null)
                {
                    var cmd = new MySqlCommand("SELECT * FROM `tb_xulyvipham` a join `tb_phieumuontra` b on a.mamt = b.mamt join `tb_docgia` c on b.madg = c.madg join `tb_thedangky` d on c.madk = d.madk where a.mamt = '" + id + "' ");
                    cmd.Connection = conn;
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        doc = new XuLy();
                        doc.MAMT = reader.GetString(0);
                        doc.HINHTHUCXL = reader.GetString(1);
                        doc.NGAYXL = reader.GetString(2);
                        doc.NGAYMOTHE = reader.GetString(3);
                        doc.PHAT = reader.GetInt32(4);
                        doc.HOTEN = reader.GetString("hoten");
                        doc.NGUYENNHAN = reader.GetString("tinhtrang");
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

        public static Message put(XuLy doc)
        {
            MySqlConnection conn = DBService.GetDBConnection();
            MySqlDataReader reader = null;
            Message message = new Message();
            try
            {

                if (conn != null)
                {
                    var cmd = new MySqlCommand("insert into tb_xulyvipham (hinhthucxl, ngayxl, ngaymothe, tienphat) values(@madk, @gt, @sdt, @tien)");
                    cmd.Parameters.AddWithValue("@madk", doc.HINHTHUCXL);
                    cmd.Parameters.AddWithValue("@gt", DateTime.UtcNow);
                    cmd.Parameters.AddWithValue("@sdt", DateTime.ParseExact(doc.NGAYMOTHE, "dd/MM/yyyy", null));
                    cmd.Parameters.AddWithValue("@tien", doc.PHAT);
                    cmd.Connection = conn;
                    conn.Open();
                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        message.TYPE = 0;
                        message.MSG = "Thêm thành công xử lý vi phạm ";
                    }
                    else
                    {
                        message.TYPE = 1;
                        message.MSG = "Thêm thất bại xử lý vi phạm ";
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

        public static Message update(XuLy doc)
        {
            MySqlConnection conn = DBService.GetDBConnection();
            MySqlDataReader reader = null;
            Message message = new Message();
            try
            {

                if (conn != null)
                {
                    var cmd = new MySqlCommand("update tb_xulyvipham set hinhthucxuly = @madk, ngayxl = @gt, ngaymothe = @sdt, tienphat = @tien where mamt = @mamt");
                    cmd.Parameters.AddWithValue("@madk", doc.HINHTHUCXL);
                    cmd.Parameters.AddWithValue("@gt", DateTime.ParseExact(doc.NGAYXL, "dd/MM/yyyy", null));
                    cmd.Parameters.AddWithValue("@sdt", DateTime.ParseExact(doc.NGAYMOTHE, "dd/MM/yyyy", null));
                    cmd.Parameters.AddWithValue("@tien", doc.PHAT);
                    cmd.Parameters.AddWithValue("@mamt", doc.MAMT);
                    cmd.Connection = conn;
                    conn.Open();
                    if(cmd.ExecuteNonQuery() > 0)
                    {
                        message.TYPE = 0;
                        message.MSG = "Cập nhật thành công xử lý vi phạm";
                    }
                    else
                    {
                        message.TYPE = 1;
                        message.MSG = "Cập nhật thất bại xử lý vi phạm";
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