using System;
using PortfolioBLDAL.Models;
using System.Configuration;
using PortfolioBLDAL.DataLayer;
using System.Data.SqlClient;

namespace PortfolioBLDAL.BusinessLayer
{
    public class ProjectBL
    {
        public static Project ProjectSelect(int projectId)
        {
            Project objProject = new Project();
            try
            {
                ProjectDAL projectSelect = new ProjectDAL();
                SqlDataReader reader = projectSelect.ProjectSelect(projectId);
                while (reader.Read())
                {
                    objProject = MapDataReaderProject(reader);
                }
                reader.Close();
            }
            catch (Exception ex)
            {

                if (ConfigurationManager.AppSettings["RethrowErrors"] == "true") { throw ex; }
            }
            return objProject;
        }

        /// <summary>
        /// Inserts a project
        /// </summary>
        /// <param name="project"></param>
        /// <returns>Project Id</returns>
        public static int ProjectInsert(Project project)
        {
            ProjectDAL projectInsert = new ProjectDAL();
            return projectInsert.ProjectInsert(project);
        }

        private static Project MapDataReaderProject(SqlDataReader reader)
        {
            Project project = new Project();
            if (!reader.IsDBNull(reader.GetOrdinal("projectId"))) project.projectId = reader.GetInt32(reader.GetOrdinal("projectId"));
            if (!reader.IsDBNull(reader.GetOrdinal("portfolioId"))) project.portfolioId = reader.GetInt32(reader.GetOrdinal("portfolioId"));
            if (!reader.IsDBNull(reader.GetOrdinal("title"))) project.title = reader.GetString(reader.GetOrdinal("title"));
            if (!reader.IsDBNull(reader.GetOrdinal("description"))) project.description = reader.GetString(reader.GetOrdinal("description"));
            if (!reader.IsDBNull(reader.GetOrdinal("startDate"))) project.startDate = reader.GetDateTime(reader.GetOrdinal("startDate"));
            if (!reader.IsDBNull(reader.GetOrdinal("endDate"))) project.endDate = reader.GetDateTime(reader.GetOrdinal("endDate"));
            if (!reader.IsDBNull(reader.GetOrdinal("dateAdded"))) project.dateAdded = reader.GetDateTime(reader.GetOrdinal("dateAdded"));
            if (!reader.IsDBNull(reader.GetOrdinal("dateUpdated"))) project.dateUpdated = reader.GetDateTime(reader.GetOrdinal("dateUpdated"));
            if (!reader.IsDBNull(reader.GetOrdinal("otherDetails"))) project.otherDetails = reader.GetString(reader.GetOrdinal("otherDetails"));
            if (!reader.IsDBNull(reader.GetOrdinal("studentId"))) project.studentId = reader.GetString(reader.GetOrdinal("studentId"));
            if (!reader.IsDBNull(reader.GetOrdinal("sectionId"))) project.sectionId = reader.GetString(reader.GetOrdinal("sectionId"));
            if (!reader.IsDBNull(reader.GetOrdinal("public_status"))) project.public_status = reader.GetString(reader.GetOrdinal("public_status"));
            if (!reader.IsDBNull(reader.GetOrdinal("active_status"))) project.active_status = reader.GetString(reader.GetOrdinal("active_status"));
            return project;
        }
    }
}
