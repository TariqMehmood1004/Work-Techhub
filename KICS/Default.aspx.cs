using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KICS
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Session["userId"] !=  null && Session["username"] != null)
                {
                    nameLabel.Text = "Welcome " + Session["username"].ToString();
                }
                else
                {
                    nameLabel.Text = "Please login now!";
                }
            }      
        }

        protected void AddApplicationForm_Click(object sender, EventArgs e)
        {
            Response.Redirect("Controllers/admin/ApplicationsForms/addApplicationForms.aspx");
        }
    }
}