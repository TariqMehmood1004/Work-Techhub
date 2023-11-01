using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KICS
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if the user is logged in
                if (Session["userId"] != null)
                {
                    // Set the userProfileImage value to a variable
                    string userProfileImage = Session["userProfileImage"] as string;

                    // Use that variable in the HTML markup
                    userProfileImageTag.ImageUrl = userProfileImage; 
                }

            }
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            // Clear all session variables
            Session.Clear();

            // Abandon the session
            Session.Abandon();

            // Redirect to the login page or any other page you want after logout
            Response.Redirect("~/Controllers/auth/login.aspx");
        }
    }
}