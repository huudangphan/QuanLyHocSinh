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
            comboBox1.DataBindings.Add(new Binding("text", datagridview2.DataSource, "lop", true, DataSourceUpdateMode.Never));
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
            string lophoc = comboBox1.Text;
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

        
    }
}
