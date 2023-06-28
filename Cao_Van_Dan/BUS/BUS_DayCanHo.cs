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
    public class BUS_DayCanHo
    {
        DAL_DayCanHo dal_daych = new DAL_DayCanHo();
        public DataTable getData()
        {
            return dal_daych.getData();
        }
        public string valuecbbDCH(string ma)
        {
            return dal_daych.loadcbbDCH(ma);
        }
    }
}
