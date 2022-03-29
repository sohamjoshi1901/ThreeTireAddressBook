using AddressBook.BAL;
using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_ContactCategory_ContactCategoryAddEdit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
            if (Request.QueryString["ContactCategoryID"] != null)
            {
                FillControls(Convert.ToInt32(Request.QueryString["ContactCategoryID"]));
            }
        }
    }
    #region Button : Cancel
    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/ContactCategory/ContactCategoryList.aspx");
    }
    #endregion Button : Cancel

         #region Button:Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation
        string strError = "";
        if (txtCCName.Text == "")
            strError += "-Enter Contact Category Name</br>";
        if (strError != "")
        {
            lblMessage.Text = strError;
            return;
        }
        #endregion Server Side Validation

        #region Collect From Data

        ContactCategoryENT entContactCategory = new ContactCategoryENT();
        if (txtCCName.Text.Trim() != "")
        {
            entContactCategory.ContactCategoryName = txtCCName.Text.Trim();
        }

        #endregion Collect From Data

        ContactCategoryBAL balContactCategory = new ContactCategoryBAL();
        if (Request.QueryString["ContactCategoryID"] != null)
        {
            entContactCategory.ContactCategoryID = Convert.ToInt32(Request.QueryString["ContactCategoryID"]);
            if (balContactCategory.Update(entContactCategory))
            {
                Response.Redirect("~/AdminPanel/ContactCategory/ContactCategoryList.aspx");
            }
            else
            {
                lblMessage.Text = balContactCategory.Message;
            }
        }
        else
        {
            if (balContactCategory.Insert(entContactCategory))
            {
                lblMessage.Text = "data inserted successfully";
            }
            else
            {
                lblMessage.Text = balContactCategory.Message;
            }
        }
    }
    #endregion Button:Save

    #region FillControls
    private void FillControls(SqlInt32 ContactCategoryID)
    {
        ContactCategoryENT entContactCategory = new ContactCategoryENT();
        ContactCategoryBAL balContactCategory = new ContactCategoryBAL();

        entContactCategory = balContactCategory.SelectByPK(ContactCategoryID);

        if (!entContactCategory.ContactCategoryName.IsNull)
            txtCCName.Text = entContactCategory.ContactCategoryName.Value.ToString();
    }
    #endregion FillControls
    }
