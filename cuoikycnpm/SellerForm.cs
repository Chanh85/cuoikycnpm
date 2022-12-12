using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cuoikycnpm
{
    public partial class SellerForm : Form
    {
        String strConn = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
        public SellerForm()
        {
            InitializeComponent();
            SellerId.ReadOnly= true;
        }
        //SqlConnection Con = new SqlConnection(@"Data Source=PCPV-PC\SQLEXPRESS;Initial Catalog=cnpmcuoiky;Integrated Security=True");
        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void populate()
        {
            SqlConnection Con = new SqlConnection(strConn);
            Con.Open();
            string query = "select * from SellerTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            sellerdgv.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection Con = new SqlConnection(strConn);
            try
            {
                Con.Open();
                string query = "insert into SellerTbl values('" + SellerName.Text + "'," + SellerAge.Text + "," + SellerPhone.Text + ")";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("SellerTbl added success");
                Con.Close();
                populate();
                SellerId.Text = "";
                SellerName.Text = "";
                SellerPhone.Text = "";
             
                SellerAge.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection Con = new SqlConnection(strConn);
            try
            {
                if (SellerId.Text == "" || SellerName.Text == "" || SellerPhone.Text == "" || SellerAge.Text == "")
                {
                    MessageBox.Show("missing information");
                }
                else
                {

                    if (Con.State == ConnectionState.Closed)
                    {
                        Con.Open();

                    }
                    string query = "update SellerTbl set SellerName='" + SellerName.Text + "',SellerAge=" + SellerAge.Text + ",SellerPhone='" + SellerPhone.Text + "'where SellerId=" + SellerId.Text + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("update success");
                    Con.Close();
                    populate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void sellerdgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SellerId.Text = sellerdgv.SelectedRows[0].Cells[0].Value.ToString();
            SellerName.Text = sellerdgv.SelectedRows[0].Cells[1].Value.ToString();
            SellerAge.Text = sellerdgv.SelectedRows[0].Cells[2].Value.ToString();
            SellerPhone.Text = sellerdgv.SelectedRows[0].Cells[3].Value.ToString();
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection Con = new SqlConnection(strConn);
            try
            {
                if (SellerId.Text == "")
                {
                    MessageBox.Show("Select the category to delete");

                }
                else
                {
                    if (Con.State == ConnectionState.Closed)
                    {
                        Con.Open();

                    }
                    string query = "delete from SellerTbl where SellerId=" + SellerId.Text + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("seller delete success");
                    Con.Close();
                    populate();
                    SellerId.Text = "";
                    SellerName.Text = "";
                    SellerPhone.Text = "";
                  
                    SellerAge.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void user1_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            CategoryForm cat = new CategoryForm();
            cat.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            ProductForm pro = new ProductForm();
            pro.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            SellerForm seller = new SellerForm();
            seller.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            SellingForm selling = new SellingForm();
            selling.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Form1 log = new Form1();
            log.Show();
            this.Hide();
        }

        private void SellerForm_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {
            DashBoardForm selling = new DashBoardForm();
            selling.Show();
            this.Hide();
        }
    }
}
