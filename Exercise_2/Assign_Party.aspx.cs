using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Exercise_2
{
    public partial class Assign_Party : System.Web.UI.Page
    {
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

            string PName = ((DropDownList)(GridView2.Rows[e.RowIndex]
                .Cells[0].FindControl("DropDownList1"))).SelectedValue;
            string PRName = ((DropDownList)(GridView2.Rows[e.RowIndex].Cells[0].FindControl("DropDownList2"))).SelectedValue;

            int count = -1;

            string ConStr2 = @"Data Source=DESKTOP-9IJS7NM; Initial Catalog=Exercise2; Integrated Security=SSPI;";
            SqlConnection con2 = new SqlConnection(ConStr2);
            string query2 = " select a.id,p.PartyName,pr.ProductName from party p inner join AssignParty a on p.id = a.party_id inner join products pr on pr.id = a.product_id where p.PartyName=@PartyName and pr.ProductName=@ProductName";
            SqlCommand cmd2 = new SqlCommand(query2, con2);
            cmd2.Parameters.AddWithValue("@PartyName", PName);
            cmd2.Parameters.AddWithValue("@ProductName", PRName);
            con2.Open();
            SqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                count++;
            }
            con2.Close();

            if (count == -1)
            {
                SqlDataSource3.UpdateParameters["PartyName"].DefaultValue = PName;
                SqlDataSource3.UpdateParameters["ProductName"].DefaultValue = PRName;
            }
            else
            {
                string pname1 = "";
                string prname1 = "";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Updated Record Is Already Available')", true);
                string ConStr3 = @"Data Source=DESKTOP-9IJS7NM; Initial Catalog=Exercise2; Integrated Security=SSPI;";
                SqlConnection con3 = new SqlConnection(ConStr3);
                string query3 = " select a.id,p.PartyName,pr.ProductName from party p inner join AssignParty a on p.id = a.party_id inner join products pr on pr.id = a.product_id where a.id=@ids";
                SqlCommand cmd3 = new SqlCommand(query3, con3);
                cmd3.Parameters.AddWithValue("@ids", ids);
                con3.Open();
                SqlDataReader reader3 = cmd3.ExecuteReader();
                while (reader3.Read())
                {
                    pname1 = reader3.GetString(1);
                    prname1 = reader3.GetString(2);
                }
                con3.Close();
                SqlDataSource3.UpdateParameters["PartyName"].DefaultValue = pname1;
                SqlDataSource3.UpdateParameters["ProductName"].DefaultValue = prname1;
                count = -1;

            }


        }

    }
}