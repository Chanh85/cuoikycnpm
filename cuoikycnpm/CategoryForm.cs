using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace cuoikycnpm
{
    public partial class CategoryForm : Form
    {
        string strConn = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
        
        
        public CategoryForm()
        {
            InitializeComponent();
        }
        //SqlConnection Con = new SqlConnection(@"Data Source=PCPV-PC\SQLEXPRESS;Initial Catalog=cnpmcuoiky;Integrated Security=True");
        private void CategoryForm_Load(object sender, EventArgs e)
        {
            catid.ReadOnly= true;
            populate();
        }
        private void populate()
        {
            SqlConnection Con = new SqlConnection(strConn);
            Con.Open();
            string query = "select * from cattable";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            catdgv.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection Con = new SqlConnection(strConn);
                Con.Open();
                string query = "insert into cattable values('"+catname.Text+"','"+catdesc.Text+"')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("category added success");
                Con.Close();
                populate();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void catdgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            catid.Text = catdgv.SelectedRows[0].Cells[0].Value.ToString();
            catname.Text = catdgv.SelectedRows[0].Cells[1].Value.ToString();
            catdesc.Text = catdgv.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection Con = new SqlConnection(strConn);
            try
            {
                if(catid.Equals(""))
                {
                    MessageBox.Show("Select the category to delete");

                }
                else
                {
                    if(Con.State== ConnectionState.Closed)
                    {
                        
                        Con.Open();

                    }
                    string query = "delete from cattable where catid=" + catid.Text + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("category delete success");
                    Con.Close();
                    populate();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection Con = new SqlConnection(strConn);
            try
            {
                if (catid.Text=="" || catname.Text=="" || catdesc.Text=="")
                {
                    MessageBox.Show("missing information");
                }
                else
                {

                Con.Open();
                string query = "update cattable set catname='" + catname.Text + "',catdesc='" + catdesc.Text + "'where catid=" + catid.Text + "";
                SqlCommand cmd = new SqlCommand(@query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("update success");
                Con.Close();
                    populate();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProductForm prod = new ProductForm();
            prod.Show();
            this.Hide();
        }

        private void catid_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           SellerForm sell = new SellerForm();
            sell.Show();
            this.Hide();
        }

        private void user1_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            ProductForm pro = new ProductForm();
            pro.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            SellerForm seller = new SellerForm();
            seller.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {

            SellingForm selling = new SellingForm();
            selling.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Form1 log = new Form1();
            log.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            DashBoardForm selling = new DashBoardForm();
            selling.Show();
            this.Hide();
        }
    }
}
