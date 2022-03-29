using AddressBook;
using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
/// <summary>
/// Summary description for ContactDAL
/// </summary>
namespace AddressBook.DAL
{
    public class ContactDAL : DatabaseConfig
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
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();

                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {

                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;

                        objCmd.CommandText = "PR_Contact_InsertByUserID";
                        objCmd.Parameters.Add("@ContactID", SqlDbType.Int).Direction = ParameterDirection.Output;
                        objCmd.Parameters.AddWithValue("@PersonName", entContact.PersonName);
                        objCmd.Parameters.AddWithValue("@Address", entContact.Address);
                        objCmd.Parameters.AddWithValue("@CityID", entContact.CityID);
                        objCmd.Parameters.AddWithValue("@StateID", entContact.StateID);
                        objCmd.Parameters.AddWithValue("@CountryID", entContact.CountryID);
                        objCmd.Parameters.AddWithValue("@BloodGroupID", entContact.BloodGroupID);
                        objCmd.Parameters.AddWithValue("@PinCode", entContact.PinCode);
                        objCmd.Parameters.AddWithValue("@MobileNo", entContact.MobileNo);
                        objCmd.Parameters.AddWithValue("@PhoneNo", entContact.PhoneNo);
                        objCmd.Parameters.AddWithValue("@Email", entContact.Email);
                        objCmd.Parameters.AddWithValue("@Gender", entContact.Gender);
                        objCmd.Parameters.AddWithValue("@Birthdate", entContact.Birthdate);
                        objCmd.Parameters.AddWithValue("@Profession", entContact.Profession);
                        
                        objCmd.Parameters.AddWithValue("@ContactCategoryID", entContact.ContactCategoryID);
                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = HttpContext.Current.Session["UserID"];

                        #endregion

                        objCmd.ExecuteNonQuery();

                       entContact.ContactID =Convert.ToInt32(objCmd.Parameters["@ContactID"].Value);

                        return true;
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.Message;
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.Message;
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }
        #endregion

        #region Update Operation
        public Boolean Update(ContactENT entContact)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();

                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {

                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Contact_UpdateByPKByUserID";
                        objCmd.Parameters.AddWithValue("@ContactID", entContact.ContactID);
                        objCmd.Parameters.AddWithValue("@PersonName", entContact.PersonName);
                        objCmd.Parameters.AddWithValue("@Address", entContact.Address);
                        objCmd.Parameters.AddWithValue("@CityID", entContact.CityID);
                        objCmd.Parameters.AddWithValue("@StateID", entContact.StateID);
                        objCmd.Parameters.AddWithValue("@BloodGroupID", entContact.BloodGroupID);
                        objCmd.Parameters.AddWithValue("@CountryID", entContact.CountryID);
                        objCmd.Parameters.AddWithValue("@PinCode", entContact.PinCode);
                        objCmd.Parameters.AddWithValue("@MobileNo", entContact.MobileNo);
                        objCmd.Parameters.AddWithValue("@PhoneNo", entContact.PhoneNo);
                        objCmd.Parameters.AddWithValue("@Email", entContact.Email);
                        objCmd.Parameters.AddWithValue("@Gender", entContact.Gender);
                        objCmd.Parameters.AddWithValue("@Birthdate", entContact.Birthdate);
                        objCmd.Parameters.AddWithValue("@Profession", entContact.Profession);
                        
                        objCmd.Parameters.AddWithValue("@ContactCategoryID", entContact.ContactCategoryID);
                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = HttpContext.Current.Session["UserID"];

                        #endregion

                        objCmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.Message;
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.Message;
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }
        #endregion

        #region Delete Operation
        public Boolean Delete(SqlInt32 ContactID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();

                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {

                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Contact_DeleteByPKByUserID";


                        objCmd.Parameters.AddWithValue("@ContactID", ContactID);
                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = HttpContext.Current.Session["UserID"];

                        #endregion


                        objCmd.ExecuteNonQuery();

                        return true;
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.Message;
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.Message;
                        return false;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }
        #endregion

        #region Select Operation

        #region SelectAll
        public DataTable SelectAll()
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();

                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Contact_SelectAllByUserID";
                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = HttpContext.Current.Session["UserID"];
                        #endregion

                        #region Read Data and return DataTable
                        DataTable dt = new DataTable();

                        using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;
                        #endregion
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.Message;
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.Message;
                        return null;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }
        #endregion

        #region SelectForDropdownList
        public DataTable SelectForDropdownList()
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();

                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {

                        DataTable dt = new DataTable();

                        return dt;
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.Message;
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.Message;
                        return null;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }
        #endregion

        #region SelectByPK
        public ContactENT SelectByPK(SqlInt32 ContactID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();

                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Contact_SelectByPK";
                        objCmd.Parameters.AddWithValue("@ContactID", ContactID);
                        #endregion

                        #region Read Data and return ENT

                        ContactENT entContact = new ContactENT();

                        SqlDataReader objSDR = objCmd.ExecuteReader();

                        if (objSDR.HasRows)
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["PersonName"].Equals(DBNull.Value))
                                    entContact.PersonName = Convert.ToString(objSDR["PersonName"]);

                                if (!objSDR["Address"].Equals(DBNull.Value))
                                    entContact.Address = Convert.ToString(objSDR["Address"]);

                                if (!objSDR["CityID"].Equals(DBNull.Value))
                                    entContact.CityID = Convert.ToInt32(objSDR["CityID"]);

                                if (!objSDR["StateID"].Equals(DBNull.Value))
                                    entContact.StateID = Convert.ToInt32(objSDR["StateID"]);

                                if (!objSDR["CountryID"].Equals(DBNull.Value))
                                    entContact.CountryID = Convert.ToInt32(objSDR["CountryID"]);

                                if (!objSDR["PinCode"].Equals(DBNull.Value))
                                    entContact.PinCode = Convert.ToString(objSDR["PinCode"]);

                                if (!objSDR["MobileNo"].Equals(DBNull.Value))
                                    entContact.MobileNo = Convert.ToString(objSDR["MobileNo"]);

                                if (!objSDR["PhoneNo"].Equals(DBNull.Value))
                                    entContact.PhoneNo = Convert.ToString(objSDR["PhoneNo"]);

                                if (!objSDR["Email"].Equals(DBNull.Value))
                                    entContact.Email = Convert.ToString(objSDR["Email"]);

                                if (!objSDR["Gender"].Equals(DBNull.Value))
                                    entContact.Gender = Convert.ToString(objSDR["Gender"]);

                                if (!objSDR["Birthdate"].Equals(DBNull.Value))
                                    entContact.Birthdate = Convert.ToDateTime(objSDR["Birthdate"]);

                                if (!objSDR["Profession"].Equals(DBNull.Value))
                                    entContact.Profession = Convert.ToString(objSDR["Profession"]);

                                if (!objSDR["BloodGroupID"].Equals(DBNull.Value))
                                    entContact.BloodGroupID = Convert.ToInt32(objSDR["BloodGroupID"]);

                                if (!objSDR["ContactCategoryID"].Equals(DBNull.Value))
                                    entContact.ContactCategoryID = Convert.ToInt32(objSDR["ContactCategoryID"]);



                                break;
                            }
                        }

                        return entContact;

                        #endregion;
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.Message;
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.Message;
                        return null;
                    }
                    finally
                    {
                        if (objConn.State == ConnectionState.Open)
                            objConn.Close();
                    }
                }
            }
        }
        #endregion

        #endregion
    }
}