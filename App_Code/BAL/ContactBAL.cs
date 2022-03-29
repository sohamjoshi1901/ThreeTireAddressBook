using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using AddressBook.DAL;
using System.Data.SqlTypes;
using AddressBook.ENT;

/// <summary>
/// Summary description for ContactBAL
/// </summary>
namespace AddressBook.BAL
{

    public class ContactBAL
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
        public Boolean Insert(ContactENT entContact)
        {
            ContactDAL dalContact = new ContactDAL();

            if (dalContact.Insert(entContact))
            {
                return true;
            }
            else
            {
                Message = dalContact.Message;
                return false;
            }
        }
        #endregion

        #region Update Operation
        public Boolean Update(ContactENT entContact)
        {
            ContactDAL dalContact = new ContactDAL();

            if (dalContact.Update(entContact))
            {
                return true;
            }
            else
            {
                Message = dalContact.Message;
                return false;
            }
        }
        #endregion

        #region Delete Operation
        public Boolean Delete(SqlInt32 ContactID)
        {
            ContactDAL dalContact = new ContactDAL();

            if (dalContact.Delete(ContactID))
            {
                return true;
            }
            else
            {
                Message = dalContact.Message;
                return false;
            }
        }
        #endregion

        #region Select Operation

        #region SelectAll
        public DataTable SelectAll()
        {
            ContactDAL dalContact = new ContactDAL();
            return dalContact.SelectAll();
        }
        #endregion

        #region Select For Dropdown List
        public DataTable SelectForDropdownList()
        {
            ContactDAL dalContact = new ContactDAL();
            return dalContact.SelectForDropdownList();
        }
        #endregion

        #region SelectByPK
        public ContactENT SelectByPK(SqlInt32 ContactID)
        {
            ContactDAL dalContact = new ContactDAL();
            return dalContact.SelectByPK(ContactID);
        }
        #endregion

        #endregion
    }
}