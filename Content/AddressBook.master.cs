using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Content_AddressBook : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        #region Check For Valid User

        if (Session["UserID"] == null)
            Response.Redirect("~/AdminPanel/Login.aspx");

        #endregion Check For Valid User
        if (!Page.IsPostBack)
        {
            if (Session["DisplayName"] != null)
                lblUserName.Text = "Hi!" + Session["DisplayName"].ToString().Trim();
        }
       
       
    }

    protected void btnLogout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Response.Redirect("~/AdminPanel/Login.aspx");
    }
}
