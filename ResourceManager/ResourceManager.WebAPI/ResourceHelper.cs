using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ResourceManager.WebAPI.Models;

namespace ResourceManager.WebAPI
{
    public class ResourceHelper
    {
        public Resource UpsertResource(Resource resource, string connectionString)
        {
            var lstResource = new List<Resource>();
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("dbo.prc_UpsertResource", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add("@Name", SqlDbType.NVarChar).Value = resource.Name;
                command.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = resource.Phone;
                command.Parameters.Add("@BloodGroup", SqlDbType.NVarChar).Value = resource.BloodGroup;
                command.Parameters.Add("@Hierarchy", SqlDbType.NVarChar).Value = resource.Hierarchy;
                command.Parameters.Add("@Reserve1", SqlDbType.NVarChar).Value = resource.Reserve1;
                command.Parameters.Add("@Lat", SqlDbType.Float).Value = resource.Latitude;
                command.Parameters.Add("@Long", SqlDbType.Float).Value = resource.Longitude;
                connection.Open();
                var objSqlDataAdapter = new SqlDataAdapter(command);
                var dtResource = new DataTable();
                objSqlDataAdapter.Fill(dtResource);
                connection.Close();

                if (dtResource.Rows.Count > 0)
                {
                    lstResource.AddRange(from DataRow drRow in dtResource.Rows
                                         select new Resource
                                         {
                                             Name = drRow.IsNull("Name") ? null : drRow["Name"].ToString(),
                                             Phone = drRow.IsNull("Phone") ? null : drRow["Phone"].ToString(),
                                             BloodGroup = drRow.IsNull("BloodGroup") ? null : drRow["BloodGroup"].ToString(),
                                             Hierarchy = drRow.IsNull("Hierarchy") ? null : drRow["Hierarchy"].ToString(),
                                             Reserve1 = drRow.IsNull("Reserve1") ? null : drRow["Reserve1"].ToString(),
                                             Latitude = Convert.ToDouble(drRow["Lat"]),
                                             Longitude = Convert.ToDouble(drRow["Long"]),
                                             LastUpdated = Convert.ToDateTime(drRow["LastUpdated"])
                                         });
                }
                return lstResource.FirstOrDefault();
            }
        }

        public List<Resource> GetNearbyResources(float latitude, float longitude, float radius, string connectionString)
        {
            var lstResource = new List<Resource>();
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("dbo.prc_GetNearByResources", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.Add("@Lat", SqlDbType.Float).Value = latitude;
                command.Parameters.Add("@Long", SqlDbType.Float).Value = longitude;
                command.Parameters.Add("@radius", SqlDbType.Float).Value = radius;

                connection.Open();
                var objSqlDataAdapter = new SqlDataAdapter(command);
                var dtResource = new DataTable();
                objSqlDataAdapter.Fill(dtResource);
                connection.Close();

                if (dtResource.Rows.Count > 0)
                {
                    lstResource.AddRange(from DataRow drRow in dtResource.Rows
                                         select new Resource
                                         {
                                             Name = drRow.IsNull("Name") ? null : drRow["Name"].ToString(),
                                             Phone = drRow.IsNull("Phone") ? null : drRow["Phone"].ToString(),
                                             BloodGroup = drRow.IsNull("BloodGroup") ? null : drRow["BloodGroup"].ToString(),
                                             Hierarchy = drRow.IsNull("Hierarchy") ? null : drRow["Hierarchy"].ToString(),
                                             Reserve1 = drRow.IsNull("Reserve1") ? null : drRow["Reserve1"].ToString(),
                                             Latitude = Convert.ToDouble(drRow["Lat"]),
                                             Longitude = Convert.ToDouble(drRow["Long"]),
                                             LastUpdated = Convert.ToDateTime(drRow["LastUpdated"]),
                                             Distance = Convert.ToDouble(drRow["Distance"])
                                         });
                }
            }
            return lstResource;
        }
    }
}