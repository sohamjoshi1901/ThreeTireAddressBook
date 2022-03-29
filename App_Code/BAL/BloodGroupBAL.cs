using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using AddressBook.DAL;
using System.Data.SqlTypes;
using AddressBook.ENT;

/// <summary>
/// Summary description for BloodGroupBAL
/// </summary>
public class BloodGroupBAL 
{
	#region Local Variables
    private string _Message;

    public string Message
    {
        get
        {
            return _Message;
        }
        set
        {
            _Message = value;
        }
    }
    #endregion

    #region Insert Operation
    public Boolean Insert(BloodGroupENT entBloodGroup)
    {
        BloodGroupDAL dalBloodGroup = new BloodGroupDAL();

        if (dalBloodGroup.Insert(entBloodGroup))
        {
            return true;
        }
        else
        {
            Message = dalBloodGroup.Message;
            return false;
        }
    }
    #endregion

    #region Update Operation
    public Boolean Update(BloodGroupENT entBloodGroup)
    {
        BloodGroupDAL dalBloodGroup = new BloodGroupDAL();

        if (dalBloodGroup.Update(entBloodGroup))
        {
            return true;
        }
        else
        {
            Message = dalBloodGroup.Message;
            return false;
        }
    }
    #endregion

    #region Delete Operation
    public Boolean Delete(SqlInt32 BloodGroupID)
    {
        BloodGroupDAL dalBloodGroup = new BloodGroupDAL();

        if (dalBloodGroup.Delete(BloodGroupID))
        {
            return true;
        }
        else
        {
            Message = dalBloodGroup.Message;
            return false;
        }
    }
    #endregion

    #region Select Operation

    #region SelectAll
    public DataTable SelectAll()
    {
        BloodGroupDAL dalBloodGroup = new BloodGroupDAL();
        return dalBloodGroup.SelectAll();
    }
    #endregion

    #region Select For Dropdown List
    public DataTable SelectForDropdownList()
    {
        BloodGroupDAL dalBloodGroup = new BloodGroupDAL();
        return dalBloodGroup.SelectForDropdownList();
    }
    #endregion

    #region SelectByPK
    public BloodGroupENT SelectByPK(SqlInt32 BloodGroupID)
    {
        BloodGroupDAL dalBloodGroup = new BloodGroupDAL();
        return dalBloodGroup.SelectByPK(BloodGroupID);
    }
    #endregion

    #endregion
}