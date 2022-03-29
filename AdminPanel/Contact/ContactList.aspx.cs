using AddressBook.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Contact_ContactList : System.Web.UI.Page
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
        ContactBAL balContact = new ContactBAL();
        DataTable dtContact = new DataTable();

        dtContact = balContact.SelectAll();

        if (dtContact != null && dtContact.Rows.Count > 0)
        {
            gvContact.DataSource = dtContact;
            gvContact.DataBind();
        }
    }
    #endregion FillGridView

    #region Contact_RowCommand
    protected void gvContact_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                ContactBAL balContact = new ContactBAL();
                if (balContact.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                {
                    FillGridView();
                    lblMessage.Text = "Data Deleted SuccsessFully.";
                }
                else
                {
                    lblMessage.Text = balContact.Message;
                }
            }
        }
    }
    #endregion Contact_RowCommand

    #region Button : Add
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Contact/ContactAddEdit.aspx");
    }
    #endregion Button : Add

}