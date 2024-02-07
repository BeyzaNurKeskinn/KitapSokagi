using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KitapSokagi
{
    public partial class UC_MyOrders : UserControl
    {
        public UC_MyOrders()
        {
            InitializeComponent();
        }
        Database db = new Database();
        private void UC_MyOrders_Load(object sender, EventArgs e)
        {
            try
            {
                db.OrderList();
                dgvOrder.DataSource = db.getOrderSource();
                dgvOrder.Columns[3].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dgvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgvOrder.Columns[0].Index && e.RowIndex >= 0)
                {
                    db.OrderDetailList(int.Parse(dgvOrder.Rows[e.RowIndex].Cells[3].Value.ToString()));
                    dgvOrderDetail.DataSource = db.getOrderDetailSource();
                    dgvOrderDetail.Columns[0].Width = 180;
                    dgvOrderDetail.Columns[2].Width = 60;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
