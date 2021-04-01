using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.Helpers
{
    public static class DbConnectionExtension
    {
        public static IEnumerable<T> QueryFunction<T>(this DbConnection connection, string functionName, object parameters)
        {
            var dynamicParameters = new DynamicParameters();

            foreach (var parameter in parameters.GetType().GetProperties())
                dynamicParameters.Add(parameter.Name, parameter.GetValue(parameters));

            return connection.Query<T>(functionName, dynamicParameters, commandType: CommandType.StoredProcedure);
        }
    }
}
