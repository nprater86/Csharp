using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dojo_survey_with_model.Models;

namespace dojo_survey_with_model.Controllers;

public class SurveyController : Controller
{
    [HttpGet]
    [Route("")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("survey/post")]
    public IActionResult Submit(Survey survey)
    {
        if(ModelState.IsValid)
        {
            return RedirectToAction("Results", survey);
        }
        else
        {
            return View("Index");
        }
    }

    [HttpGet]
    [Route("result")]
    public IActionResult Results(Survey survey)
    {
        return View(survey);
    }
}
