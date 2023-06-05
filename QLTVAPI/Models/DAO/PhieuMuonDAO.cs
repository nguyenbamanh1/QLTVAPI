using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLTVAPI.Models.DAO
{
    public class PhieuMuonDAO
    {
        public static List<PhieuMuon> getall()
        {
            List<PhieuMuon> PhieuMuons = new List<PhieuMuon>();
            MySqlConnection conn = DBService.GetDBConnection();
            MySqlDataReader reader = null;
            try
            {

                if (conn != null)
                {
                    var cmd = new MySqlCommand("SELECT * FROM `tb_phieumuontra` a join `tb_docgia` b on a.madg = b.madg join `tb_thedangky` c on b.madk = c.madk");
                    cmd.Connection = conn;
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        PhieuMuon doc = new PhieuMuon();
                        doc.MAMT = reader.GetString(0);
                        doc.MATT = reader.GetString(1);
                        doc.MADG = reader.GetString(2);
                        doc.MATL = reader.GetString(3);
                        doc.HINHTHUC = reader.GetString(4);
                        doc.GHICHU = reader.GetString(5);
                        doc.TINHTRANG = reader.GetString(6);
                        doc.GIA = reader.GetInt32(7);
                        doc.NGAYMUON = reader.GetString(8);
                        doc.NGAYTRA = reader.GetString(9);
                        doc.HOTEN = reader.GetString("hoten");
                        doc.GHICHU = reader.GetString("ghichu");
                        PhieuMuons.Add(doc);
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
            return PhieuMuons;
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
                    var cmd = new MySqlCommand("delete from tb_phieumuontra where mamt = @madg");
                    cmd.Parameters.AddWithValue("@madg", id);
                    cmd.Connection = conn;
                    conn.Open();
                    if(cmd.ExecuteNonQuery() > 0)
                    {
                        message.TYPE = 0;
                        message.MSG = "Xóa thành công Phiếu mượn " + id;
                    }
                    else
                    {
                        message.TYPE = 1;
                        message.MSG = "Xóa thất bại Phiếu mượn " + id;
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

        public static PhieuMuon get(string id)
        {
            MySqlConnection conn = DBService.GetDBConnection();
            MySqlDataReader reader = null;
            PhieuMuon doc = null;
            try
            {

                if (conn != null)
                {
                    var cmd = new MySqlCommand("SELECT * FROM `tb_phieumuontra` a join `tb_docgia` b on a.madg = b.madg join `tb_thedangky` c on b.madk = c.madk where a.mamt = '" + id + "'");
                    cmd.Connection = conn;
                    conn.Open();
                    reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        doc = new PhieuMuon();
                        doc.MAMT = reader.GetString(0);
                        doc.MATT = reader.GetString(1);
                        doc.MADG = reader.GetString(2);
                        doc.MATL = reader.GetString(3);
                        doc.HINHTHUC = reader.GetString(4);
                        doc.GHICHU = reader.GetString(5);
                        doc.TINHTRANG = reader.GetString(6);
                        doc.GIA = reader.GetInt32(7);
                        doc.NGAYMUON = reader.GetString(8);
                        doc.NGAYTRA = reader.GetString(9);
                        doc.HOTEN = reader.GetString("hoten");
                        doc.GHICHU = reader.GetString("ghichu");
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

        public static Message put(PhieuMuon doc)
        {
            MySqlConnection conn = DBService.GetDBConnection();
            MySqlDataReader reader = null;
            Message message = new Message();

            try
            {

                if (conn != null)
                {
                    var cmd = new MySqlCommand("INSERT INTO `tb_phieumuontra`(`matt`, `madg`, `matl`, `ngaymuon`, `ngaytra`, `tinhtrang`, `hinhthuc`, `ghichu`, `gia`) VALUES (@matt, @madg, @matl, @ngaymuon, @ngaytra, @tinhtrang, @hinhthuc, @ghichu, @gia)");
                    cmd.Parameters.AddWithValue("@matt", doc.MATT);
                    cmd.Parameters.AddWithValue("@madg", doc.MADG);
                    cmd.Parameters.AddWithValue("@ngaymuon", DateTime.UtcNow);
                    cmd.Parameters.AddWithValue("@ngaytra", DateTime.ParseExact(doc.NGAYTRA, "dd/MM/yyyy", null));
                    cmd.Parameters.AddWithValue("@tinhtrang", doc.TINHTRANG);
                    cmd.Parameters.AddWithValue("@matl", doc.MATL);
                    cmd.Parameters.AddWithValue("@hinhthuc", doc.HINHTHUC);
                    cmd.Parameters.AddWithValue("@ghichu", doc.GHICHU);
                    cmd.Parameters.AddWithValue("@gia", doc.GIA);
                    cmd.Connection = conn;
                    conn.Open();
                    if(cmd.ExecuteNonQuery() > 0)
                    {
                        message.TYPE = 0;
                        message.MSG = "Thêm thành công Phiếu mượn ";
                    }
                    else
                    {
                        message.TYPE = 0;
                        message.MSG = "Thêm thất bại Phiếu mượn ";
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

        public static Message update(PhieuMuon doc)
        {
            MySqlConnection conn = DBService.GetDBConnection();
            MySqlDataReader reader = null;
            Message message = new Message();

            try
            {

                if (conn != null)
                {
                    var cmd = new MySqlCommand("UPDATE `tb_phieumuontra` SET `matt`=@matt,`madg`=@madg,`matl`=@matl,`ngaymuon`=@ngaymuon,`ngaytra`=@ngaytra,`tinhtrang`=@tinhtrang, `hinhthuc` = @hinhthuc, `ghichu` = @ghichu, `gia`= @gia WHERE `mamt`=@mamt");
                    cmd.Parameters.AddWithValue("@matt", doc.MATT);
                    cmd.Parameters.AddWithValue("@madg", doc.MADG);
                    cmd.Parameters.AddWithValue("@ngaymuon", DateTime.ParseExact(doc.NGAYMUON, "dd/MM/yyyy", null));
                    cmd.Parameters.AddWithValue("@ngaytra", DateTime.ParseExact(doc.NGAYTRA, "dd/MM/yyyy", null));
                    cmd.Parameters.AddWithValue("@tinhtrang", doc.TINHTRANG);
                    cmd.Parameters.AddWithValue("@matl", doc.MATL);
                    cmd.Parameters.AddWithValue("@hinhthuc", doc.HINHTHUC);
                    cmd.Parameters.AddWithValue("@ghichu", doc.GHICHU);
                    cmd.Parameters.AddWithValue("@gia", doc.GIA);
                    cmd.Parameters.AddWithValue("@mamt", doc.MAMT);

                    cmd.Connection = conn;
                    conn.Open();
                    if(cmd.ExecuteNonQuery() > 0)
                    {
                        message.TYPE = 0;
                        message.MSG = "Cập nhật thành công Phiếu mượn " + doc.MAMT;
                    }
                    else
                    {
                        message.TYPE = 1;
                        message.MSG = "Cập nhật thất bại Phiếu mượn " + doc.MAMT;
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