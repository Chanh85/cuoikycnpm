using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cuoikycnpm
{

    public partial class SellingForm : Form
    {
        String strConn = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
        public SellingForm()
        {
            InitializeComponent();
            billid.ReadOnly= true;
        }
        
        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void populate()
        {
            SqlConnection Con = new SqlConnection(strConn);
            Con.Open();
            string query = "select productname,productquantity from producttable";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            prodgv1.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void populatebill()
        {
            SqlConnection Con = new SqlConnection(strConn);
            Con.Open();
            string query = "select * from billtable";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            billdgv.DataSource = ds.Tables[0];
            Con.Close();
        }
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
            searchcb.ValueMember = "catname";
            searchcb.DataSource = dt;
            Con.Close();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            date.Text=DateTime.Today.Day.ToString()+"/"+ DateTime.Today.Month.ToString() + "/"+DateTime.Today.Year.ToString() ;
        }

        private void SellingForm_Load(object sender, EventArgs e)
        {
            fillcombo();
            populate();
            populatebill();
            sellername.Text = Form1.Sellername;
        }

        private void prodgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            sellername.Text = prodgv1.SelectedRows[0].Cells[0].Value.ToString();
            productquantity.Text = prodgv1.SelectedRows[0].Cells[1].Value.ToString();
        }
        int grdtotal = 0;
        private void button8_Click(object sender, EventArgs e)
        {
            int n = 0,total= Convert.ToInt32(productprice.Text) * Convert.ToInt32(productquantity.Text);
            if (sellername.Text == "" || productquantity.Text=="")
            {
                MessageBox.Show("missing data");

            }
            else
            {
            DataGridViewRow newrow = new DataGridViewRow();
            newrow.CreateCells(orderdgv);
            newrow.Cells[0].Value = n + 1;
            newrow.Cells[1].Value = sellername.Text;
            newrow.Cells[2].Value = productprice.Text;
            newrow.Cells[3].Value = productquantity.Text;
            newrow.Cells[4].Value = Convert.ToInt32(productprice.Text)*Convert.ToInt32(productquantity.Text);
            orderdgv.Rows.Add(newrow);
            grdtotal = grdtotal + total;
            amount.Text = "" + grdtotal;
            }


        }

        private void prodgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }


        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void billid_Click(object sender, EventArgs e)
        {

        }
       
        private void billdgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            e.Graphics.DrawString(" DAILYTHUCPHAMCHUCNANG ",new Font("Century Gothic",25,FontStyle.Bold),Brushes.Red,new Point(230));
            e.Graphics.DrawString("bill id:"+billdgv.SelectedRows[0].Cells[0].Value.ToString(),new Font("Century Gothic",20,FontStyle.Bold),Brushes.Red,new Point(100,70));
            e.Graphics.DrawString("seller name:"+billdgv.SelectedRows[0].Cells[1].Value.ToString(),new Font("Century Gothic",20,FontStyle.Bold),Brushes.Red,new Point(100,100));
            e.Graphics.DrawString("date :"+billdgv.SelectedRows[0].Cells[2].Value.ToString(),new Font("Century Gothic",20,FontStyle.Bold),Brushes.Red,new Point(100,130));
            e.Graphics.DrawString("total amount:"+billdgv.SelectedRows[0].Cells[3].Value.ToString(),new Font("Century Gothic",20,FontStyle.Bold),Brushes.Red,new Point(100,160));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            populate();

        }

        private void catcb_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void label8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void date_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection Con = new SqlConnection(strConn);
            if (billid.Text == "")
            {
                MessageBox.Show("missing bill id");
            }
            else
            {

                try
                {
                    if (Con.State == ConnectionState.Closed)
                    {
                        Con.Open();

                    }
                    string query = "insert into billtable values('" + sellername.Text + "','" + date.Text + "'," + amount.Text + ")";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("category added success");
                    Con.Close();
                    populatebill();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        

        private void label16_Click(object sender, EventArgs e)
        {
            CategoryForm cat = new CategoryForm();
            cat.Show();
            this.Hide();
        }

        private void label10_Click_1(object sender, EventArgs e)
        {
            ProductForm pro = new ProductForm();
            pro.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            SellerForm seller = new SellerForm();
            seller.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            Form1 log = new Form1();
            log.Show();
            this.Hide();
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
            date.Text = DateTime.Today.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString();
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            
            SqlConnection Con = new SqlConnection(strConn);
            try
            {
                if (billid.Text == "")
                {
                    MessageBox.Show("Select the bill to delete");

                }
                else
                {
                    if (Con.State == ConnectionState.Closed)
                    {
                        Con.Open();

                    }
                    string query = "delete from billtable where billid=" + billid.Text + "";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(" delete success");
                    Con.Close();
                    populate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {
            DashBoardForm selling = new DashBoardForm();
            selling.Show();
            this.Hide();
        }
    }
}
