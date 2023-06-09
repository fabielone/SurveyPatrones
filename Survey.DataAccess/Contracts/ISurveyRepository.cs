// ISurveyRepository.cs
using Survey.API.Models;
namespace Survey.DataAccess;

public interface ISurveyRepository
{
    Task<IEnumerable<SurveyItem>> GetSurveysAsync();
    Task<SurveyItem> GetSurveyByIdAsync(int id);
    Task<SurveyItem> AddSurveyAsync(SurveyItem survey);
    Task<SurveyItem> UpdateSurveyAsync(SurveyItem survey);
    Task DeleteSurveyAsync(int id);
}


