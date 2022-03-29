using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CityENT
/// </summary>
namespace AddressBook.ENT
{

    public class CityENT
    {
        #region Constructor

        public CityENT()
        {

        }

        #endregion

        #region CityID

        protected SqlInt32 _CityID;

        public SqlInt32 CityID
        {
            get
            {
                return _CityID;
            }
            set
            {
                _CityID = value;
            }
        }

        #endregion

        #region CityName

        protected SqlString _CityName;

        public SqlString CityName
        {
            get
            {
                return _CityName;
            }
            set
            {
                _CityName = value;
            }
        }

        #endregion

        #region Pincode

        protected SqlString _Pincode;

        public SqlString Pincode
        {
            get
            {
                return _Pincode;
            }
            set
            {
                _Pincode = value;
            }
        }

        #endregion

        #region STDCode

        protected SqlString _STDCode;

        public SqlString STDCode
        {
            get
            {
                return _STDCode;
            }
            set
            {
                _STDCode = value;
            }
        }

        #endregion

        #region StateID

        protected SqlInt32 _StateID;

        public SqlInt32 StateID
        {
            get
            {
                return _StateID;
            }
            set
            {
                _StateID = value;
            }
        }

        #endregion

        #region CountryID

        protected SqlInt32 _CountryID;

        public SqlInt32 CountryID
        {
            get
            {
                return _CountryID;
            }
            set
            {
                _CountryID = value;
            }
        }

        #endregion

        #region UserID

        protected SqlInt32 _UserID;

        public SqlInt32 UserID
        {
            get
            {
                return _UserID;
            }
            set
            {
                _UserID = value;
            }
        }

        #endregion


    }
}