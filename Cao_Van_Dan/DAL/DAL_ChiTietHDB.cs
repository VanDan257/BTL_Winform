using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entities;

namespace DAL
{
    public class DAL_ChiTietHDB : DBConnect
    {
        DBConnect connect = new DBConnect();
        public DataTable getData(string ma)
        {
            return connect.getData("Select * from CHiTietHDB Where MaHDB = '" + ma.Trim() + "'");
        }
        public int kiemtramatrung(string ma)
        {
            string sql = "Select count(*) from ChiTietHDB where MaHDB = '" + ma.Trim() + "'";
            return connect.kiemtramatrung(ma, sql);
        }
        public bool ThemCTHDB(ChiTietHoaDonBan CT)
        {
            string sql = string.Format("Insert into ChiTietHDB Values ('{0}', '{1}', '{2}', '{3}', '{4}')", CT.MaHDB, CT.SoNha, CT.DonGia, CT.GiamGia, CT.ThanhTien);
            string TTCanHo = string.Format("Update CanHo Set TinhTrang = N'Đã Bán' Where SoNha = '" + CT.SoNha + "'");
            thucthisql(sql);
            thucthisql(TTCanHo);
            return true;
        }
        public bool SuaCTHDB(ChiTietHoaDonBan CT)
        {
            string sql = string.Format("Update ChiTietHDB Set MaHDB = '{0}' Where SoNha = '{1}', DonGia = '{2}', GiamGia = '{3}', ThanhTien = '{4}'", CT.MaHDB, CT.SoNha, CT.DonGia, CT.GiamGia, CT.ThanhTien);
            thucthisql(sql);
            return true;
        }
        public bool XoaCTHDB(string ma)
        {
            string sql = "Delete from ChiTietHDB where MaHDB = '" + ma.Trim() + "'";
            string TTCanHo = string.Format("Update CanHo Set TinhTrang = N'Còn' Where SoNha = '" + ma.Trim() + "'");
            thucthisql(sql);
            thucthisql(TTCanHo);
            return true;
        }
        public DataTable TimKiem(string mahd, string sonha)
        {
            string sql = "Select * from ChiTietHDB";
            string dk = "";
            if (mahd.Trim() == "" && sonha.Trim() == "")
            {
                // 1
                return null;
            }
            if (mahd.Trim() != "" && dk == "")
            {
                // 2
                dk += " MaHDB like '%" + mahd.Trim() + "%'";
            }
            if (sonha.Trim() != "" && dk != "")
            {
                // 3
                dk += " and SoNha like '%" + sonha.Trim() + "%'";
            }
            if (sonha.Trim() != "" && dk == "")
            {
                // 4
                dk += "SoNha like '%" + sonha.Trim() + "%'";
            }
            if (dk != "")
            {
                sql += " WHERE " + dk;
            }
            return connect.getData(sql);
        }
        public double ThongKeDoanhThuTheoThang(string thang, string nam)
        {
            string sql = "SELECT SUM(TongTien) from HoaDonBan Where Month(ngayban) = " + thang.Trim() + " and Year(ngayban) = " + nam.Trim() + "";
            return connect.ThongKeDoanhThu(sql);
        }
        public DataTable ThongKeHoaDonTheoThang(string thang, string nam)
        {
            string sql = string.Format("Select H.MaHDB, H.MaNV, H.MaKH, h.NgayBan, C.SoNha, C.DonGia, C.GiamGia, C.ThanhTien from HoaDonBan H inner join ChiTietHDB C on H.MaHDB = C.MaHDB Where Month(ngayban) = " + thang.Trim() + " and Year(ngayban) = " + nam.Trim() + "");
            return connect.getData(sql);
        }
        public DataTable ThongKeHoaDonTheoNam(string nam)
        {
            string sql = string.Format("Select H.MaHDB, H.MaNV, H.MaKH, h.NgayBan, C.SoNha, C.DonGia, C.GiamGia, C.ThanhTien from HoaDonBan H inner join ChiTietHDB C on H.MaHDB = C.MaHDB Where Year(ngayban) = " + nam.Trim() + "");
            return connect.getData(sql);
        }
        public double ThongKeDoanhThuTheoNam(string nam)
        {
            string sql = "SELECT SUM(TongTien) from HoaDonBan Where Year(ngayban) = " + nam.Trim() + "";
            return connect.ThongKeDoanhThu(sql);
        }
    }
}
