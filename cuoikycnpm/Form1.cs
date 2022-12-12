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
            SqlConnection Con = new SqlConnection(strConn);
            if (user.Text == "" || pass.Text == "")
            {
                MessageBox.Show("Enter the user and password");
            }
            else
            {
                Con.Open();
                   SqlDataAdapter sda= new SqlDataAdapter("Select count(10) from tbl_user where name='"+user.Text+"' and password='"+pass.Text+"'",Con);
                   DataTable dt = new DataTable();
                   sda.Fill(dt);
                if (dt.Rows[0][0].ToString()=="1")
                {
                    CategoryForm category= new CategoryForm();
                    category.Show();
                    this.Hide();
                    Con.Close();
                }
                 else
                 {
                          MessageBox.Show("if you are the admin,enter the correct id and password");
                 }
                Con.Close() ;
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