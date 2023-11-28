using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Exercise_2
{
    public partial class AddAssign_Party : System.Web.UI.Page
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

            //finding patyId
            int productId = findProduct(productDropdown.Text);

            //finding productId
            int partyId = findParty(partyDropdown.Text);

            //insert assign
            if (!isAvailableAssign(partyId, productId))
            {
                SqlCommand cmd3 = new SqlCommand("insert into [dbo].[AssignParty] (Party_id,Product_id) values (@partyId,@productId)", sqlConnection);
                cmd3.Parameters.AddWithValue("@partyId", partyId);
                cmd3.Parameters.AddWithValue("@productId", productId);
                sqlConnection.Open();
                int rowCount = cmd3.ExecuteNonQuery();

                sqlConnection.Close();
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Added Successfully.')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Is Already Available')", true);
            }

        }

        protected void cancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("Assign_Party.aspx");
        }
        public bool isAvailableAssign(int partyId, int productId)
        {
            SqlCommand cmd = new SqlCommand("select id from AssignParty where Party_id=@party_id and Product_id=@Product_id", sqlConnection);
            cmd.Parameters.AddWithValue("@Party_id", partyId);
            cmd.Parameters.AddWithValue("@Product_id", productId);
            sqlConnection.Open();
            SqlDataReader reader2 = cmd.ExecuteReader();

            bool isAvailable = reader2.HasRows;
            sqlConnection.Close();
            return isAvailable;
        }

        public int findProduct(string productName)
        {

            SqlCommand cmd = new SqlCommand("select top 1 id from products where ProductName=@ProductName", sqlConnection);
            cmd.Parameters.AddWithValue("@ProductName", productName);
            sqlConnection.Open();
            int productId = (int)cmd.ExecuteScalar();
            sqlConnection.Close();
            return productId;
        }

        public int findParty(string partyName)
        {
            SqlCommand cmd1 = new SqlCommand("select top 1 id from party where PartyName=@PartyName", sqlConnection);
            cmd1.Parameters.AddWithValue("@PartyName", partyName);
            sqlConnection.Open();
            int partyId = (int)cmd1.ExecuteScalar();
            sqlConnection.Close();
            return partyId;
        }
    }
}