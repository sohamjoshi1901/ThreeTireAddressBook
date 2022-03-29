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
/// Summary description for StateDAL
/// </summary>
namespace AddressBook.DAL
{
    public class StateDAL : DatabaseConfig
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
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                objConn.Open();

                using (SqlCommand objCmd = objConn.CreateCommand())
                {
                    try
                    {

                        #region Prepare Command
                        objCmd.CommandType = CommandType.StoredProcedure;
                        objCmd.CommandText = "PR_State_InsertByUserID";
                       // objCmd.Parameters.Add("@StateID", SqlDbType.Int).Direction = ParameterDirection.Output;
                        objCmd.Parameters.AddWithValue("@StateName", entState.StateName);
                        objCmd.Parameters.Add("@CountryID", SqlDbType.Int).Value = entState.CountryID;
                        objCmd.Parameters.Add("@UserID", SqlDbType.Int).Value = HttpContext.Current.Session["UserID"];

                        #endregion

                        objCmd.ExecuteNonQuery();
                       // entState.StateID = (SqlInt32)objCmd.Parameters["@StateID"].Value;

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
        public Boolean Update(StateENT entState)
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
                        objCmd.CommandText = "PR_State_UpdateByPKByUserID";
                        objCmd.Parameters.AddWithValue("@StateID", entState.StateID);
                        objCmd.Parameters.AddWithValue("@StateName", entState.StateName);
                        objCmd.Parameters.AddWithValue("@CountryID", entState.CountryID);
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
        public Boolean Delete(SqlInt32 StateID)
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
                        objCmd.CommandText = "PR_State_DeleteByPKByUserID";

                        objCmd.Parameters.AddWithValue("@StateID", StateID);
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
                        objCmd.CommandText = "PR_State_SelectAllByUserID";
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
        public DataTable SelectForDropdownList(SqlInt32 CountryID)
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
                        objCmd.CommandText = "PR_State_SelectForDropDownListNewByUserID";

                        objCmd.Parameters.AddWithValue("@UserID", HttpContext.Current.Session["UserID"]);
                        objCmd.Parameters.AddWithValue("@CountryID", CountryID);
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
                        objCmd.CommandText = "PR_State_SelectForDropDownListByUserID";
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
        public StateENT SelectByPK(SqlInt32 StateID)
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
                        objCmd.CommandText = "PR_State_SelectByPK";
                        objCmd.Parameters.AddWithValue("@StateID", StateID);
                        #endregion

                        #region Read Data and return ENT

                        StateENT entState = new StateENT();

                        SqlDataReader objSDR = objCmd.ExecuteReader();

                        if (objSDR.HasRows)
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["StateName"].Equals(DBNull.Value))
                                    entState.StateName = Convert.ToString(objSDR["StateName"]);

                                if (!objSDR["CountryID"].Equals(DBNull.Value))
                                    entState.CountryID = Convert.ToInt32(objSDR["CountryID"]);



                                break;
                            }
                        }

                        return entState;

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