using PortfolioBLDAL.DataLayer;
using PortfolioBLDAL.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioBLDAL.BusinessLayer
{
    public class ProjectTypeBL
    {

        public static IEnumerable<ProjectType> ProjectTypeSelect(int projectId)
        {
            List<ProjectType> projectTypes = new List<ProjectType>();
            try
            {
                ProjectTypeDAL projectTypeDal = new ProjectTypeDAL();
                SqlDataReader data = projectTypeDal.ProjectTypeSelect(projectId);
                while (data.Read())
                {
                    ProjectType type = new ProjectType();
                    type = MapDataReaderProjectType(data);
                    projectTypes.Add(type);
                }
            }
            catch (Exception ex)
            {

                if (ConfigurationManager.AppSettings["RethrowErrors"] == "true") { throw ex; }
                return new List<ProjectType>();
            }

            return projectTypes;
        }

        public static int ProjectTypeInsert(int projectId, int typeId)
        {
            ProjectTypeDAL dal = new ProjectTypeDAL();
            return dal.ProjectTypeInsert(projectId, typeId);
        }

        private static ProjectType MapDataReaderProjectType(SqlDataReader reader)
        {
            ProjectType type = new ProjectType();
            if (!reader.IsDBNull(reader.GetOrdinal("projectId"))) type.projectId = reader.GetInt32(reader.GetOrdinal("projectId"));
            if (!reader.IsDBNull(reader.GetOrdinal("typeId"))) type.typeId = reader.GetInt32(reader.GetOrdinal("typeId"));
            if (!reader.IsDBNull(reader.GetOrdinal("title"))) type.title = reader.GetString(reader.GetOrdinal("title"));
            if (!reader.IsDBNull(reader.GetOrdinal("description"))) type.description = reader.GetString(reader.GetOrdinal("description"));
            return type;
        }
    }
}
