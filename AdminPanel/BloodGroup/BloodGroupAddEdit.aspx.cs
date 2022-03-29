using AddressBook.BAL;
using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_BloodGroup_BloodGroupAddEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["BloodGroupID"] != null)
            {
                FillControls(Convert.ToInt32(Request.QueryString["BloodGroupID"]));
            }
        }
    }
    #region Button:Cancel
    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/BloodGroup/BloodGroupList.aspx");
    }
    #endregion Button:Cancel

    #region Button:Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation
        string strError = "";
        if (txtBloodGroupName.Text == "")
            strError += "-Enter Blood Group Name</br>";
        if (strError != "")
        {
            lblMessage.Text = strError;
            return;
        }
        #endregion Server Side Validation

        #region Collect From Data

        BloodGroupENT entBloodGroup = new BloodGroupENT();
        if (txtBloodGroupName.Text.Trim() != "")
        {
            entBloodGroup.BloodGroupName = txtBloodGroupName.Text.Trim();
        }

        #endregion Collect From Data

        BloodGroupBAL balBloodGroup = new BloodGroupBAL();
        if (Request.QueryString["BloodGroupID"] != null)
        {
            entBloodGroup.BloodGroupID = Convert.ToInt32((Request.QueryString["BloodGroupID"]));
            if (balBloodGroup.Update(entBloodGroup))
            {
                Response.Redirect("~/AdminPanel/BloodGroup/BloodGroupList.aspx");
                
            }
        }
        else
        {
            if (balBloodGroup.Insert(entBloodGroup))
            {
                lblMessage.Text = "data inserted successfully";
            }
            else
            {
                lblMessage.Text = balBloodGroup.Message;
            }
        }
    }
    #endregion Button:Save

     #region FillControls
    private void FillControls(SqlInt32 BloodGroupID)
    {
        BloodGroupENT entBloodGroup = new BloodGroupENT();
        BloodGroupBAL balBloodgroup = new BloodGroupBAL();

        entBloodGroup = balBloodgroup.SelectByPK(BloodGroupID);

        if (!entBloodGroup.BloodGroupName.IsNull)
            txtBloodGroupName.Text = entBloodGroup.BloodGroupName.Value.ToString();
    }
     #endregion FillControls
}