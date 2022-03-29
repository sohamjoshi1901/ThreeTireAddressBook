using AddressBook.BAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Country_CountryList : System.Web.UI.Page
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
        CountryBAL balCountry = new CountryBAL();
        DataTable dtCountry = new DataTable();

        dtCountry = balCountry.SelectAll();

        if (dtCountry != null && dtCountry.Rows.Count > 0)
        {
            gvCountry.DataSource = dtCountry;
            gvCountry.DataBind();
        }
    }
    #endregion FillGridView
    protected void gvCountry_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument != null)
            {
                CountryBAL balCountry = new CountryBAL();
                if (balCountry.Delete(Convert.ToInt32(e.CommandArgument.ToString().Trim())))
                {
                    FillGridView();
                    lblMessage.Text = "Data Deleted SuccsessFully.";
                }
                else
                {
                    lblMessage.Text = balCountry.Message;
                }
            }
        }
    }
    #region Button : Add
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Country/CountryAddEdit.aspx");
    }
    #endregion Button : Add
}