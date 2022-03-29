using AddressBook.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_ContactCategory_ContactCategoryList : System.Web.UI.Page
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
        ContactCategoryBAL balContactCategory = new ContactCategoryBAL();
        DataTable dtContactCategory = new DataTable();

        dtContactCategory = balContactCategory.SelectAll();

        if (dtContactCategory != null && dtContactCategory.Rows.Count > 0)
        {
            gvContactCategory.DataSource = dtContactCategory;
            gvContactCategory.DataBind();
        }
    }
    #endregion FillGridView
    protected void gvContactCategory_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                ContactCategoryBAL balContactCategory = new ContactCategoryBAL();
                if (balContactCategory.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                {
                    FillGridView();
                    lblMessage.Text = "Data Deleted SuccsessFully.";
                }
                else
                {
                    lblMessage.Text = balContactCategory.Message;
                }
            }
        }
    }
    #region Button : Add
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/ContactCategory/ContactCategoryAddEdit.aspx");
    }
    #endregion Button : Add
}