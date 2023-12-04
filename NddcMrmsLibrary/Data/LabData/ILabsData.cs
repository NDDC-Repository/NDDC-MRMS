using NddcMrmsLibrary.Model.Lab;

namespace NddcMrmsLibrary.Data.LabData
{
    public interface ILabsData
    {
        void ApproveLab(int Id);
        List<MyLabModel> GetAllLabs();
    }
}