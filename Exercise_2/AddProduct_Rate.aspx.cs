using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Exercise_2
{
    public partial class AddProduct_Rate : System.Web.UI.Page
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
            try
            {
                int rate = Convert.ToInt32(ProductRate.Text);
                if (rate < 0)
                {
                    error.Text = "Please Enter valid rate";
                    throw new Exception("Please Enter valid rate");
                }
                string Date1 = Calendar1.SelectedDate.Year.ToString() + "-" + Calendar1.SelectedDate.Month.ToString() + "-" + Calendar1.SelectedDate.Day.ToString();

                int pr_id = -1;
                string ConStr = @"Data Source=DESKTOP-9IJS7NM; Initial Catalog=Exercise2; Integrated Security=SSPI;";
                SqlConnection con = new SqlConnection(ConStr);
                string query = "select * from Products";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.GetString(1) == ProductName.SelectedValue)
                    {
                        pr_id = reader.GetInt32(0);

                        break;
                    }
                }
                if (pr_id != -1)
                {
                    SqlConnection con1 = new SqlConnection(ConStr);

                    string query1 = "insert into [dbo].[ProductRate] values (@Product_id,@Rate,@date)";
                    SqlCommand cmd1 = new SqlCommand(query1, con1);
                    cmd1.Parameters.AddWithValue("@Product_id", pr_id);
                    cmd1.Parameters.AddWithValue("@Rate", rate);
                    cmd1.Parameters.AddWithValue("@date", Date1);
                    con1.Open();
                    int rowCount = cmd1.ExecuteNonQuery();

                    con1.Close();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Add SuccessFulluy... ')", true);
                    error.Text = " ";
                }
                else
                {
                    pr_id = -1;
                }
                con.Close();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('input Data is not Valid')", true);

            }
        }

        protected void cancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("Product_Rate.aspx");
        }
    }
}
