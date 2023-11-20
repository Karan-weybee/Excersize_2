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
    public partial class AddAssign_Party : System.Web.UI.Page
    {
        private SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PartyProductConnectionString"].ConnectionString);

        public void addPartyDropdown()
        {
            string query = "select * from party";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                partyDropdown.Items.Add(reader.GetString(1));
            }
            sqlConnection.Close();
        }
        public void addProductDropdown()
        {
            string query = "select * from products";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                productDropdown.Items.Add(reader.GetString(1));
            }
            sqlConnection.Close();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            addPartyDropdown();
            addProductDropdown();


        }

        protected void save_Click(object sender, EventArgs e)
        {
            int partyId = -1;
            int productId = -1;
            int count = -1;

            string query = "select * from products";
            SqlCommand cmd = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader.GetString(1) == productDropdown.Text)
                {
                    productId = reader.GetInt32(0);
                    break;
                }
            }
            sqlConnection.Close();

            string query1 = "select * from party";
            SqlCommand cmd1 = new SqlCommand(query1, sqlConnection);
            sqlConnection.Open();
            SqlDataReader reader1 = cmd1.ExecuteReader();
            while (reader1.Read())
            {
                if (reader1.GetString(1) == partyDropdown.Text)
                {
                    partyId = reader1.GetInt32(0);
                    break;
                }
            }
            sqlConnection.Close();

            string query2 = "select id from AssignParty where Party_id=@party_id and Product_id=@Product_id";
            SqlCommand cmd2 = new SqlCommand(query2, sqlConnection);
            cmd2.Parameters.AddWithValue("@Party_id", partyId);
            cmd2.Parameters.AddWithValue("@Product_id", productId);
            sqlConnection.Open();
            SqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                count++;
            }
            sqlConnection.Close();

            if (count == -1)
            {
                string query3 = "insert into [dbo].[AssignParty] (Party_id,Product_id) values (@partyId,@productId)";
                SqlCommand cmd3 = new SqlCommand(query3, sqlConnection);
                cmd3.Parameters.AddWithValue("@partyId", partyId);
                cmd3.Parameters.AddWithValue("@productId", productId);
                sqlConnection.Open();
                int rowCount = cmd3.ExecuteNonQuery();

                sqlConnection.Close();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Is Already Available')", true);
            }
            count = -1;
        }

        protected void cancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("Assign_Party.aspx");
        }
    }
}