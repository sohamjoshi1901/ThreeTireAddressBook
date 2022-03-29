using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using AddressBook.DAL;
using System.Data.SqlTypes;
using AddressBook.ENT;

/// <summary>
/// Summary description for CityBAL
/// </summary>
namespace AddressBook.BAL
{

    public class CityBAL
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
        public Boolean Insert(CityENT entCity)
        {
            CityDAL dalCity = new CityDAL();

            if (dalCity.Insert(entCity))
            {
                return true;
            }
            else
            {
                Message = dalCity.Message;
                return false;
            }
        }
        #endregion

        #region Update Operation
        public Boolean Update(CityENT entCity)
        {
            CityDAL dalCity = new CityDAL();

            if (dalCity.Update(entCity))
            {
                return true;
            }
            else
            {
                Message = dalCity.Message;
                return false;
            }
        }
        #endregion

        #region Delete Operation
        public Boolean Delete(SqlInt32 CityID)
        {
            CityDAL dalCity = new CityDAL();

            if (dalCity.Delete(CityID))
            {
                return true;
            }
            else
            {
                Message = dalCity.Message;
                return false;
            }
        }
        #endregion

        #region Select Operation

        #region SelectAll
        public DataTable SelectAll()
        {
            CityDAL dalCity = new CityDAL();
            return dalCity.SelectAll();
        }
        #endregion

        #region Select For Dropdown List
        public DataTable SelectForDropdownList(SqlInt32 StateID)
        {
            CityDAL dalCity = new CityDAL();
            return dalCity.SelectForDropdownList(StateID);
        }
        public DataTable SelectForDropdownList()
        {
            CityDAL dalCity = new CityDAL();
            return dalCity.SelectForDropDownList();
        }
        #endregion

        #region SelectByPK
        public CityENT SelectByPK(SqlInt32 CityID)
        {
            CityDAL dalCity = new CityDAL();
            return dalCity.SelectByPK(CityID);
        }
        #endregion

        #endregion
    }
}