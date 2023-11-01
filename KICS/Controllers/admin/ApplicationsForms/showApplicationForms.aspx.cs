using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KICS.Controllers.admin.ApplicationsForms
{
    public partial class showApplicationForms : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridViewQuestionManage_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int rowIndex = e.Row.RowIndex;
                int startingIndex = GridViewQuestionManage.PageIndex * GridViewQuestionManage.PageSize;
                int displayIndex = startingIndex + rowIndex + 1;

                e.Row.Cells[0].Text = displayIndex.ToString();
            }
        }

        protected void GridViewQuestionManage_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "PrintRecord")
            {
                // Get the FORMS_ID from the CommandArgument
                int formsId = Convert.ToInt32(e.CommandArgument);

                // Redirect to a print page with the selected record ID
                Response.Redirect($"PrintPage.aspx?FormsId={formsId}");
            }
        }
    }
}