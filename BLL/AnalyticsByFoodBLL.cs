using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ReportFood : IComparable
    {
        public string Name;
        public int Quantity;

        public int quantity
        {
            get { return Quantity; }
            set { Quantity = value; }
        }

        public string name
        {
            get { return Name; }
            set { Name = value; }
        }

        public int CompareTo(object obj)
        {
            ReportFood rp = obj as ReportFood;
            if (this.Quantity.CompareTo(rp.Quantity) == 1)
                return -1;
            if (this.Quantity.CompareTo(rp.Quantity) == 0)
                return 0;
            return 1;

        }

        //public int CompareTo(object obj)
        //{
        //    return Quantity.CompareTo(obj);
        //}
    }
    public class AnalyticsByFoodBLL
    {
        public List<ReportFood> GetAnalyticsByMonth(int month, int year)
        {
            var report = from od in Connection.DBContext.OrderDetails                      
                         select new { od.MenuItem.Name, od.Quantity, od.DateCreated } into aa
                         group aa by new { aa.Name } into bb
                         select new ReportFood
                         {
                             Name = bb.Key.Name,
                             Quantity = (int)bb.Sum(x => x.Quantity),                             
                         };
            return report.ToList();
        }
    }
}
