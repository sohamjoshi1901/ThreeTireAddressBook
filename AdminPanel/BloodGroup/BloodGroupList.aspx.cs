using AddressBook.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_BloodGroup_BloodGroupList : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillGridView();
        }
    }
    #endregion Load Event

    #region FillGridView
    private void FillGridView()
    {
        BloodGroupBAL balBloodGroup = new BloodGroupBAL();
        DataTable dtBloodGroup = new DataTable();

        dtBloodGroup = balBloodGroup.SelectAll();

        if (dtBloodGroup != null && dtBloodGroup.Rows.Count > 0)
        {
            gvBloodGroup.DataSource = dtBloodGroup;
            gvBloodGroup.DataBind();
        }
    }
    #endregion FillGridView


    protected void gvBloodGroup_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                BloodGroupBAL balBloodGroup = new BloodGroupBAL();
                if (balBloodGroup.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                {
                    FillGridView();
                    lblMessage.Text = "Data Deleted SuccsessFully.";
                }
                else
                {
                    lblMessage.Text = balBloodGroup.Message;
                }
            }
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/BloodGroup/BloodGroupAddEdit.aspx");
    }
}