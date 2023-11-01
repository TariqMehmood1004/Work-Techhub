using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using KICS.Content.Utils;

namespace KICS.Controllers.auth
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                msgLabel.Visible = false;
            }
        }

        protected void signIn_Click(object sender, EventArgs e)
        {
            string loginQuery = "SELECT USERS_ID, USERS_USERNAME, USERS_ROLE, USERS_IMAGES_PATH FROM USERS " +
                    "WHERE USERS_CNIC = @CNIC AND USERS_PASSWORD = @Password";

            SqlConnection conn = AppSettings.Connection();

            SqlCommand cmd = new SqlCommand(loginQuery, conn);

            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@CNIC", cnic.Text.Trim());
            cmd.Parameters.AddWithValue("@Password", password.Text.Trim());


            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int userId = reader.GetInt32(0);
                    string username = reader.GetString(1);
                    int userRole = reader.GetInt32(2); 
                    string userProfileImage = reader.GetString(3);

                    Session["userId"] = userId;
                    Session["username"] = username;
                    Session["userProfileImage"] = userProfileImage;


                    msgLabel.Visible = true;
                    msgLabel.Text = "You are logged in successfully!";
                    Response.Redirect("~/");
                }
                else
                {
                    msgLabel.Visible = true;
                    msgLabel.Text = "You are not logged in. Try again!";
                }
            }
            catch (SqlException ex)
            {
                msgLabel.Visible = true;
                msgLabel.Text = $"Something went wrong: {ex.Message}";
            }
            finally
            {
                conn.Close();
            }
        }

        protected void reset_Click(object sender, EventArgs e)
        {
            EmptyFields();
        }

        private void EmptyFields()
        {
            cnic.Text = string.Empty;
            password.Text = string.Empty;
            msgLabel.Visible = false;
        }
    }
}