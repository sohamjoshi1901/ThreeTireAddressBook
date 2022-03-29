using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using AddressBook.DAL;
using System.Data.SqlTypes;
using AddressBook.ENT;

/// <summary>
/// Summary description for CountryBAL
/// </summary>
namespace AddressBook.BAL
{

    public class CountryBAL
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
        public Boolean Insert(CountryENT entCountry)
        {
            CountryDAL dalCountry = new CountryDAL();

            if (dalCountry.Insert(entCountry))
            {
                return true;
            }
            else
            {
                Message = dalCountry.Message;
                return false;
            }
        }
        #endregion

        #region Update Operation
        public Boolean Update(CountryENT entCountry)
        {
            CountryDAL dalCountry = new CountryDAL();

            if (dalCountry.Update(entCountry))
            {
                return true;
            }
            else
            {
                Message = dalCountry.Message;
                return false;
            }
        }
        #endregion

        #region Delete Operation
        public Boolean Delete(SqlInt32 CountryID)
        {
            CountryDAL dalCountry = new CountryDAL();

            if (dalCountry.Delete(CountryID))
            {
                return true;
            }
            else
            {
                Message = dalCountry.Message;
                return false;
            }
        }
        #endregion

        #region Select Operation

        #region SelectAll
        public DataTable SelectAll()
        {
            CountryDAL dalCountry = new CountryDAL();
            return dalCountry.SelectAll();
        }
        #endregion

        #region Select For Dropdown List
        public DataTable SelectForDropdownList()
        {
            CountryDAL dalCountry = new CountryDAL();
            return dalCountry.SelectForDropdownList();
        }
        #endregion

        #region SelectByPK
        public CountryENT SelectByPK(SqlInt32 CountryID)
        {
            CountryDAL dalCountry = new CountryDAL();
            return dalCountry.SelectByPK(CountryID);
        }
        #endregion

        #endregion
    }
}