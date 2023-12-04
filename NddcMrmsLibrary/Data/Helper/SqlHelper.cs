using NddcMrmsLibrary.Databases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NddcMrmsLibrary.Data.Helper
{
    public class SqlHelper : IHelperData
    {
        private readonly ISqlDataAccess db;

        private const string connectionStringName = "SqlDb";

        public SqlHelper(ISqlDataAccess db)
        {
            this.db = db;
        }

        public T GetAnyRecord<T, U>(string tableName, string returnFieldName, string parameterName, U paramValue)
        {
            string SQL = $"select {returnFieldName} from {tableName} where {parameterName} = @{parameterName}";

            return db.LoadData<T, dynamic>(SQL, new { Id = paramValue }, connectionStringName, false).First();

            //return (T)Convert.ChangeType(myValue, typeof(T));
        }
    }
}
