using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using AddressBook.DAL;
using System.Data.SqlTypes;
using AddressBook.ENT;

/// <summary>
/// Summary description for UserBAL
/// </summary>
namespace AddressBook.BAL
{
    public class UserBAL
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
        public Boolean Insert(UserENT entUser)
        {
            UserDAL dalUser = new UserDAL();

            if (dalUser.Insert(entUser))
            {
                return true;
            }
            else
            {
                Message = dalUser.Message;
                return false;
            }
        }
        #endregion

        #region Update Operation
        public Boolean Update(UserENT entUser)
        {
            UserDAL dalUser = new UserDAL();

            if (dalUser.Update(entUser))
            {
                return true;
            }
            else
            {
                Message = dalUser.Message;
                return false;
            }
        }
        #endregion

        #region Delete Operation
        public Boolean Delete(SqlInt32 UserID)
        {
            UserDAL dalUser = new UserDAL();

            if (dalUser.Delete(UserID))
            {
                return true;
            }
            else
            {
                Message = dalUser.Message;
                return false;
            }
        }
        #endregion

        #region Select Operation

        #region SelectAll
        public DataTable SelectAll()
        {
            UserDAL dalUser = new UserDAL();
            return dalUser.SelectAll();
        }
        #endregion

        #region Select For Dropdown List
        public DataTable SelectForDropdownList()
        {
            UserDAL dalUser = new UserDAL();
            return dalUser.SelectForDropdownList();
        }
        #endregion

        #region SelectByPK
        public UserENT SelectByPK(SqlInt32 UserID)
        {
            UserDAL dalUser = new UserDAL();
            return dalUser.SelectByPK(UserID);
        }
        #endregion

        #endregion
    }
}