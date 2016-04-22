using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using PortfolioBLDAL.Models;
using System.Configuration;

namespace PortfolioBLDAL.DataLayer
{
    public class ProjectDAL : DBHelper
    {
        private SqlConnection _DBConn;

        public ProjectDAL()
        {
            _DBConn = base.Connection;
        }

        #region Methods

        public SqlDataReader ProjectSelect(int projectId)
        {
            SqlDataReader data;
            try
            {
                SqlCommand selectCommand = new SqlCommand();
                selectCommand.CommandType = CommandType.StoredProcedure;
                selectCommand.CommandText = "Projects_Select";
                selectCommand.Connection = this._DBConn;
                selectCommand.Parameters.AddWithValue("@projectId", projectId);
                if (this._DBConn.State == ConnectionState.Closed)
                {
                    this._DBConn.Open();
                }
                data = selectCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                if (ConfigurationManager.AppSettings["RethrowErrors"] == "true")
                {
                    throw ex;
                }
                data = null;
            }
            finally
            {
               // this._DBConn.Close();
            }
            
            return data;
        }

        public int ProjectInsert(Project project)
        {
            int projectId = 0;
            try
            {
                var sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "Project_Insert";
                sqlCmd.Connection = this._DBConn;
                sqlCmd.Parameters.AddWithValue("@portfolioId", project.portfolioId);
                sqlCmd.Parameters.AddWithValue("@title", project.title);
                sqlCmd.Parameters.AddWithValue("@description", (object)project.description ?? DBNull.Value);
                sqlCmd.Parameters.AddWithValue("@startDate", (object)project.startDate ?? DBNull.Value);
                sqlCmd.Parameters.AddWithValue("@endDate", (object)project.endDate ?? DBNull.Value);
                sqlCmd.Parameters.AddWithValue("@dateAdded", (object)project.dateAdded?? DateTime.Now);
                sqlCmd.Parameters.AddWithValue("@dateUpdated", (object)project.dateUpdated ?? DateTime.Now);
                sqlCmd.Parameters.AddWithValue("@otherDetails", (object)project.otherDetails ?? DBNull.Value);
                sqlCmd.Parameters.AddWithValue("@studentId", project.studentId);
                sqlCmd.Parameters.AddWithValue("@sectionId", project.sectionId);
                sqlCmd.Parameters.AddWithValue("@publicStatus", project.public_status ?? "VISIBLE");
                sqlCmd.Parameters.AddWithValue("@activeStatus", project.active_status ?? "ACTIVE");
                sqlCmd.Parameters.Add("@projectId", SqlDbType.Int).Direction = ParameterDirection.Output;

                if (this._DBConn.State == ConnectionState.Closed)          
                {
                    this._DBConn.Open();
                }
                sqlCmd.ExecuteNonQuery();
                projectId = Convert.ToInt32(sqlCmd.Parameters["@projectId"].Value);
                this._DBConn.Close();
            }
            catch (Exception ex)
            {

                if (ConfigurationManager.AppSettings["RethrowErrors"] == "true")
                {
                    throw ex;
                }
            }
            finally
            {
                //this._DBConn.Close();
            }
            return projectId;
        }

        public bool ProjectUpdate(Project project)
        {
            bool status = false;
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.CommandText = "Projects_Update";
                sqlCmd.Connection = this._DBConn;
                sqlCmd.Parameters.AddWithValue("@projectId", project.projectId);
                sqlCmd.Parameters.AddWithValue("@portfolioId", project.portfolioId);
                sqlCmd.Parameters.AddWithValue("@title", project.title);
                sqlCmd.Parameters.AddWithValue("@description", (object)project.description ?? DBNull.Value);
                sqlCmd.Parameters.AddWithValue("@startDate", (object)project.startDate ?? DBNull.Value);
                sqlCmd.Parameters.AddWithValue("@endDate", (object)project.endDate ?? DBNull.Value);
                sqlCmd.Parameters.AddWithValue("@dateUpdated", (object)project.dateUpdated ?? DateTime.Now);
                sqlCmd.Parameters.AddWithValue("@otherDetails", (object)project.otherDetails ?? DBNull.Value);
                sqlCmd.Parameters.AddWithValue("@studentId", project.studentId);
                sqlCmd.Parameters.AddWithValue("@sectionId", (object)project.sectionId?? DBNull.Value);
                sqlCmd.Parameters.AddWithValue("@public_status", project.public_status ?? "VISIBLE");
                sqlCmd.Parameters.AddWithValue("@active_status", project.active_status ?? "ACTIVE");
                if (this._DBConn.State == ConnectionState.Closed)
                {
                    this._DBConn.Open();
                }
                int numberOfRecordsAffected = sqlCmd.ExecuteNonQuery();
                if (numberOfRecordsAffected > 0)
                {
                    status = true;
                }
                this._DBConn.Close();
            }
            catch (Exception ex)
            {
                if (ConfigurationManager.AppSettings["RethrowErrors"] == "true") { throw ex; }
                status = false;
            }
            finally
            {
                //this._DBConn.Close();
            }
            return status;
        }
        #endregion
    }
}

