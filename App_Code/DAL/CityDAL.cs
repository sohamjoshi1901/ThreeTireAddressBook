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
/// Summary description for CityDAL
/// </summary>

namespace AddressBook.DAL
{
    public class CityDAL : DatabaseConfig
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
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();

                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {

                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_City_InsertByUserID";
                        //objCmd.Parameters.Add("@CityID", SqlDbType.Int).Direction = ParameterDirection.Output;
                        objCmd.Parameters.AddWithValue("@CityName", entCity.CityName);
                        objCmd.Parameters.AddWithValue("@Pincode", entCity.Pincode);
                        objCmd.Parameters.AddWithValue("@STDCode", entCity.STDCode);
                        objCmd.Parameters.AddWithValue("@StateID", entCity.StateID);
                        objCmd.Parameters.AddWithValue("@CountryID", entCity.CountryID);
                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = HttpContext.Current.Session["UserID"];

                        #endregion

                        objCmd.ExecuteNonQuery();
                        //entCity.CityID = (SqlInt32)objCmd.Parameters["@CityID"].Value;

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
        public Boolean Update(CityENT entCity)
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
                        objCmd.CommandText = "PR_City_UpdateByPKByUserID";
                        objCmd.Parameters.AddWithValue("@CityID", entCity.CityID);
                        objCmd.Parameters.AddWithValue("@CityName", entCity.CityName);
                        objCmd.Parameters.AddWithValue("@Pincode", entCity.Pincode);
                        objCmd.Parameters.AddWithValue("@STDCode", entCity.STDCode);
                        objCmd.Parameters.AddWithValue("@StateID", entCity.StateID);
                        objCmd.Parameters.AddWithValue("@CountryID", entCity.CountryID);
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
        public Boolean Delete(SqlInt32 CityID)
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
                        objCmd.CommandText = "PR_City_DeleteByPKByUserID";
                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = HttpContext.Current.Session["UserID"];
                        objCmd.Parameters.AddWithValue("@CityID", CityID);

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
                        objCmd.CommandText = "PR_City_SelectAllByUserID";
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
        public DataTable SelectForDropdownList(SqlInt32 StateID)
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
                        objCmd.CommandText = "PR_City_SelectForDropDownListNewByUserID";

                        objCmd.Parameters.AddWithValue("@UserID", HttpContext.Current.Session["UserID"]);
                        objCmd.Parameters.AddWithValue("@StateID", StateID);
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
        public DataTable SelectForDropDownList()
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
                        objCmd.CommandText = "PR_City_SelectForDropDownListByUserID";
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
                        Message = sqlex.InnerException.Message;
                        return null;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message;
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
        public CityENT SelectByPK(SqlInt32 CityID)
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
                        objCmd.CommandText = "PR_City_SelectByPK";
                        objCmd.Parameters.AddWithValue("@CityID", CityID);
                        
                        #endregion

                        #region Read Data and return ENT

                        CityENT entCity = new CityENT();

                        SqlDataReader objSDR = objCmd.ExecuteReader();

                        if (objSDR.HasRows)
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["CityName"].Equals(DBNull.Value))
                                    entCity.CityName = Convert.ToString(objSDR["CityName"]);

                                if (!objSDR["Pincode"].Equals(DBNull.Value))
                                    entCity.Pincode = Convert.ToString(objSDR["Pincode"]);

                                if (!objSDR["STDCode"].Equals(DBNull.Value))
                                    entCity.STDCode = Convert.ToString(objSDR["STDCode"]);

                                if (!objSDR["StateID"].Equals(DBNull.Value))
                                    entCity.StateID = Convert.ToInt32(objSDR["StateID"]);

                                if (!objSDR["CountryID"].Equals(DBNull.Value))
                                    entCity.CountryID = Convert.ToInt32(objSDR["CountryID"]);



                                break;
                            }
                        }

                        return entCity;

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