using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Exercise_2
{
    public partial class AddParty : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void save_Click(object sender, EventArgs e)
        {
            //string constring = ConfigurationManager.ConnectionStrings["ABCD"].ConnectionString;
            //using (SqlConnection con = new SqlConnection(constring))
            //    BELOW WEB.CONFIG FILE CODE

            //    <connectionStrings>
            //        < add name = "ABCD" connectionString = "Data Source=DESKTOP-SU3NKUU\MSSQLSERVER2016;Initial Catalog=TESTKISWRMIP;Integrated Security=True" providerName = "System.Data.SqlClient" />

            //   </ connectionStrings >

            string name = PartyName.Text.Trim();
            bool b = false;
            if (name != String.Empty)
            {
                string ConStr1 = @"Data Source=DESKTOP-9IJS7NM; Initial Catalog=Exercise2; Integrated Security=SSPI;";
                SqlConnection con1 = new SqlConnection(ConStr1);

                string query1 = "select * from Party Where PartyName = @name";


                SqlCommand cmd1 = new SqlCommand(query1, con1);
                cmd1.Parameters.AddWithValue("@name", name);
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

                    string query = "insert into [dbo].[Party] (PartyName) values (@name)";


                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@name", name);
                    con.Open();
                    int rowCount = cmd.ExecuteNonQuery();

                    con.Close();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Party Added Successfully .. ')", true);

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Party is already available .. ')", true);

                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter the record .. ')", true);

            }
        }

        protected void cancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("party.aspx");
        }
    }
}