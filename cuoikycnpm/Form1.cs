using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace cuoikycnpm
{
    public partial class Form1 : Form
    {
        String strConn = ConfigurationManager.ConnectionStrings["MyConn"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
        }
        public static string Sellername = "";
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (user.Text == "" || pass.Text == "")
            {
                MessageBox.Show("Enter the user and password");
            }
            else
            {   
                        if (user.Text == "123" && pass.Text == "123")
                        {
                            ProductForm prod = new ProductForm();
                            prod.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("if you are the admin,enter the correct id and password");
                        }
            }
                 
        }
        

        private void label4_Click(object sender, EventArgs e)
        {
            user.Text = "";
            pass.Text = "";
        }

        private void user_TextChanged(object sender, EventArgs e)
        {

        }

        private void rolecb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}