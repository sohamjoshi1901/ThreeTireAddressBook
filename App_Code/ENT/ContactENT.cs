using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContactENT
/// </summary>
namespace AddressBook.ENT
{
    public class ContactENT
    {
        #region Constructor

        public ContactENT()
        {

        }

        #endregion

        #region ContactID

        protected SqlInt32 _ContactID;

        public SqlInt32 ContactID
        {
            get
            {
                return _ContactID;
            }
            set
            {
                _ContactID = value;
            }
        }

        #endregion

        #region PersonName

        protected SqlString _PersonName;

        public SqlString PersonName
        {
            get
            {
                return _PersonName;
            }
            set
            {
                _PersonName = value;
            }
        }

        #endregion

        #region Address

        protected SqlString _Address;

        public SqlString Address
        {
            get
            {
                return _Address;
            }
            set
            {
                _Address = value;
            }
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

        #region PinCode

        protected SqlString _PinCode;

        public SqlString PinCode
        {
            get
            {
                return _PinCode;
            }
            set
            {
                _PinCode = value;
            }
        }

        #endregion

        #region MobileNo

        protected SqlString _MobileNo;

        public SqlString MobileNo
        {
            get
            {
                return _MobileNo;
            }
            set
            {
                _MobileNo = value;
            }
        }

        #endregion

        #region PhoneNo

        protected SqlString _PhoneNo;

        public SqlString PhoneNo
        {
            get
            {
                return _PhoneNo;
            }
            set
            {
                _PhoneNo = value;
            }
        }

        #endregion

        #region Email

        protected SqlString _Email;

        public SqlString Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
            }
        }

        #endregion

        #region Gender

        protected SqlString _Gender;

        public SqlString Gender
        {
            get
            {
                return _Gender;
            }
            set
            {
                _Gender = value;
            }
        }

        #endregion

        #region Birthdate

        protected SqlDateTime _Birthdate;

        public SqlDateTime Birthdate
        {
            get
            {
                return _Birthdate;
            }
            set
            {
                _Birthdate = value;
            }
        }

        #endregion

        #region Profession

        protected SqlString _Profession;

        public SqlString Profession
        {
            get
            {
                return _Profession;
            }
            set
            {
                _Profession = value;
            }
        }

        #endregion

        #region BloodGroupID

        protected SqlInt32 _BloodGroupID;

        public SqlInt32 BloodGroupID
        {
            get
            {
                return _BloodGroupID;
            }
            set
            {
                _BloodGroupID = value;
            }
        }

        #endregion

        #region ContactCategoryID

        protected SqlInt32 _ContactCategoryID;

        public SqlInt32 ContactCategoryID
        {
            get
            {
                return _ContactCategoryID;
            }
            set
            {
                _ContactCategoryID = value;
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