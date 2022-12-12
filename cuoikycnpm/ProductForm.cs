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
    public partial class ProductForm : Form
    {
        String strConn = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
        public ProductForm()
        {
            
            InitializeComponent();
            productid.ReadOnly = true;
        }
        //SqlConnection Con = new SqlConnection(@"Data Source=PCPV-PC\SQLEXPRESS;Initial Catalog=cnpmcuoiky;Integrated Security=True");
        private void fillcombo()
        {//this method will bind the combobox with the database
            SqlConnection Con = new SqlConnection(strConn);
            Con.Open();
            SqlCommand cmd = new SqlCommand("select catname from cattable", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("catname", typeof(string));
            dt.Load(rdr);
            catcb.ValueMember = "catname";
            catcb.DataSource = dt;
            Con.Close();

        }
        private void populate()
        {
            SqlConnection Con = new SqlConnection(strConn);
            Con.Open();
            string query = "select * from producttable";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            prodgv.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void ProductForm_Load(object sender, EventArgs e)
        {
            fillcombo();
            populate();
        }

        private void prodgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            productid.Text = prodgv.SelectedRows[0].Cells[0].Value.ToString();
            productname.Text = prodgv.SelectedRows[0].Cells[1].Value.ToString();
            productquantity.Text = prodgv.SelectedRows[0].Cells[2].Value.ToString();
            productprice.Text = prodgv.SelectedRows[0].Cells[3].Value.ToString();
            catcb.SelectedValue = prodgv.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            CategoryForm cat = new CategoryForm();
            cat.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            SellerForm seller = new SellerForm();
            seller.Show();
            this.Hide();
        }

        private void user1_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            SellingForm selling = new SellingForm();
            selling.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection Con = new SqlConnection(strConn);
            try
            {
                Con.Open();
                string query = "insert into producttable values('" + productname.Text + "'," + productquantity.Text + "," + productprice.Text + ",'" + catcb.SelectedValue.ToString() + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("category added success");
                Con.Close();
                populate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection Con = new SqlConnection(strConn);
            try
            {
                if (productid.Text == "" || productname.Text == "" || productquantity.Text == "" || productprice.Text == "")
                {
                    MessageBox.Show("missing information");
                }
                else
                {
                    if (Con.State == ConnectionState.Closed)
                    {
                        Con.Open();

                    }
                    string query = "delete from producttable where productid=" + productid.Text + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("seller delete success");
                    Con.Close();
                    populate();

                }
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
                if (productid.Text == "" || productname.Text == "" || productquantity.Text == "" || productprice.Text == "")
                {
                    MessageBox.Show("missing information");
                }
                else
                {

                    Con.Open();
                    string query = "update producttable set productname='" + productname.Text + "',productname='" + productquantity.Text + "'where productid=" + productid.Text + "";
                    SqlCommand cmd = new SqlCommand(@query, Con);
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

        private void label5_Click(object sender, EventArgs e)
        {
            DashBoardForm selling = new DashBoardForm();
            selling.Show();
            this.Hide();
        }
    }
}
