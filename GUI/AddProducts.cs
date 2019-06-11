using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class AddProducts : Form
    {
        public AddProducts()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.AddProduct();
        }

        private void AddProduct()
        {
            if (this.tvName.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm", "Warning", MessageBoxButtons.OK);
            }
            else
            {
                if (this.tvSoLuong.Text.Trim() == "")
                {
                    MessageBox.Show("vui lòng nhập số lượng sản phẩm", "Warning", MessageBoxButtons.OK);
                }
                else
                {
                    Product p = new Product();
                    p.Name = tvName.Text;
                    p.Quantity = int.Parse(tvSoLuong.Text);
                    p.DateAdd = dateTimePicker1.Value;
                    p.DateExpiry = dateTimePicker2.Value;

                    ProductBLL productBLL = new ProductBLL();
                    Product product = productBLL.AddProduct(p);
                    this.Close();

                }
            }
        }
    }

}
