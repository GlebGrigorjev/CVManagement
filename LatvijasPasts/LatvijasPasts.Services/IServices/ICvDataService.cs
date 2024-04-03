using LatvijasPastsCore.Models;

namespace LatvijasPasts.Services.IServices
{
    public interface ICvDataService : IEntityService<CVData>
    {
        List<CVData> GetAllCvData();
        CVData GetById(int id);
        bool Save();
        public bool CheckForDuplicates(CVData? cvData);
    }
}
