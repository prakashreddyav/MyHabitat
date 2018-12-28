using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace Services.Core.DataAccess
{
    public interface IDataManager
    {
        string ConnectionString { get; }

        DbCommand GetCommand(string commandText);

        DbCommand GetCommand(string commandText, CommandType commandType);

        void AddParameter(DbCommand command, string parameterName, object parameterValue);

        void AddParameter(DbCommand command, string parameterName, object parameterValue, DbType type);

        void AddParameter(DbCommand command, string parameterName, object parameterValue, DbType type, ParameterDirection direction);

        void AddParameter(DbCommand command, string parameterName, object parameterValue, string typeName);

        void AddReturnParameter(DbCommand command);

        void AddErrorCodeParameter(DbCommand command);

        void AddErrorCodeParameter(DbCommand command, string parameterName);

        int GetReturnValue(DbCommand command);

        string GetErrorCodeValue(DbCommand command);

        T GetParameterValue<T>(DbCommand command, string parameterName);

        DataSet ExecuteDataSet(DbCommand command);

        DataTable ExecuteDataTable(DbCommand command);

        Task<DataTable> ExecuteDataTableAsync(DbCommand command);

        object ExecuteScalar(DbCommand command);

        Task<object> ExecuteScalarAsync(DbCommand command);

        int ExecuteNonQuery(DbCommand command);

        Task<int> ExecuteNonQueryAsync(DbCommand command);

        void AddPoErrorCodeParameter(DbCommand command);

        T GetOuputParameter<T>(DbCommand command, string parameterName);
    }
}
