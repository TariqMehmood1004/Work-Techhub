using KICS.Content.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace KICS.Controllers.auth
{
    public partial class registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //EmptyFields();

                BindingIDs(GetIdsFromDatabase("SELECT * FROM ROLES;"),
                           userRoles, "ROLES_NAMES", "ROLES_ID", 
                           "--- Select User Role ---");
            }
        }

        private DataTable GetIdsFromDatabase(string query)
        {
            SqlConnection conn = AppSettings.Connection();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            try
            {
                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "MyKey", "alert('Fetching id failure.');", true);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        private void BindingIDs(DataTable table, DropDownList dropDownList, string DataTextField, string DataValueField, string messageType)
        {
            // Bind data to the DropDownList
            dropDownList.DataSource = table;
            dropDownList.DataTextField = DataTextField;
            dropDownList.DataValueField = DataValueField;
            dropDownList.DataBind();

            // Add a default item
            dropDownList.Items.Insert(0, new ListItem(messageType, "0"));
        }

        protected void userRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(userRoles.SelectedValue);

            int selectedValue;
            if (int.TryParse(userRoles.SelectedValue, out selectedValue))
            {
                ViewState["userRolesIndex"] = selectedValue;
            }
            else
            {
                ViewState["msgLabel"] = "You have selected wrong role.";
            }
        }

        protected void submit_Click(object sender, EventArgs e)
        {
            int? userRole = ViewState["userRolesIndex"] as int?;
            string imagePath = "https://images.unsplash.com/photo-1633332755192-727a05c4013d?auto=format&fit=crop&q=60&w=500&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8dXNlcnxlbnwwfHwwfHx8MA%3D%3D";

            using (SqlConnection conn = AppSettings.Connection())
            {
                string insertQuery = "INSERT INTO USERS (USERS_USERNAME, USERS_CNIC, USERS_PASSWORD, USERS_IMAGES_PATH, USERS_PHONE, USERS_ROLE) " +
                                     "VALUES (@Username, @CNIC, @Password, @ImagesPath, @Phone, @UserRole)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                {
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@Username", username.Text.Trim());
                    cmd.Parameters.AddWithValue("@CNIC", cnic.Text.Trim());
                    cmd.Parameters.AddWithValue("@Password", password.Text.Trim());
                    cmd.Parameters.AddWithValue("@ImagesPath", imagePath);
                    cmd.Parameters.AddWithValue("@Phone", phone.Text.Trim());
                    cmd.Parameters.AddWithValue("@UserRole", userRole);

                    try
                    {
                        conn.Open();
                        int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            ViewState["msgLabel"] = "User has been created successfully!";
                            Response.Redirect("login.aspx");
                        }
                        else
                        {
                            ViewState["msgLabel"] = "Error while adding the user. Try again.";
                        }
                    }
                    catch (SqlException ex)
                    {
                        ViewState["msgLabel"] = $"Something went wrong: {ex.Message}";
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        protected void reset_Click(object sender, EventArgs e)
        {
            EmptyFields();

        }

        private void EmptyFields()
        {
            username.Text = string.Empty;
            cnic.Text = string.Empty;
            password.Text = string.Empty;
            profileImage.AccessKey = string.Empty;
            phone.Text = string.Empty;
            userRoles.SelectedIndex = 0;
        }
    }
}