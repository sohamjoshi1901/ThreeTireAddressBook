using AddressBook.BAL;
using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Country_CountryAddEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
            if (Request.QueryString["CountryID"] != null)
            {
                FillControls(Convert.ToInt32(Request.QueryString["CountryID"]));
            }
        }
    }
    #region Button : Cancel
    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Country/CountryList.aspx");
    }
    #endregion Button : Cancel

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation
        string strError = "";
        if (txtCountryCode.Text.Trim() == "")
        {
            strError += "-Enter Country Code </br>";
        }
        if (txtCountryName.Text == "")
            strError += "-Enter Contact Category Name</br>";
        if (strError != "")
        {
            lblMessage.Text = strError;
            return;
        }
        #endregion Server Side Validation

        #region Collect From Data

        CountryENT entCountry = new CountryENT();
        if (txtCountryName.Text.Trim() != "")
        {
            entCountry.CountryName = txtCountryName.Text.Trim();
        }

        if (txtCountryCode.Text.Trim() != "")
        {
            entCountry.CountryCode = txtCountryCode.Text.Trim();
        }
        #endregion Collect From Data

        CountryBAL balCountry = new CountryBAL();
        if (Request.QueryString["CountryID"] != null)
        {
            entCountry.CountryID = Convert.ToInt32((Request.QueryString["CountryID"]));
            if (balCountry.Update(entCountry))
            {
                Response.Redirect("~/AdminPanel/Country/CountryList.aspx");
            }
            else
            {
                lblMessage.Text = balCountry.Message;
            }
        }
        else
        {
            if (balCountry.Insert(entCountry))
            {
                lblMessage.Text = "data inserted successfully";
            }
            else
            {
                lblMessage.Text = balCountry.Message;
            }
        }
    }
    #endregion Button : Save

    #region FillControls
    private void FillControls(SqlInt32 CountryID)
    {
        CountryENT entCountry = new CountryENT();
        CountryBAL balCountry = new CountryBAL();

        entCountry = balCountry.SelectByPK(CountryID);

        if (!entCountry.CountryName.IsNull)
            txtCountryName.Text = entCountry.CountryName.Value.ToString();

        if (!entCountry.CountryCode.IsNull)
            txtCountryCode.Text = entCountry.CountryCode.Value.ToString();

    }
    #endregion FillControls
}