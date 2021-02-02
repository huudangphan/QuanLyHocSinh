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
            cblophs.DataBindings.Add(new Binding("text", datagridview2.DataSource, "lop", true, DataSourceUpdateMode.Never));
            txthocsinh.DataBindings.Add(new Binding("text", datagridview2.DataSource, "tenhs", true, DataSourceUpdateMode.Never));
            cblopcn.DataBindings.Add(new Binding("text", dataGridView1.DataSource, "tenlop", true, DataSourceUpdateMode.Never));
            txtchunhiem.DataBindings.Add(new Binding("text", dataGridView1.DataSource, "tengv", true, DataSourceUpdateMode.Never));
            txtid.DataBindings.Add(new Binding("text", datagridview2.DataSource, "id",true,DataSourceUpdateMode.Never));
            dateTimePicker1.DataBindings.Add(new Binding("Value", datagridview2.DataSource, "ngaySinh", true, DataSourceUpdateMode.Never));
        }
        void loadData()
        {
            var result = (from c in db.Lops

                          select new { c.tenlop,c.giaovien.tengv}).Distinct();            
            dataGridView1.DataSource = result.ToList();
            var result2 = from c in db.hocsinhs
                          select new { c.tenhs,c.lop,c.ngaysinh,c.id};
            datagridview2.DataSource = result2.ToList();
            var listLop = (db.Lops.ToList()).Distinct();
            foreach (var item in listLop)
            {
                cblopcn.Items.Add(item.tenlop);
                cblophs.Items.Add(item.tenlop);
            }

        }
       
        void addhs()
        {
            DateTime date = dateTimePicker1.Value;
            string lophoc = cblophs.Text;
            string tenhocsinh = txthocsinh.Text;
                      
                hocsinh hs = new hocsinh() { tenhs =tenhocsinh, lop = lophoc, ngaysinh = date };
                db.hocsinhs.Add(hs);
                db.SaveChanges();              
            
           
        }
        void addlop()
        {
           
           
        }

        void edit()
        {

        }
        void delete() {
            try {
                int idhs = Int32.Parse(txtid.Text);
                hocsinh hs = db.hocsinhs.Where(p => p.id == idhs).SingleOrDefault();
                db.hocsinhs.Remove(hs);
                db.SaveChanges();
            } catch { }
            
        }



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
            delete();
            MessageBox.Show("Xoa thanh cong");
            loadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
