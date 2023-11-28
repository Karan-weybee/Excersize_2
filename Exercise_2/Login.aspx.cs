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
    public partial class Login : System.Web.UI.Page
    {
        private SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PartyProductConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void signin_Click(object sender, EventArgs e)
        {
            string user_name = username.Text;
            string pass_word = password.Text;
            bool b = false;
            if (pass_word != String.Empty && user_name != String.Empty)
            {

                string query1 = "select * from UserRegister Where UserName = @username and password=@password";


                SqlCommand cmd1 = new SqlCommand(query1, sqlConnection);
                cmd1.Parameters.AddWithValue("@username", user_name);
                cmd1.Parameters.AddWithValue("@password", pass_word);
                sqlConnection.Open();
                SqlDataReader reader = cmd1.ExecuteReader();
                b = reader.HasRows;

                sqlConnection.Close();
                if (b)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('User is valid .. ')", true);
                    Session["user"] = user_name;
                    Response.Redirect("Party.aspx");
                    b = false;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter valid User name or password .. ')", true);

                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter The Valid Record .. ')", true);

            }
        }
    }
}