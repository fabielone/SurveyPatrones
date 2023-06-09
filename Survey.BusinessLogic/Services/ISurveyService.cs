using System.Collections.Generic;
using System.Threading.Tasks;
using Survey.API.Models;

namespace Survey.BusinessLogic.Services
{
    public interface ISurveyService
    {
        Task<IEnumerable<SurveyItem>> GetSurveysAsync();
        Task<SurveyItem> GetSurveyByIdAsync(int id);
        Task<SurveyItem> AddSurveyAsync(SurveyItem survey);
        Task<SurveyItem> UpdateSurveyAsync(SurveyItem survey);
        Task DeleteSurveyAsync(int id);
    }
}
