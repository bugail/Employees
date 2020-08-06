using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Employees.Infrastructure
{
    public abstract class RepositoryBase
    {
        private readonly string connectionString;

        public RepositoryBase(string connectionString)
        {
            this.connectionString = connectionString;       
        }

        /// <summary>
        /// Execute insert to database using dapper
        /// </summary>
        /// <param name="sql">Insert query</param>
        /// <param name="parameters">Insert query parameter</param>
        /// <returns></returns>
        public virtual async Task<int> AddAsync(string sql, object parameters)
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.ExecuteAsync(sql, parameters);
        }

        /// <summary>
        /// Executes query on database using dapper.
        /// </summary>
        /// <typeparam name="T">Type to return</typeparam>
        /// <param name="sql">Select query</param>
        /// <returns>Query results to type of T</returns>
        public virtual async Task<IEnumerable<T>> QueryAsync<T>(string sql)
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryAsync<T>(sql);
        }

        /// <summary>
        /// Execute store procedure using dapper
        /// </summary>
        /// <param name="procedure">Name of stored procedure</param>
        /// <param name="parameters">Store procedure parameters</param>
        /// <returns>The number of rows affected</returns>
        public virtual async Task<int> ExecuteStoreProcedureAsync(string procedure, object parameters)
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.ExecuteAsync(procedure, parameters, commandType: CommandType.StoredProcedure);
        }

        /// <summary>
        /// Execute query using dapper
        /// </summary>
        /// <typeparam name="T">Select query</typeparam>
        /// <param name="procedure">Select query parameters</param>
        /// <returns>Query results to type of T</returns>
        public virtual async Task<IEnumerable<T>> QueryStoreProcedureAsync<T>(string procedure)
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryAsync<T>(procedure, commandType: CommandType.StoredProcedure);
        }
    }
}
