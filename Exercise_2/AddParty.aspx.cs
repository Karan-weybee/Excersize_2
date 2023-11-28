using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace Exercise_2
{
    public partial class AddParty : System.Web.UI.Page
    {
        private SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PartyProductConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void save_Click(object sender, EventArgs e)
        {
            string partyName = PartyName.Text.Trim();
            if (partyName != String.Empty)
            {

                if (!isAvailableParty(partyName))
                {
                    SqlCommand cmd = new SqlCommand("insert into [dbo].[Party] (PartyName) values (@partyName)", sqlConnection);
                    cmd.Parameters.AddWithValue("@partyName", partyName);
                    sqlConnection.Open();
                    int rowCount = cmd.ExecuteNonQuery();

                    sqlConnection.Close();
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
        public bool isAvailableParty(string partyName)
        {
            SqlCommand cmd = new SqlCommand("select * from Party Where PartyName = @partyName", sqlConnection);
            cmd.Parameters.AddWithValue("@partyName", partyName);
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            bool isAvailable = reader.HasRows;
            sqlConnection.Close();
            return isAvailable;
        }
    }
}