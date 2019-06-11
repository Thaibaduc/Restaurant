using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;

namespace GUI
{
    public partial class QuanLyKho : Form
    {
        List<BLL.ReportProduct> reports;
        public QuanLyKho()
        {
            InitializeComponent();
            reports = new List<ReportProduct>();
            this.LoadData();
        }

        private void LoadData()
        {
            ProductBLL productBLL = new ProductBLL();
            this.reports = productBLL.GetProduct();
            this.dataGridView1.DataSource = reports;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new AddProducts().ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridView dgv = this.dataGridView1;
            int index = dgv.SelectedRows[0].Index;
            List<Product> listProduct = (List<Product>)dgv.DataSource;

            if (MessageBox.Show("Are you sure to delete this emloyee \"" + listProduct[index].Name + "\"", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ProductBLL productBLL = new ProductBLL();
                productBLL.Delete(listProduct[index]);
                this.LoadData();

            }
        }
    }
}
