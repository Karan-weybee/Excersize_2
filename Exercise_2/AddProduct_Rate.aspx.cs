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
    public partial class AddProduct_Rate : System.Web.UI.Page
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
            try
            {
                int rate = Convert.ToInt32(ProductRate.Text);
                if (rate < 0)
                {
                    error.Text = "Please Enter valid rate";
                    throw new Exception("Please Enter valid rate");
                }
                string Date1 = Calendar1.SelectedDate.Year.ToString() + "-" + Calendar1.SelectedDate.Month.ToString() + "-" + Calendar1.SelectedDate.Day.ToString();

                int productId = -1;


                string query = "select * from Products";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.GetString(1) == ProductName.SelectedValue)
                    {
                        productId = reader.GetInt32(0);

                        break;
                    }
                }
                sqlConnection.Close();
                if (productId != -1)
                {
                    string query1 = "insert into [dbo].[ProductRate] values (@Product_id,@Rate,@date)";
                    SqlCommand cmd1 = new SqlCommand(query1, sqlConnection);
                    cmd1.Parameters.AddWithValue("@Product_id", productId);
                    cmd1.Parameters.AddWithValue("@Rate", rate);
                    cmd1.Parameters.AddWithValue("@date", Date1);
                    sqlConnection.Open();
                    int rowCount = cmd1.ExecuteNonQuery();

                    sqlConnection.Close();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Add SuccessFulluy... ')", true);
                    error.Text = " ";
                }
                else
                {
                    productId = -1;
                }

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
