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

public partial class AdminPanel_City_CityAddEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDownListCountry();
            FillDropDownListState();
            if (Request.QueryString["CityID"] != null)
            {
                FillControls(Convert.ToInt32(Request.QueryString["CityID"]));
            }
        }
    }
    #region Button : Cancel
    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/City/CityList.aspx");
    }
    #endregion Button : Cancel

     #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation
        string strError = "";
        if (ddlCountry.SelectedIndex == 0)
            strError += "-Select Country</br>";
        if (ddlState.SelectedIndex == 0)
            strError += "-Select State</br>";

        if (txtCityName.Text.Trim() == "")
            strError += "-Enter City Name";
        if (strError != "")
        {
            lblMessage.Text = strError;
            return;
        }
        #endregion Server Side Validation

        #region Collect From data
        CityENT entCity = new CityENT();
        if (ddlCountry.SelectedIndex > 0)
            entCity.CountryID = Convert.ToInt32(ddlCountry.SelectedValue);

        if (ddlState.SelectedIndex > 0)
            entCity.StateID = Convert.ToInt32(ddlState.SelectedValue);

        if (txtCityName.Text.Trim() != "")
            entCity.CityName = txtCityName.Text.Trim();

        if (txtPinCode.Text.Trim() != "")
            entCity.Pincode = txtPinCode.Text.Trim();

        if (txtSTDCode.Text.Trim() != "")
            entCity.STDCode = txtSTDCode.Text.Trim();

        #endregion Collect From data

        CityBAL balCity = new CityBAL();
        if (Request.QueryString["CityID"] != null)
        {
            entCity.CityID=Convert.ToInt32((Request.QueryString["CityID"]));
            if(balCity.Update(entCity))
            {
                Response.Redirect("~/AdminPanel/City/CityList.aspx");
            }
        }
        else
        {
            if (balCity.Insert(entCity))
            {
                lblMessage.Text = "Data Inserted SuccessFully";
            }
            else
            {
                lblMessage.Text = balCity.Message;
            }
        }
    }
     #endregion Button : Save

    #region FillDropDownListCountry
    private void FillDropDownListCountry()
    {
        CommonFillMethods.FillDropDownListCountry(ddlCountry);
    }
    #endregion FillDropDownListCountry

    #region FillDropDownListState
    private void FillDropDownListState()
    {
        CommonFillMethods.FillDropDownListState(ddlState);
    }
    #endregion FillDropDownListState

    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCountry.SelectedIndex > 0)
        {
            CommonFillMethods.FillDropDownStateByCountryID(ddlState, Convert.ToInt32(ddlCountry.SelectedValue.Trim()));
        }
        else
        {
            CommonFillMethods.FillDropDownListEmpty(ddlState, "State");
        }
    }

    #region FillControls
    private void FillControls(SqlInt32 CityID)
    {
        CityENT entCity = new CityENT();
        CityBAL balCity = new CityBAL();

        entCity = balCity.SelectByPK(CityID);

        if (!entCity.CityName.IsNull)
            txtCityName.Text = entCity.CityName.Value.ToString();

        if (!entCity.Pincode.IsNull)
            txtPinCode.Text = entCity.Pincode.Value.ToString();

        if (!entCity.STDCode.IsNull)
            txtSTDCode.Text = entCity.STDCode.Value.ToString();

        if (!entCity.StateID.IsNull)
            ddlState.SelectedValue = entCity.StateID.Value.ToString();

        if (!entCity.CountryID.IsNull)
            ddlCountry.SelectedValue = entCity.CountryID.Value.ToString();        
    }
    #endregion FillControls
}