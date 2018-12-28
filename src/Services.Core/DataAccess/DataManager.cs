using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Core.DataAccess
{
    public class DataManager : IDataManager
    {
        public DataManager(string connectionString)
        {
            ConnectionString = connectionString;
            Initialize();
        }

        public string ConnectionString { get; private set; }

        protected Database Database { get; set; }

        public DbCommand GetCommand(string commandText)
        {
            return GetCommand(commandText, CommandType.StoredProcedure);
        }

        public DbCommand GetCommand(string commandText, CommandType commandType)
        {
            DbCommand cmd = null;
            switch (commandType)
            {
                case CommandType.StoredProcedure:
                    cmd = Database.GetStoredProcCommand(commandText);
                    cmd.CommandType = commandType;
                    break;
                case CommandType.Text:
                    cmd = Database.GetSqlStringCommand(commandText);
                    cmd.CommandType = commandType;
                    break;
            }
            return cmd;
        }

        public void AddParameter(DbCommand command, string parameterName, object parameterValue)
        {
            command.Parameters.Add(GetParameter(command, parameterName, parameterValue, true, null, null, null));
        }

        public void AddParameter(DbCommand command, string parameterName, object parameterValue, DbType type)
        {
            command.Parameters.Add(GetParameter(command, parameterName, parameterValue, true, type, null, ParameterDirection.Input));
        }

        public void AddParameter(DbCommand command, string parameterName, object parameterValue, DbType type, ParameterDirection direction)
        {
            command.Parameters.Add(GetParameter(command, parameterName, parameterValue, true, type, null, direction));
        }

        public void AddParameter(DbCommand command, string parameterName, object parameterValue, string typeName)
        {
            var parameter = GetParameter(command, parameterName, parameterValue, true, null, null, null);
            if (parameter is SqlParameter && !string.IsNullOrWhiteSpace(typeName))
            {
                var sqlParameter = parameter as SqlParameter;
                sqlParameter.SqlDbType = SqlDbType.Structured;
                sqlParameter.TypeName = typeName;
            }
            command.Parameters.Add(parameter);
        }

        public void AddReturnParameter(DbCommand command)
        {
            command.Parameters.Add(GetParameter(command, DataAccessConstants.ReturnValue, null, false, null, null, ParameterDirection.ReturnValue));
        }

        public void AddErrorCodeParameter(DbCommand command)
        {
            command.Parameters.Add(GetParameter(command, DataAccessConstants.ErrorCode, null, false, DbType.String, 120, ParameterDirection.Output));
        }
        public void AddErrorCodeParameter(DbCommand command, string parameterName)
        {
            command.Parameters.Add(GetParameter(command, parameterName, null, false, DbType.String, 120, ParameterDirection.Output));
        }

        public int GetReturnValue(DbCommand command)
        {
            if (command != null && command.Parameters.Contains(DataAccessConstants.ReturnValue) && command.Parameters[DataAccessConstants.ReturnValue].Value != DBNull.Value)
            {
                return (int)command.Parameters[DataAccessConstants.ReturnValue].Value;
            }
            return 0;
        }

        public string GetErrorCodeValue(DbCommand command)
        {
            return GetParameterValue<string>(command, DataAccessConstants.ErrorCode) ?? DataAccessConstants.None;
        }

        public T GetParameterValue<T>(DbCommand command, string parameterName)
        {
            if (command != null && command.Parameters.Contains(parameterName) && command.Parameters[parameterName].Value != DBNull.Value)
            {
                return (T)command.Parameters[parameterName].Value;
            }
            return default(T);
        }

        public DataSet ExecuteDataSet(DbCommand command)
        {
            return Database.ExecuteDataSet(command);
        }

        public DataTable ExecuteDataTable(DbCommand command)
        {
            var resultDataSet = Database.ExecuteDataSet(command);
            return resultDataSet != null && resultDataSet.Tables.Count > 0 ? resultDataSet.Tables[0] : new DataTable();
        }

        public async Task<DataTable> ExecuteDataTableAsync(DbCommand command)
        {
            using (var connection = Database.CreateConnection())
            {
                command.Connection = connection;
                await connection.OpenAsync();
                using (var reader = command.ExecuteReaderAsync())
                {
                    var resultDataTable = new DataTable();
                    resultDataTable.Load(await reader);
                    return resultDataTable;
                }
            }
        }

        public object ExecuteScalar(DbCommand command)
        {
            return Database.ExecuteScalar(command);
        }

        public async Task<object> ExecuteScalarAsync(DbCommand command)
        {
            return await command.ExecuteScalarAsync();
        }

        public int ExecuteNonQuery(DbCommand command)
        {
            return Database.ExecuteNonQuery(command);
        }

        public async Task<int> ExecuteNonQueryAsync(DbCommand command)
        {
            return await command.ExecuteNonQueryAsync();
        }

        protected DbParameter GetParameter(DbCommand command, string name, object value, bool setValue, DbType? dbType, int? size, ParameterDirection? direction)
        {
            var parameter = command.CreateParameter();
            parameter.ParameterName = name;
            if (setValue)
            {
                parameter.Value = value;
            }
            if (dbType.HasValue)
            {
                parameter.DbType = dbType.Value;
            }
            if (size.HasValue)
            {
                parameter.Size = size.Value;
            }
            if (direction.HasValue)
            {
                parameter.Direction = direction.Value;
            }
            return parameter;
        }

        protected void Initialize()
        {
            if (string.IsNullOrWhiteSpace(ConnectionString))
            {
                throw new ArgumentNullException(DataAccessConstants.ConnectionString);
            }
            else if (Database == null)
            {
                var factory = new DatabaseProviderFactory();
                Database = factory.Create(ConnectionString);
            }
        }

        public void AddPoErrorCodeParameter(DbCommand command)
        {
            command.Parameters.Add(GetParameter(command, DataAccessConstants.PoVarErrorCode, null, false, DbType.String, 120, ParameterDirection.Output));
        }

        public T GetOuputParameter<T>(DbCommand command, string parameterName)
        {
            if (command != null && command.Parameters.Contains(parameterName) && command.Parameters[parameterName].Value != DBNull.Value)
            {
                return (T)command.Parameters[parameterName].Value;
            }

            // Default value for int.
            return default(T);
        }
    }
}
