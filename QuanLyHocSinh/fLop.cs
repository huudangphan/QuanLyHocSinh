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
    public partial class fLop : Form
    {

        QuanLyHocSinhEntities db = new QuanLyHocSinhEntities();
        public fLop()
        {
            InitializeComponent();
            loadData();
            addBinding();
        }
        void addBinding()
        {
            txtlop.DataBindings.Add(new Binding("text", dataGridView1.DataSource, "tenLop",true,DataSourceUpdateMode.Never));
            txtchunhiem.DataBindings.Add(new Binding("text", dataGridView1.DataSource, "tengiaoVien", true, DataSourceUpdateMode.Never));
            txthocsinh.DataBindings.Add(new Binding("text", dataGridView2.DataSource, "ten", true, DataSourceUpdateMode.Never));
        }
        void loadData()
        {
            var result = (from c in db.LopHocs

                          select new { c.tenlop,c.GiaoVien.tengiaoVien}).Distinct();



            
            dataGridView1.DataSource = result.ToList();
            var result2 = from c in db.HocSinhs
                          select new { c.ten, c.ngaySinh, c.diachi, c.sdt, c.lop };
            dataGridView2.DataSource = result2.ToList();
        }


        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
