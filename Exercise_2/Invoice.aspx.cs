using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Exercise_2
{
    public partial class Invoice : System.Web.UI.Page
    {
        public void CalcGrandTotal()
        {
            int sum = 0;
            string ConStr = @"Data Source=DESKTOP-9IJS7NM; Initial Catalog=Exercise2; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(ConStr);
            string query = "select Total from Invoice";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ProductName", ProductDropDown.SelectedValue.ToString());
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                sum += reader.GetInt32(0);
            }
            GrandTotal1.Text = Convert.ToString(sum);
            con.Close();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                Session["productCount"] = "1";
                PartyDropDown.Items.Clear();
                PartyDropDown.Items.Add("select Party");
                string ConStr = @"Data Source=DESKTOP-9IJS7NM; Initial Catalog=Exercise2; Integrated Security=SSPI;";
                SqlConnection con = new SqlConnection(ConStr);
                string query = "select PartyName from Party";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    PartyDropDown.Items.Add(reader.GetString(0));
                }
                con.Close();


            }
            if (Session["party_Name"] != null)
            {
                PartyDropDown.SelectedValue = Session["party_Name"].ToString();
                PartyDropDown.Enabled = false;
                if (Session["productCount"] != null)
                {
                    AddProductInDropDown();
                    Session["productCount"] = null;
                }
            }
            else
            {
                PartyDropDown.Enabled = true;
            }


            CalcGrandTotal();
        }

        public void AddProductInDropDown()
        {
            ProductDropDown.Items.Clear();
            ProductDropDown.Items.Add("select Product");
            string ConStr = @"Data Source=DESKTOP-9IJS7NM; Initial Catalog=Exercise2; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(ConStr);
            string query = "select pr.ProductName from AssignParty a inner join Products pr on a.Product_id=pr.id where Party_id=(select top 1 id from Party where PartyName = @PartyName)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@PartyName", Convert.ToString(Session["Party_Name"]));
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ProductDropDown.Items.Add(reader.GetString(0));
            }
            con.Close();

        }
        protected void PartyDropDown_SelectedIndexChanged1(object sender, EventArgs e)
        {
            ProductDropDown.Items.Clear();
            ProductDropDown.Items.Add("select Product");
            string ConStr = @"Data Source=DESKTOP-9IJS7NM; Initial Catalog=Exercise2; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(ConStr);
            string query = "select pr.ProductName from AssignParty a inner join Products pr on a.Product_id=pr.id where Party_id=(select top 1 id from Party where PartyName = @PartyName)";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@PartyName", PartyDropDown.SelectedValue.ToString());
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ProductDropDown.Items.Add(reader.GetString(0));
            }
            con.Close();

        }

        protected void ProductDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            Rate.Text = " ";
            string ConStr = @"Data Source=DESKTOP-9IJS7NM; Initial Catalog=Exercise2; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(ConStr);
            string query = "select Rate from ProductRate where Product_id =(select top 1 id from Products where ProductName = @ProductName) order by Date_Of_Rate";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@ProductName", ProductDropDown.SelectedValue.ToString());
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Rate.Text = Convert.ToString(reader.GetInt32(0));
            }
            con.Close();

        }

        protected void save_Click(object sender, EventArgs e)
        {
            string party = PartyDropDown.SelectedValue.ToString();
            string product = ProductDropDown.SelectedValue.ToString();
            int rate = -1;
            int quantity = 0;
            int total = 0;
            try
            {

                rate = Convert.ToInt32(Rate.Text);
                quantity = Convert.ToInt32(Quantity.Text);
                total = rate * quantity;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter Valid Rate and Quantity.. ')", true);

            }


            if (party != String.Empty && party != "select Party" && product != "select Product" && product != String.Empty && rate > -1 && quantity > 0)
            {

                string ConStr = @"Data Source=DESKTOP-9IJS7NM; Initial Catalog=Exercise2; Integrated Security=SSPI;";
                SqlConnection con = new SqlConnection(ConStr);

                string query = "insert into [dbo].[Invoice] values (@party,@product,@rate,@quantity,@total)";


                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@party", party);
                cmd.Parameters.AddWithValue("@product", product);
                cmd.Parameters.AddWithValue("@rate", rate);
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.Parameters.AddWithValue("@total", total);
                con.Open();
                int rowCount = cmd.ExecuteNonQuery();

                con.Close();
                Session["party_Name"] = PartyDropDown.SelectedValue.ToString();
                Session["productCount"] = "1";
                Response.Redirect("Invoice.aspx");

            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Enter Data is not valid .. ')", true);

            }

        }

        protected void clearInvoice_Click(object sender, EventArgs e)
        {
            //delete all record into invoice
            string ConStr1 = @"Data Source=DESKTOP-9IJS7NM; Initial Catalog=Exercise2; Integrated Security=SSPI;";
            SqlConnection con1 = new SqlConnection(ConStr1);

            string query1 = "delete from [dbo].[Invoice]";


            SqlCommand cmd1 = new SqlCommand(query1, con1);

            con1.Open();
            int rowCount = cmd1.ExecuteNonQuery();

            con1.Close();
            Session["party_Name"] = null;
            Response.Redirect("Invoice.aspx");
        }
    }
}