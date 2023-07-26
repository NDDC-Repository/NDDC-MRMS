using NddcMrmsLibrary.Model.Lab;

namespace NddcMrmsLibrary.Data.LabData
{
    public interface ILabsData
    {
        List<MyLabModel> GetAllLabs();
    }
}