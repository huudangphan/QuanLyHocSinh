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

        QLHocSinhEntities db = new QLHocSinhEntities();

        public fLop()
        {
            InitializeComponent();
            loadData();
            addBinding();
        }
        void addBinding()
        {
            txtlophs.DataBindings.Add(new Binding("text", datagridview2.DataSource, "lop",true,DataSourceUpdateMode.Never));
            txthocsinh.DataBindings.Add(new Binding("text", datagridview2.DataSource, "tenhs", true, DataSourceUpdateMode.Never));
            cblopcn.DataBindings.Add(new Binding("text", dataGridView1.DataSource, "tenlop", true, DataSourceUpdateMode.Never));
            txtchunhiem.DataBindings.Add(new Binding("text", dataGridView1.DataSource, "tengv", true, DataSourceUpdateMode.Never));

            dateTimePicker1.DataBindings.Add(new Binding("Value", datagridview2.DataSource, "ngaySinh", true, DataSourceUpdateMode.Never));
        }
        void loadData()
        {
            var result = (from c in db.Lops

                          select new { c.tenlop,c.giaovien.tengv}).Distinct();            
            dataGridView1.DataSource = result.ToList();
            var result2 = from c in db.hocsinhs
                          select new { c.tenhs,c.lop,c.ngaysinh};
            datagridview2.DataSource = result2.ToList();

        }
       
        void addhs()
        {
            DateTime date = dateTimePicker1.Value;            
           
            try
            {
                hocsinh hs = new hocsinh() { tenhs = txthocsinh.Text, lop = txtlophs.Text, ngaysinh = date };
                db.hocsinhs.Add(hs);
                db.SaveChanges();

                db.SaveChanges();
            }
            catch
            {
                
            }
           
        }
        void addlop()
        {
           
           
        }

        void edit()
        {

        }
        void delete() { }



        private void button5_Click(object sender, EventArgs e)
        {

        }

        

        private void btnthem_Click(object sender, EventArgs e)
        {
            addhs();
            loadData();
          
            MessageBox.Show("Them hoc sinh thanh cong");
        }

        private void btnsua_Click(object sender, EventArgs e)
        {

        }

        private void btnxoa_Click(object sender, EventArgs e)
        {

        }

        private void btnthemlop_Click(object sender, EventArgs e)
        {
            addlop();
            loadData();
            MessageBox.Show("Chia lop thanh cong");
        }
    }
}
