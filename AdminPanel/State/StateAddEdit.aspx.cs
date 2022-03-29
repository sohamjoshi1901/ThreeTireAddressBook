using AddressBook;
using AddressBook.BAL;
using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_State_StateAddEdit : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDownList();
            if (Request.QueryString["StateID"] != null)
            {
                FillControls(Convert.ToInt32(Request.QueryString["StateID"]));
            }
        }
    }
    #region Button : Cancel
    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/State/StateList.aspx");
    }
    #endregion Button : Cancel

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region ServerSideValidation
        string strError = "";
        if (ddlCountry.SelectedIndex == 0)
            strError += "-Select Country</br>";
        if (txtStateName.Text.Trim() == "")
            strError += "-Enter state Name";
        if (strError != "")
        {
            lblMessage.Text = strError;
            return;
        }
        #endregion ServerSideValidation

        #region Collect Form Data
        StateENT entState = new StateENT();

        if (ddlCountry.SelectedIndex > 0)
            entState.CountryID = Convert.ToInt32(ddlCountry.SelectedValue);

        if (txtStateName.Text.Trim() != "")
            entState.StateName = txtStateName.Text.Trim();
        #endregion Collect Form Data

        StateBAL balState = new StateBAL();

        if (Request.QueryString["StateID"] != null)
        {
            entState.StateID = Convert.ToInt32((Request.QueryString["StateID"]));
            if (balState.Update(entState))
            {
                Response.Redirect("~/AdminPanel/State/StateList.aspx");

            }
            else
            {
                lblMessage.Text = balState.Message;
            }
        }
        else
        {
            if (balState.Insert(entState))
            {
                lblMessage.Text = "Data Inserted SuccessFully";
            }
            else
            {
                lblMessage.Text = balState.Message;
            }
        }
    }
    #endregion Button : Save

    #region FillDropDownList
    private void FillDropDownList()
    {
        CommonFillMethods.FillDropDownListCountry(ddlCountry);
    }
    #endregion FillDropDownList

    #region FillControls
    private void FillControls(SqlInt32 StateID)
    {
        StateENT entState = new StateENT();
        StateBAL balState = new StateBAL();

        entState = balState.SelectByPK(StateID);

        if (!entState.StateName.IsNull)
            txtStateName.Text = entState.StateName.Value.ToString();

        if (!entState.CountryID.IsNull)
            ddlCountry.SelectedValue = entState.CountryID.Value.ToString();
    }
    #endregion FillControls
}