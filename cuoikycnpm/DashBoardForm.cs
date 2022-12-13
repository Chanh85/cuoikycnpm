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
    public partial class DashBoardForm : Form
    {
        String strConn = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
        public DashBoardForm()
        {
            InitializeComponent();
        }

        private void user1_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {
            CategoryForm cat = new CategoryForm();
            cat.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            ProductForm prod = new ProductForm();
            prod.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            SellerForm sell = new SellerForm();
            sell.Show();
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

        }

        private void DashBoardForm_Load(object sender, EventArgs e)
        {
            SqlConnection Con = new SqlConnection(strConn);
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from tbl_user", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            stock1.Text = dt.Rows[0][0].ToString();
            SqlDataAdapter sda1 = new SqlDataAdapter("select sum(quantity) from tbl_order", Con);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            stock2.Text = dt1.Rows[0][0].ToString();
            SqlDataAdapter sda2 = new SqlDataAdapter("select sum(total_bill) from billtable", Con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            stock3.Text = dt2.Rows[0][0].ToString();
            Con.Close();
        }
    }
}
