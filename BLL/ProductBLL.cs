using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ReportProduct
    {
        public string DateAdd;
        public string DateExpiry;
        public string Name;
        public int Quantity;

        public string dateAdd
        {
            get { return DateAdd; }
        }
        public string dateExpiry
        {
            get { return dateExpiry; }
        }
        public string name
        {
            get { return Name; }
        }
        public int quantity
        {
            get { return Quantity; }
            set { Quantity = value; }
        }
    }
    public class ProductBLL
    {
        //public List<Product> ListTablesByKho(Kho kho)
        //{
        //    return Connection.DBContext.Products.Where(t => t.KhoID == kho.ID).ToList();
        //}

        public List<Product> ListAvailableProduct()
        {
            return Connection.DBContext.Products.ToList();
        }
     
        public Product AddProduct(Product product)
        {
            if (product.Name != null && product.Name != "")
            {
                Connection.DBContext.Products.Add(product);
                Connection.DBContext.SaveChanges();
            }
            return product;
        }

        public void Delete(Product product)
        {
            Connection.DBContext.Products.Attach(product);
            Connection.DBContext.Products.Remove(product);
            Connection.DBContext.SaveChanges();
        }

        public void Update(Product product)
        {
            Connection.DBContext.Products.AddOrUpdate(product);
            Connection.DBContext.SaveChanges();
        }

        public List<ReportProduct> GetProduct()
        {
            var report = from od in Connection.DBContext.Products
                             //select new { od.Name, od.Quantity, od.DateAdd, od.DateExpiry } into aa

                         select new ReportProduct
                         {
                             DateAdd = od.DateAdd.ToString(),
                             DateExpiry = od.DateExpiry.ToString(),
                             Name = od.Name,
                             Quantity = (int)od.Quantity,
                         };
            return report.ToList();
        }
    }
}
