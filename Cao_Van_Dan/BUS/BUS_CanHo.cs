using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;
using Entities;

namespace BUS
{
    public class BUS_CanHo
    {
        DAL_CanHo dal_ch = new DAL_CanHo();
        public DataTable getData()
        {
            return dal_ch.getData();
        }
        public int kiemtramatrung(string ma)
        {
            return dal_ch.kiemtramatrung(ma);
        }
        public bool ThemCH(CanHo ch)
        {
            return dal_ch.ThemCH(ch);
        }
        public bool SuaCH(CanHo ch)
        {
            return dal_ch.SuaCH(ch);
        }
        public bool XoaCH(string ma)
        {
            return dal_ch.XoaCH(ma);
        }
        public DataTable TimKiem(string sonha, string dientich, string giaban)
        {
            return dal_ch.TimKiemCH(sonha, dientich, giaban);
        }
    }
}
