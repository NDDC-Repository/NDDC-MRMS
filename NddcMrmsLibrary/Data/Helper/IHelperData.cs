namespace NddcMrmsLibrary.Data.Helper
{
    public interface IHelperData
    {
        int GetAge(DateTime dateOfBirth);
        T GetAnyRecord<T, U>(string tableName, string returnFieldName, string parameterName, U paramValue);
    }
}