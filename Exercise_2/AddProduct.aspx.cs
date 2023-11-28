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
    public partial class AddProduct : System.Web.UI.Page
    {
        private SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PartyProductConnectionString"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        public bool isAvailableProduct(string productName)
        {

            SqlCommand cmd = new SqlCommand("select * from Products Where ProductName = @productName", sqlConnection);
            cmd.Parameters.AddWithValue("@productName", productName);
            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            bool isAvailable = reader.HasRows;
            sqlConnection.Close();
            return isAvailable;
        }

        protected void save_Click(object sender, EventArgs e)
        {
            string productName = ProductName.Text.Trim();
            if (productName != String.Empty)
            {

                if (!isAvailableProduct(productName))
                {

                    SqlCommand cmd = new SqlCommand("insert into [dbo].[Products] (ProductName) values (@productName)", sqlConnection);
                    cmd.Parameters.AddWithValue("@productName", productName);
                    sqlConnection.Open();
                    int rowCount = cmd.ExecuteNonQuery();

                    sqlConnection.Close();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Product Added Successfully .. ')", true);

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Product is already available .. ')", true);

                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Enter the record .. ')", true);

            }
        }

        protected void cancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("products.aspx");
        }
    }
}