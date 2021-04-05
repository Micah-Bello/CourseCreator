using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseCreator.Library.DataAccess
{
    public interface ISqlDataAccess
    {
        void CommitTransaction();
        Task<List<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName);
        Task<List<T>> LoadDataInTransaction<T, U>(string storedProcedure, U parameters);
        void RollbackTransaction();
        Task SaveData<T>(string storedProcedure, T parameters, string connectionStringName);
        Task SaveDataInTransaction<T>(string storedProcedure, T parameters);
        void StartTransaction(string connectionStringName);
    }
}