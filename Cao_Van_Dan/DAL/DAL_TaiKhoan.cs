using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entities;

namespace DAL
{
    public class DAL_TaiKhoan : DBConnect
    {
        DBConnect connect = new DBConnect();
        public DataTable getData()
        {
            return connect.getData("Select * from TaiKhoan");
        }
        public int kiemtramatrung(string ma)
        {
            string sql = "Select count(*) From TaiKhoan Where UserID = '" + ma.Trim() + "'";
            return connect.kiemtramatrung(ma, sql);
        }
        public bool ThemUser(TaiKhoan tk)
        {
            string sql = "INSERT INTO TaiKhoan VALUES('" + tk.UserID + "','" + tk.Pass + "','" + tk.Per + "')";
            thucthisql(sql);
            return true;
        }
    }
}
