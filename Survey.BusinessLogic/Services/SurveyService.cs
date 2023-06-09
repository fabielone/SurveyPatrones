using System.Collections.Generic;
using System.Threading.Tasks;
using Survey.API.Models;
using Survey.DataAccess;

namespace Survey.BusinessLogic.Services
{
    public class SurveyService : ISurveyService
    {
        private readonly ISurveyRepository _surveyRepository;

        public SurveyService(ISurveyRepository surveyRepository)
        {
            _surveyRepository = surveyRepository;
        }

        public async Task<IEnumerable<SurveyItem>> GetSurveysAsync()
        {
            return await _surveyRepository.GetSurveysAsync();
        }

        public async Task<SurveyItem> GetSurveyByIdAsync(int id)
        {
            return await _surveyRepository.GetSurveyByIdAsync(id);
        }

        public async Task<SurveyItem> AddSurveyAsync(SurveyItem survey)
        {
            return await _surveyRepository.AddSurveyAsync(survey);
        }

        public async Task<SurveyItem> UpdateSurveyAsync(SurveyItem survey)
        {
            return await _surveyRepository.UpdateSurveyAsync(survey);
        }

        public async Task DeleteSurveyAsync(int id)
        {
            await _surveyRepository.DeleteSurveyAsync(id);
        }
    }
}
