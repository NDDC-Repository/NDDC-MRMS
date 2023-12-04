using NddcMrmsLibrary.Databases;
using NddcMrmsLibrary.Model.Lab;
using NddcMrmsLibrary.Model.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NddcMrmsLibrary.Data.LabData
{
    public class SQLLabs : ILabsData
    {
        private const string connectionStringName = "SqlDb";
        private readonly ISqlDataAccess db;

        public SQLLabs(ISqlDataAccess db)
        {
            this.db = db;
        }

        public List<MyLabModel> GetAllLabs()
        {
            string SQL = "SELECT ROW_NUMBER() OVER (ORDER BY Id DESC) As SrNo, Id, LabName, LabType, State, City, CompanyPhone, CompanyEmail, Approved From Laboratories";
            return db.LoadData<MyLabModel, dynamic>(SQL, new { }, connectionStringName, false).ToList();
        }
        public void ApproveLab(int Id)
        {
            db.SaveData<dynamic>("Update Laboratories Set Approved = 1 Where Id = @Id", new { Id }, connectionStringName, false);
        }
    }
}
