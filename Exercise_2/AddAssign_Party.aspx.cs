using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Exercise_2
{
    public partial class AddAssign_Party : System.Web.UI.Page
    {
        public void addPartyDropdown()
        {
            string ConStr = @"Data Source=DESKTOP-9IJS7NM; Initial Catalog=Exercise2; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(ConStr);
            string query = "select * from party";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                partyDropdown.Items.Add(reader.GetString(1));
            }
            con.Close();
        }
        public void addProductDropdown()
        {
            string ConStr = @"Data Source=DESKTOP-9IJS7NM; Initial Catalog=Exercise2; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(ConStr);
            string query = "select * from products";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                productDropdown.Items.Add(reader.GetString(1));
            }
            con.Close();
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
            int p_id = -1;
            int pr_id = -1;
            int count = -1;
            string ConStr = @"Data Source=DESKTOP-9IJS7NM; Initial Catalog=Exercise2; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(ConStr);
            string query = "select * from products";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if (reader.GetString(1) == productDropdown.Text)
                {
                    pr_id = reader.GetInt32(0);
                    break;
                }
            }
            con.Close();

            string ConStr1 = @"Data Source=DESKTOP-9IJS7NM; Initial Catalog=Exercise2; Integrated Security=SSPI;";
            SqlConnection con1 = new SqlConnection(ConStr1);
            string query1 = "select * from party";
            SqlCommand cmd1 = new SqlCommand(query1, con1);
            con1.Open();
            SqlDataReader reader1 = cmd1.ExecuteReader();
            while (reader1.Read())
            {
                if (reader1.GetString(1) == partyDropdown.Text)
                {
                    p_id = reader1.GetInt32(0);
                    break;
                }
            }
            con1.Close();

            // Response.Write(p_id);
            // Response.Write(pr_id);

            string ConStr2 = @"Data Source=DESKTOP-9IJS7NM; Initial Catalog=Exercise2; Integrated Security=SSPI;";
            SqlConnection con2 = new SqlConnection(ConStr2);
            string query2 = "select id from AssignParty where Party_id=@party_id and Product_id=@Product_id";
            SqlCommand cmd2 = new SqlCommand(query2, con2);
            cmd2.Parameters.AddWithValue("@Party_id", p_id);
            cmd2.Parameters.AddWithValue("@Product_id", pr_id);
            con2.Open();
            SqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                count++;
            }
            con2.Close();

            if (count == -1)
            {
                SqlConnection con3 = new SqlConnection(ConStr);

                string query3 = "insert into [dbo].[AssignParty] (Party_id,Product_id) values (@p_id,@pr_id)";


                SqlCommand cmd3 = new SqlCommand(query3, con3);
                cmd3.Parameters.AddWithValue("@p_id", p_id);
                cmd3.Parameters.AddWithValue("@pr_id", pr_id);
                con3.Open();
                int rowCount = cmd3.ExecuteNonQuery();

                con3.Close();
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