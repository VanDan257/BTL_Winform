using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entities;

namespace DAL
{
    public class DAL_CanHo : DBConnect
    {
        //chứa mọi xử lý liên quan đến CSDL
        //xử lý lấy dữ liệu để đưa ra dgv
        //khởi tạo đối tượng thuộc lớp DBConnect
        DBConnect connect = new DBConnect();
        public DataTable getData()
        {
            string sql = "Select * from CanHo";
            return connect.getData(sql);
        }
        public int kiemtramatrung(string ma)
        {
            string sql = "Select count(*) from CanHo where SoNha = '" + ma.Trim() + "'";
            return connect.kiemtramatrung(ma, sql);
        }
        public bool ThemCH(CanHo ch)
        {
            string sql = string.Format("Insert into CanHo values('{0}','{1}', '{2}', '{3}', '{4}')", ch.SoNha, ch.DienTich, ch.GiaBan, ch.TinhTrang, ch.MaDay);
            thucthisql(sql);
            return true;
        }
        public bool SuaCH(CanHo ch)
        {
            string sql = string.Format("Update CanHo set DienTich = '{1}', GiaBan = '{2}', TinhTrang = '{3}', MaDay = '{4}' Where SoNha = '{0}' ", ch.SoNha, ch.DienTich, ch.GiaBan, ch.TinhTrang, ch.MaDay);
            thucthisql(sql);
            return true;
        }
        public bool XoaCH(string ma)
        {
            string sql = "DELETE from CanHo Where SoNha = '" + ma.Trim() + "'";
            thucthisql(sql);
            return true;
        }
        public DataTable TimKiemCH(string SoNha, string DienTich, string GiaBan)
        {
            string sql = "Select * from CanHo";
            string dk = "";
            if(SoNha.Trim() == "" && DienTich.Trim() == "" && GiaBan.Trim() == "")
            {
                return null;
            }
            if(SoNha.Trim() != "" && dk == "")
            {
                dk += " SoNha like '%" + SoNha.Trim() + "%'";
            }
            if(DienTich.Trim() != "" && dk != "")
            {
                dk += " and DienTich between  " + DienTich + " - 5 and " + DienTich + " + 5";
            }
            if (DienTich.Trim() != "" && dk == "")
            {
                dk += " DienTich between  " + DienTich + " - 5 and " + DienTich + " + 5";
            }
            if (GiaBan.Trim() != "" && dk != "")
            {
                dk += " and GiaBan between  " + GiaBan + " - 50 and " + GiaBan + " + 50";
            }
            if (GiaBan.Trim() != "" && dk == "")
            {
                dk += " GiaBan between  " + GiaBan + " - 20 and " + GiaBan + " + 20";
            }
            if (dk != "")
            {
                sql += " Where " + dk;
            }
            return connect.getData(sql);
        }
    }
}
