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
    public partial class Assign_Party : System.Web.UI.Page
    {
        private SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PartyProductConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void AddAssign_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddAssign_Party.aspx");
        }
        protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            int ids = (int)GridView2.DataKeys[e.RowIndex].Value;

            string partyName = ((DropDownList)(GridView2.Rows[e.RowIndex]
                .Cells[0].FindControl("DropDownList1"))).SelectedValue;
            string productName = ((DropDownList)(GridView2.Rows[e.RowIndex].Cells[0].FindControl("DropDownList2"))).SelectedValue;


            string query2 = " select a.id,p.PartyName,pr.ProductName from party p inner join AssignParty a on p.id = a.party_id inner join products pr on pr.id = a.product_id where p.PartyName=@PartyName and pr.ProductName=@ProductName";
            SqlCommand cmd2 = new SqlCommand(query2, sqlConnection);
            cmd2.Parameters.AddWithValue("@PartyName", partyName);
            cmd2.Parameters.AddWithValue("@ProductName", productName);
            sqlConnection.Open();
            SqlDataReader reader2 = cmd2.ExecuteReader();
            bool isAvailableAssign = reader2.HasRows;
            sqlConnection.Close();

            if (!isAvailableAssign)
            {
                SqlDataSource3.UpdateParameters["PartyName"].DefaultValue = partyName;
                SqlDataSource3.UpdateParameters["ProductName"].DefaultValue = productName;
            }
            else
            {

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Updated Record Is Already Available')", true);
                string query3 = " select top 1 a.id,p.PartyName,pr.ProductName from party p inner join AssignParty a on p.id = a.party_id inner join products pr on pr.id = a.product_id where a.id=@ids";
                SqlCommand cmd3 = new SqlCommand(query3, sqlConnection);
                cmd3.Parameters.AddWithValue("@ids", ids);
                sqlConnection.Open();
                SqlDataReader reader3 = cmd3.ExecuteReader();

                string partyname = reader3.GetString(1);
                string productname = reader3.GetString(2);

                sqlConnection.Close();
                SqlDataSource3.UpdateParameters["PartyName"].DefaultValue = partyname;
                SqlDataSource3.UpdateParameters["ProductName"].DefaultValue = productname;

            }


        }

    }
}