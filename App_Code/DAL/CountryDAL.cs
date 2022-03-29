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
/// Summary description for CountryDAL
/// </summary>
namespace AddressBook.DAL
{

    public class CountryDAL : DatabaseConfig
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
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();

                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {

                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Country_InsertByUserID";
                        //objCmd.Parameters.Add("@CountryID", SqlDbType.Int).Direction = ParameterDirection.Output;
                        objCmd.Parameters.AddWithValue("@CountryName", entCountry.CountryName);
                        objCmd.Parameters.AddWithValue("@CountryCode", entCountry.CountryCode);
                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = HttpContext.Current.Session["UserID"];

                        #endregion

                        objCmd.ExecuteNonQuery();
                       // entCountry.CountryID = (SqlInt32)objCmd.Parameters["@CountryID"].Value;
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
        public Boolean Update(CountryENT entCountry)
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
                        objCmd.CommandText = "PR_Country_UpdateByPKByUserID";
                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = HttpContext.Current.Session["UserID"];
                        objCmd.Parameters.AddWithValue("@CountryID", entCountry.CountryID);
                        objCmd.Parameters.AddWithValue("@CountryName", entCountry.CountryName);
                        objCmd.Parameters.AddWithValue("@CountryCode", entCountry.CountryCode);
                        

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
        public Boolean Delete(SqlInt32 CountryID)
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
                        objCmd.CommandText = "PR_Country_DeleteByPKByUserID";

                        objCmd.Parameters.AddWithValue("@CountryID", CountryID);
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
                        objCmd.CommandText = "PR_Country_SelectAllByUserID";
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
                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_Country_SelectForDropDownListByUserID";
                        objCmd.Parameters.AddWithValue("@UserID", HttpContext.Current.Session["UserID"]);
                        #endregion Prepare Command

                        #region ReadData and Set Controls
                        DataTable dt = new DataTable();
                         using (SqlDataReader objSDR = objCmd.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        
                        return dt;
                        #endregion ReadData and Set Controls
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
        public CountryENT SelectByPK(SqlInt32 CountryID)
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
                        objCmd.CommandText = "PR_Country_SelectByPK";
                        objCmd.Parameters.AddWithValue("@CountryID", CountryID);
                        #endregion

                        #region Read Data and return ENT

                        CountryENT entCountry = new CountryENT();

                        SqlDataReader objSDR = objCmd.ExecuteReader();

                        if (objSDR.HasRows)
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["CountryName"].Equals(DBNull.Value))
                                    entCountry.CountryName = Convert.ToString(objSDR["CountryName"]);

                                if (!objSDR["CountryCode"].Equals(DBNull.Value))
                                    entCountry.CountryCode = Convert.ToString(objSDR["CountryCode"]);



                                break;
                            }
                        }

                        return entCountry;

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