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
            addbinding();
        }
        void addbinding()
        {
            txttoan.DataBindings.Add(new Binding("text", dataGridView1.DataSource, "toan", true, DataSourceUpdateMode.Never));
            txtly.DataBindings.Add(new Binding("text", dataGridView1.DataSource, "ly", true, DataSourceUpdateMode.Never));
            txthoa.DataBindings.Add(new Binding("text", dataGridView1.DataSource, "hoa", true, DataSourceUpdateMode.Never));
            txtvan.DataBindings.Add(new Binding("text", dataGridView1.DataSource, "van", true, DataSourceUpdateMode.Never));
            txtsu.DataBindings.Add(new Binding("text", dataGridView1.DataSource, "su", true, DataSourceUpdateMode.Never));
            txtdia.DataBindings.Add(new Binding("text", dataGridView1.DataSource, "dia", true, DataSourceUpdateMode.Never));
            txtsinh.DataBindings.Add(new Binding("text", dataGridView1.DataSource, "sinh", true, DataSourceUpdateMode.Never));
            txttin.DataBindings.Add(new Binding("text", dataGridView1.DataSource, "tin", true, DataSourceUpdateMode.Never));
            txtgdcd.DataBindings.Add(new Binding("text", dataGridView1.DataSource, "gdcd", true, DataSourceUpdateMode.Never));
            cblop.DataBindings.Add(new Binding("text", dataGridView1.DataSource, "lop", true, DataSourceUpdateMode.Never));
            
            txtten.DataBindings.Add(new Binding("text", dataGridView1.DataSource, "tenhs", true, DataSourceUpdateMode.Never));

        }
        void loadData()
        {
           
            var lop = db.Lops.ToList();
            foreach (var i in lop)
            {
                cblop.Items.Add(i.tenlop);
            }
            var result = from a in db.bangdiemhs
                         where a.idhs == a.hocsinh.id
                         select new { a.hocsinh.lop , a.hocsinh.tenhs, a.toan, a.ly, a.hoa, a.van, a.su, a.dia, a.sinh, a.tin, a.gdcd};
            dataGridView1.DataSource = result.ToList();
                       
         


        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
