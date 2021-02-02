using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyHocSinh
{
    public partial class fHocSinh : Form
    {
        QLHocSinhEntities db = new QLHocSinhEntities();
        public fHocSinh()
        {
            InitializeComponent();
            loadData();
        }
        void loadData()
        {
            var item = db.giaoviens.ToList();
            foreach (var i in item)
            {
                cbgiaovien.Items.Add(i.tengv);
            }
         


        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(cbgiaovien.Text);
        }
    }
}
