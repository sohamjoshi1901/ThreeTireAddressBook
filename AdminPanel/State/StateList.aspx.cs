using AddressBook.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_State_StateList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillGridView();
        }
    }
    #region FillGridView
    private void FillGridView()
    {
        StateBAL balState = new StateBAL();
        DataTable dtState = new DataTable();

        dtState = balState.SelectAll();

        if (dtState != null && dtState.Rows.Count > 0)
        {
            gvState.DataSource = dtState;
            gvState.DataBind();
        }
    }
    #endregion FillGridView
    protected void gvState_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                StateBAL balState = new StateBAL();
                if (balState.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                {
                    FillGridView();
                    lblMessage.Text = "Data Deleted SuccsessFully.";
                }
                else
                {
                    lblMessage.Text = balState.Message;
                }
            }
        }
    }
    #region Button : Add
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/State/StateAddEdit.aspx");
    }
    #endregion Button : Add
}