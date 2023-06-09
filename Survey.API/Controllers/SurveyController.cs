using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Survey.API.Models;
using Survey.BusinessLogic.Services;



namespace Survey.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SurveysController : ControllerBase
    {
        private readonly ISurveyService _surveyService;

        public SurveysController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SurveyItem>>> GetSurveys()
        {
            var surveys = await _surveyService.GetSurveysAsync();
            return Ok(surveys);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SurveyItem>> GetSurvey(int id)
        {
            var survey = await _surveyService.GetSurveyByIdAsync(id);
            if (survey == null)
            {
                return NotFound();
            }
            return Ok(survey);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSurvey(int id, SurveyItem survey)
        {
            if (id != survey.Id)
            {
                return BadRequest();
            }

            var updatedSurvey = await _surveyService.UpdateSurveyAsync(survey);
            if (updatedSurvey == null)
            {
                return NotFound();
            }

            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult<SurveyItem>> AddSurvey(SurveyItem survey)
        {
            var addedSurvey = await _surveyService.AddSurveyAsync(survey);
            return CreatedAtAction(nameof(GetSurvey), new { id = addedSurvey.Id }, addedSurvey);
        }

        

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSurvey(int id)
        {
            await _surveyService.DeleteSurveyAsync(id);
            return NoContent();
        }
    }
}
