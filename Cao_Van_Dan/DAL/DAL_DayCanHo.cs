using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entities;

namespace DAL
{
    public class DAL_DayCanHo : DBConnect
    {
        DBConnect connect = new DBConnect();
        public DataTable getData()
        {
            return connect.getData("Select * from DayCanHo");
        }
        public int kiemtramatrung(string ma)
        {
            string sql = "Select count(*) from DayCanHo where MaDay = '" + ma.Trim() + "'";
            return connect.kiemtramatrung(ma, sql);
        }
        public bool ThemDayCH(DayCanHo dch)
        {
            string sql = string.Format("Insert into DayCanHo Values ('{0}';, N'{1}', N'{2}')", dch.MaDay, dch.TenDay, dch.ViTri);
            thucthisql(sql);
            return true;
        }
        public bool SuaDCH(DayCanHo dch)
        {
            string sql = "Update DayCanHo Set TenDay = N'" + dch.TenDay + "', ViTri = N'" + dch.ViTri + "' Where MaDay = '" + dch.MaDay + "'";
            thucthisql(sql);
            return true;
        }
        public bool XoaDCH(string ma)
        {
            string sql = "Delete from DayCanHo Where MaDay = '" + ma.Trim() + "'";
            thucthisql(sql);
            return true;
        }
        public string loadcbbDCH(string ma)
        {
            string sql = "Select TenDay From DayCanHo Where MaDay = '" + ma.Trim() + "'";
            return connect.valuecbb(ma, sql);
        }
    }
}
