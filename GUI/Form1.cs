using BLL;
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
    public partial class AnalyticsByFood : Form
    {
        List<BLL.ReportFood> rp;
        public AnalyticsByFood()
        {
            InitializeComponent();
            rp = new List<ReportFood>();
            this.LoadData();
        }

        private void LoadData()
        {
            AnalyticsByFoodBLL analyticsByFoodBLL = new AnalyticsByFoodBLL();

            this.rp = analyticsByFoodBLL.GetAnalyticsFood();
            this.rp.Sort();
            this.dataGridView1.DataSource = rp;
        }
    }
}
