using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Exercise_2
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }



        protected void register_Click(object sender, EventArgs e)
        {
            string user_name = username.Text;
            string pass_word = password.Text;
            string repeat_pass = repeatpassword.Text;
            bool b = false;

            if (pass_word != String.Empty && repeat_pass != String.Empty && user_name != String.Empty && pass_word.Equals(repeat_pass))
            {
                string ConStr1 = @"Data Source=DESKTOP-9IJS7NM; Initial Catalog=Exercise2; Integrated Security=SSPI;";
                SqlConnection con1 = new SqlConnection(ConStr1);

                string query1 = "select * from UserRegister Where UserName = @name";


                SqlCommand cmd1 = new SqlCommand(query1, con1);
                cmd1.Parameters.AddWithValue("@name", user_name);
                con1.Open();
                SqlDataReader reader = cmd1.ExecuteReader();
                while (reader.Read())
                {
                    b = true;
                    break;
                }
                con1.Close();
                if (!b)
                {

                    string ConStr = @"Data Source=DESKTOP-9IJS7NM; Initial Catalog=Exercise2; Integrated Security=SSPI;";
                    SqlConnection con = new SqlConnection(ConStr);

                    string query = "insert into [dbo].[UserRegister] values (@username,@password)";


                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@username", user_name);
                    cmd.Parameters.AddWithValue("@password", pass_word);
                    con.Open();
                    int rowCount = cmd.ExecuteNonQuery();

                    con.Close();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('User Register Successfully .. ')", true);
                    Response.Redirect("Login.aspx");

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('User is Already Available .. ')", true);

                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter The Valid Record .. ')", true);

            }


        }
    }
}