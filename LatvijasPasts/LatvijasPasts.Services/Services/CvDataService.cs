using LatvijasPasts.Services.IServices;
using LatvijasPastsCore.Models;
using LatvijasPastsData;
using Microsoft.EntityFrameworkCore;

namespace LatvijasPasts.Services.Services
{
    public class CvDataService : EntityService<CVData>, ICvDataService
    {
        public CvDataService(ILatvijasPastsDbContext dbContext) : base(dbContext)
        {
        }

        public bool CheckForDuplicates(CVData? cvData)
        {
            if (cvData == null)
            {
                return false; // If cvData is null, return false as there cannot be duplicates
            }

            return _dbContext.CVDatas.Any(data =>
                data.Name == cvData.Name &&
                data.Surname == cvData.Surname &&
                data.PhoneNumber == cvData.PhoneNumber &&
                data.EMail == cvData.EMail &&
                data.DateOfBirth == cvData.DateOfBirth &&
                data.AvatarUrl == cvData.AvatarUrl &&
                data.ColourUrl == cvData.ColourUrl &&
                (cvData.Educations == null || cvData.Educations.Count == 0 || (
                    data.Educations[0].School == cvData.Educations[0].School &&
                    data.Educations[0].Degree == cvData.Educations[0].Degree &&
                    data.Educations[0].GraduationDate == cvData.Educations[0].GraduationDate &&
                    data.Educations[0].City == cvData.Educations[0].City &&
                    data.Educations[0].Faculty == cvData.Educations[0].Faculty
                )) &&
                (cvData.Skills == null || cvData.Skills.Count == 0 || (
                    data.Skills[0].Skill == cvData.Skills[0].Skill
                )) &&
                (cvData.WorkExperiences == null || cvData.WorkExperiences.Count == 0 || (
                    data.WorkExperiences[0].Employer == cvData.WorkExperiences[0].Employer &&
                    data.WorkExperiences[0].JobTitle == cvData.WorkExperiences[0].JobTitle &&
                    data.WorkExperiences[0].StartDate == cvData.WorkExperiences[0].StartDate &&
                    data.WorkExperiences[0].EndDate == cvData.WorkExperiences[0].EndDate &&
                    data.WorkExperiences[0].City == cvData.WorkExperiences[0].City
                )) &&
                (cvData.Languages == null || cvData.Languages.Count == 0 || (
                    data.Languages[0].Language == cvData.Languages[0].Language &&
                    data.Languages[0].Speaking == cvData.Languages[0].Speaking &&
                    data.Languages[0].Writing == cvData.Languages[0].Writing
                )) &&
                (cvData.CurrentAddress == null || (
                    data.CurrentAddress.Country == cvData.CurrentAddress.Country &&
                    data.CurrentAddress.City == cvData.CurrentAddress.City &&
                    data.CurrentAddress.PostalIndex == cvData.CurrentAddress.PostalIndex &&
                    data.CurrentAddress.Street == cvData.CurrentAddress.Street
                ))
            );
        }


        public List<CVData> GetAllCvData()
        {
            return _dbContext.CVDatas
                .Include(data => data.CurrentAddress)
                .Include(data => data.Educations)
                .Include(data => data.WorkExperiences)
                .Include(data => data.Languages)
                .Include(data => data.Skills).ToList();
        }

        public CVData GetById(int id)
        {
            return _dbContext.CVDatas
                .Include(data => data.CurrentAddress)
                .Include(data => data.Educations)
                .Include(data => data.WorkExperiences)
                .Include(data => data.Languages)
                .Include(data => data.Skills)
                .SingleOrDefault(data => data.Id == id);
        }

        public bool Save()
        {
            var saved = _dbContext.SaveChanges();

            return saved > 0 ? true : false;
        }
    }
}
