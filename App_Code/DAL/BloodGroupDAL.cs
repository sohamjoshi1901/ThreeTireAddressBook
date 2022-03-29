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
/// Summary description for BloodGroupDAL
/// </summary>

namespace AddressBook.DAL
{

    public class BloodGroupDAL : DatabaseConfig
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
        public Boolean Insert(BloodGroupENT entBloodGroup)
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
                        objCmd.CommandText = "PR_BloodGroup_InsertByUserID";
                       // objCmd.Parameters.Add("@BloodGroupID", SqlDbType.Int,4).Direction = ParameterDirection.Output;
                        objCmd.Parameters.AddWithValue("@BloodGroupName", entBloodGroup.BloodGroupName);
                        objCmd.Parameters.Add("@UserID", SqlDbType.Int, 4).Value = Convert.ToInt32(HttpContext.Current.Session["UserID"]);

                        #endregion

                        objCmd.ExecuteNonQuery();

                        //entBloodGroup.BloodGroupID = (SqlInt32)objCmd.Parameters["@BloodGroupID"].Value;

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
        public Boolean Update(BloodGroupENT entBloodGroup)
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
                        objCmd.CommandText = "PR_BloodGroup_UpdateByPKByUserID";
                        objCmd.Parameters.AddWithValue("@BloodGroupID", entBloodGroup.BloodGroupID);
                        objCmd.Parameters.AddWithValue("@BloodGroupName", entBloodGroup.BloodGroupName);
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
        public Boolean Delete(SqlInt32 BloodGroupID)
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
                        objCmd.CommandText = "PR_BloodGroup_DeleteByPKByUserID";

                        objCmd.Parameters.AddWithValue("@BloodGroupID", BloodGroupID);
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
                        objCmd.CommandText = "PR_BloodGroup_SelectAllByUserID";
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
                        objCmd.CommandText = "PR_BloodGroup_SelectForDropDownListByUserID";
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
        public BloodGroupENT SelectByPK(SqlInt32 BloodGroupID)
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
                        objCmd.CommandText = "PR_BloodGroup_SelectByPK";
                        objCmd.Parameters.AddWithValue("@BloodGroupID", BloodGroupID);
                        #endregion

                        #region Read Data and return ENT

                        BloodGroupENT entBloodGroup = new BloodGroupENT();

                        SqlDataReader objSDR = objCmd.ExecuteReader();

                        if (objSDR.HasRows)
                        {
                            while (objSDR.Read())
                            {
                                if (!objSDR["BloodGroupName"].Equals(DBNull.Value))
                                    entBloodGroup.BloodGroupName = Convert.ToString(objSDR["BloodGroupName"]);



                                break;
                            }
                        }

                        return entBloodGroup;

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