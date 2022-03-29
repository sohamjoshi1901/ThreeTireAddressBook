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
/// Summary description for UserDAL
/// </summary>
namespace AddressBook.DAL
{

    public class UserDAL : DatabaseConfig
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
        public Boolean Insert(UserENT entUser)
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
                        objCmd.CommandText = "PR_User_Insert";
                        objCmd.Parameters.AddWithValue("@UserName", entUser.UserName);
                        objCmd.Parameters.AddWithValue("@Password", entUser.Password);
                        objCmd.Parameters.AddWithValue("@DisplayName", entUser.DisplayName);
                        objCmd.Parameters.AddWithValue("@Address", entUser.Address);
                        objCmd.Parameters.AddWithValue("@MobileNo", entUser.MobileNo);

                        #endregion

                        objCmd.ExecuteNonQuery();

                        return true;
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message;
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message;
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
        public Boolean Update(UserENT entUser)
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
                        objCmd.CommandText = "PR_User_UpdateByPK";
                        objCmd.Parameters.AddWithValue("@UserName", entUser.UserName);
                        objCmd.Parameters.AddWithValue("@Password", entUser.Password);
                        objCmd.Parameters.AddWithValue("@DisplayName", entUser.DisplayName);
                        objCmd.Parameters.AddWithValue("@Address", entUser.Address);
                        objCmd.Parameters.AddWithValue("@MobileNo", entUser.MobileNo);

                        #endregion

                        objCmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message;
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message;
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
        public Boolean Delete(SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_User_DeleteByPK";

                        objCmd.Parameters.AddWithValue("@UserID", UserID);

                        #endregion


                        objCmd.ExecuteNonQuery();

                        return true;
                    }
                    catch (SqlException sqlex)
                    {
                        Message = sqlex.InnerException.Message;
                        return false;
                    }
                    catch (Exception ex)
                    {
                        Message = ex.InnerException.Message;
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
                        objCmd.CommandText = "PR_User_SelectAll";
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
        public UserENT SelectByPK(SqlInt32 UserID)
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
                        objCmd.CommandText = "PR_User_SelectByPK";
                        objCmd.Parameters.AddWithValue("@UserID", UserID);
                        #endregion

                        #region Read Data and return ENT

                        UserENT entUser = new UserENT();

                        SqlDataReader objSDR = objCmd.ExecuteReader();

                        if (objSDR.HasRows)
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["UserName"].Equals(DBNull.Value))
                                    entUser.UserName = Convert.ToString(objSDR["UserName"]);

                                if (!objSDR["Password"].Equals(DBNull.Value))
                                    entUser.Password = Convert.ToString(objSDR["Password"]);

                                if (!objSDR["DisplayName"].Equals(DBNull.Value))
                                    entUser.DisplayName = Convert.ToString(objSDR["DisplayName"]);

                                if (!objSDR["Address"].Equals(DBNull.Value))
                                    entUser.Address = Convert.ToString(objSDR["Address"]);

                                if (!objSDR["MobileNo"].Equals(DBNull.Value))
                                    entUser.MobileNo = Convert.ToString(objSDR["MobileNo"]);



                                break;
                            }
                        }

                        return entUser;

                        #endregion;
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

        #endregion
    }
}