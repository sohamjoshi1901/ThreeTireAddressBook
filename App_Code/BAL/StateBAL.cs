using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using AddressBook.DAL;
using System.Data.SqlTypes;
using AddressBook.ENT;

/// <summary>
/// Summary description for StateBAL
/// </summary>
namespace AddressBook.BAL
{

    public class StateBAL
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
        public Boolean Insert(StateENT entState)
        {
            StateDAL dalState = new StateDAL();

            if (dalState.Insert(entState))
            {
                return true;
            }
            else
            {
                Message = dalState.Message;
                return false;
            }
        }
        #endregion

        #region Update Operation
        public Boolean Update(StateENT entState)
        {
            StateDAL dalState = new StateDAL();

            if (dalState.Update(entState))
            {
                return true;
            }
            else
            {
                Message = dalState.Message;
                return false;
            }
        }
        #endregion

        #region Delete Operation
        public Boolean Delete(SqlInt32 StateID)
        {
            StateDAL dalState = new StateDAL();

            if (dalState.Delete(StateID))
            {
                return true;
            }
            else
            {
                Message = dalState.Message;
                return false;
            }
        }
        #endregion

        #region Select Operation

        #region SelectAll
        public DataTable SelectAll()
        {
            StateDAL dalState = new StateDAL();
            return dalState.SelectAll();
        }
        #endregion

        #region Select For Dropdown List
        public DataTable SelectForDropdownList(SqlInt32 CountryID)
        {
            StateDAL dalState = new StateDAL();
            return dalState.SelectForDropdownList(CountryID);
        }
        public DataTable SelectForDropdownList()
        {
            StateDAL dalState = new StateDAL();
            return dalState.SelectForDropDownList();
        }
        #endregion

        #region SelectByPK
        public StateENT SelectByPK(SqlInt32 StateID)
        {
            StateDAL dalState = new StateDAL();
            return dalState.SelectByPK(StateID);
        }
        #endregion

        #endregion
    }
}