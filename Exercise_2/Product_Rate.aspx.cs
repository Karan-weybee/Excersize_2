using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Exercise_2
{
    public partial class Product_Rate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void AddProductRate_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddProduct_Rate.aspx");
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // int ids = (int)GridView1.DataKeys[e.RowIndex].Value;

            string PRName = ((DropDownList)(GridView1.Rows[e.RowIndex]
                .Cells[0].FindControl("DropDownList1"))).SelectedValue;

            SqlDataSource1.UpdateParameters["ProductName"].DefaultValue = PRName;

        }
    }
}