using KICS.Content.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Policy;
using static System.Net.Mime.MediaTypeNames;

namespace KICS.Controllers.admin.ApplicationsForms
{
    public partial class addApplicationForms : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userId"] == null && Session["username"] == null)
                {
                    Response.Redirect("../../auth/login.aspx");
                }
                msgLabel.Visible = false;

                FORMS_USERS_ID.Text = Session["username"].ToString();
                getCoursesDetailsForDropDownList();

            }
        }

        private void getCoursesDetailsForDropDownList()
        {
            DataTable coursesDataTable = GetIdsFromDatabase("SELECT * FROM COURSES;");

            string[] dataTextFieldColumns = { "COURSES_TITLE", "COURSES_DUES" };
            string dataValueField = "COURSES_ID";
            string messageType = "--- Select Course ---";
            BindingIDs(coursesDataTable, FORMS_STUDENT_COURSE_ID, dataTextFieldColumns, dataValueField, messageType);
        }

        protected void submitApplicationForm_Click(object sender, EventArgs e)
        {
            if (AreRequiredFieldsFilled())
            {
                try
                {
                    int? userId = Session["userId"] as int?;
                    int? courseId = ViewState["FORMS_STUDENT_COURSE_ID_Index"] as int?;

                    string imagePath = "https://images.unsplash.com/photo-1633332755192-727a05c4013d?auto=format&fit=crop&q=60&w=500&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8dXNlcnxlbnwwfHwwfHx8MA%3D%3D";

                    using (SqlConnection conn = AppSettings.Connection())
                    {
                        string query = @"INSERT INTO APPLICATION_FORMS VALUES
                        (@Username, @Email, @Dob, @StudentImages, @Qualifications, @FatherNames,
                         @StudentAddress, @StudentCourseId, @StudentPhones, @FatherPhones, @Timings,
                         @OfficeFees, @Discount, @UsersId)";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.CommandType = CommandType.Text;

                            cmd.Parameters.AddWithValue("@Username", FORMS_USERNAME.Text.Trim());
                            cmd.Parameters.AddWithValue("@Email", FORMS_EMAIL.Text.Trim());
                            cmd.Parameters.AddWithValue("@Dob", FORMS_DOB.Text.Trim());
                            cmd.Parameters.AddWithValue("@StudentImages", imagePath);
                            cmd.Parameters.AddWithValue("@Qualifications", FORMS_QUALIFICATIONS.Text.Trim());
                            cmd.Parameters.AddWithValue("@FatherNames", FORMS_STUDENT_FATHER_NAMES.Text.Trim());
                            cmd.Parameters.AddWithValue("@StudentAddress", FORMS_STUDENT_ADDRESS.Text.Trim());
                            cmd.Parameters.AddWithValue("@StudentCourseId", courseId);
                            cmd.Parameters.AddWithValue("@StudentPhones", FORMS_STUDENT_PHONES.Text.Trim());
                            cmd.Parameters.AddWithValue("@FatherPhones", FORMS_STUDENT_FATHER_PHONES.Text.Trim());
                            cmd.Parameters.AddWithValue("@Timings", FORMS_TIMINGS.Text.Trim());
                            cmd.Parameters.AddWithValue("@OfficeFees", FORMS_OFFICE_FEES.Text.Trim());
                            cmd.Parameters.AddWithValue("@Discount", FORMS_DISCOUNT.Text.Trim());
                            cmd.Parameters.AddWithValue("@UsersId", userId);


                            try
                            {
                                conn.Open();
                                int i = cmd.ExecuteNonQuery();
                                if (i > 0)
                                {
                                    msgLabel.Visible = true;
                                    msgLabel.Text = "Application has been submitted successfully by " + Session["username"].ToString();

                                    // Show success message using ScriptManager
                                    string script = "alert('Application has been submitted successfully by " + Session["username"].ToString() + "');";
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", script, true);

                                    resetFields();
                                }
                                else
                                {
                                    // Show error message using ScriptManager
                                    string script = "alert('Application did not submit due to some issue. Please review the form and try again. Thanks!');";
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorScript", script, true);
                                }
                            }

                            catch (SqlException ex)
                            {
                                // Check if the exception is due to a unique constraint violation (duplicate email)
                                if (ex.Number == 2627 || ex.Number == 2601)
                                {
                                    msgLabel.Visible = true;
                                    msgLabel.Text = "Email already exists. Please use a different email address.";
                                }
                                else
                                {
                                    throw; // If it's not a unique constraint violation, rethrow the exception.
                                }
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    msgLabel.Visible = true;
                    msgLabel.Text = $"Something went wrong: {ex.Message}";
                    // Log the exception for further investigation.
                }
            }
            else
            {
                msgLabel.Visible = true;
                msgLabel.Text = "Please fill in all the required fields before submitting the application.";
            }
        }

        private bool AreRequiredFieldsFilled()
        {
            return !string.IsNullOrEmpty(FORMS_USERNAME.Text.Trim()) &&
                   !string.IsNullOrEmpty(FORMS_EMAIL.Text.Trim()) &&
                   !string.IsNullOrEmpty(FORMS_DOB.Text.Trim()) &&
                   !string.IsNullOrEmpty(FORMS_QUALIFICATIONS.Text.Trim()) &&
                   !string.IsNullOrEmpty(FORMS_STUDENT_FATHER_NAMES.Text.Trim()) &&
                   FORMS_STUDENT_COURSE_ID.SelectedIndex != 0 && // Assuming 0 is the default index for the dropdown
                   !string.IsNullOrEmpty(FORMS_STUDENT_PHONES.Text.Trim()) &&
                   !string.IsNullOrEmpty(FORMS_STUDENT_FATHER_PHONES.Text.Trim()) &&
                   !string.IsNullOrEmpty(FORMS_TIMINGS.Text.Trim()) &&
                   true; // Add more conditions as needed
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

        private void BindingIDs(DataTable table, DropDownList dropDownList, string[] DataTextFieldColumns, string DataValueField, string messageType)
        {
            // Create a new column to store the concatenated values
            table.Columns.Add("CombinedText", typeof(string), string.Join(" + '\t\t\t ----- PKR ' + ", DataTextFieldColumns));

            // Bind data to the DropDownList
            dropDownList.DataSource = table;
            dropDownList.DataTextField = "CombinedText"; // Use the new CombinedText column
            dropDownList.DataValueField = DataValueField;
            dropDownList.DataBind();

            // Add a default item
            dropDownList.Items.Insert(0, new ListItem(messageType, "0"));
        }

        protected void FORMS_STUDENT_COURSE_ID_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Assuming your DropDownList has ListItem with integer values as data values
            int selectedCourseId;
            if (int.TryParse(FORMS_STUDENT_COURSE_ID.SelectedValue, out selectedCourseId))
            {
                ViewState["FORMS_STUDENT_COURSE_ID_Index"] = selectedCourseId;
            }
            else
            {
                ViewState["FORMS_STUDENT_COURSE_ID_Index"] = null;
            }
        }

        protected void reset_Click(object sender, EventArgs e)
        {
            resetFields();
        }
        private void resetFields()
        {
            FORMS_USERNAME.Text = string.Empty;
            FORMS_EMAIL.Text = string.Empty;
            FORMS_DOB.Text = string.Empty;
            FORMS_QUALIFICATIONS.Text = string.Empty;
            FORMS_STUDENT_FATHER_NAMES.Text = string.Empty;
            FORMS_STUDENT_PHONES.Text = string.Empty;
            FORMS_STUDENT_FATHER_PHONES.Text = string.Empty;
            FORMS_TIMINGS.Text = string.Empty;
            FORMS_OFFICE_FEES.Text = string.Empty;
            FORMS_DISCOUNT.Text = string.Empty;
            FORMS_USERS_ID.Text = string.Empty;
            FORMS_STUDENT_ADDRESS.Text = string.Empty;

            // Assuming you have a DropDownList with ID FORMS_STUDENT_COURSE_ID
            FORMS_STUDENT_COURSE_ID.SelectedIndex = 0;
            msgLabel.Visible = false;
        }
    }
}