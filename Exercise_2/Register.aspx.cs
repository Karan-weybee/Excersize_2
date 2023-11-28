using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Exercise_2
{
    public partial class Register : System.Web.UI.Page
    {
        private SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PartyProductConnectionString"].ConnectionString);
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

                SqlCommand cmd1 = new SqlCommand("select * from UserRegister Where UserName = @name", sqlConnection);
                cmd1.Parameters.AddWithValue("@name", user_name);
                sqlConnection.Open();
                SqlDataReader reader = cmd1.ExecuteReader();
                b = reader.HasRows;
                sqlConnection.Close();
                if (!b)
                {

                    SqlCommand cmd = new SqlCommand("insert into [dbo].[UserRegister] values (@username,@password)", sqlConnection);
                    cmd.Parameters.AddWithValue("@username", user_name);
                    cmd.Parameters.AddWithValue("@password", pass_word);
                    sqlConnection.Open();
                    int rowCount = cmd.ExecuteNonQuery();

                    sqlConnection.Close();
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