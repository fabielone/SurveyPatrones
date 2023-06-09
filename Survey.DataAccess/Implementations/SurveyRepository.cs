using Survey.API.Data;
using Survey.API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace Survey.DataAccess
{
    public class SurveyRepository : ISurveyRepository
    {
        private readonly SurveyDbContext _context;

        public SurveyRepository(SurveyDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<SurveyItem>> GetSurveysAsync()
        {
            return await _context.Surveys.ToListAsync();
        }

        public async Task<SurveyItem> GetSurveyByIdAsync(int id)
        {
            return await _context.Surveys.FindAsync(id);
        }

        public async Task<SurveyItem> AddSurveyAsync(SurveyItem survey)
        {
            _context.Surveys.Add(survey);
            await _context.SaveChangesAsync();
            return survey;
        }

        public async Task<SurveyItem> UpdateSurveyAsync(SurveyItem survey)
        {
            _context.Entry(survey).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return survey;
        }

        public async Task DeleteSurveyAsync(int id)
        {
            var survey = await _context.Surveys.FindAsync(id);
            if (survey != null)
            {
                _context.Surveys.Remove(survey);
                await _context.SaveChangesAsync();
            }
        }
    }
}
