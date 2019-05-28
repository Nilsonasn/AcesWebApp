using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Entities;

namespace TestCoreWebApp.Controllers
{
    public class AssignmentController : Controller
    {
        private AssignmentService _assignmentService;

        public AssignmentController(AssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }

        [Route("Assignments")]
        public IActionResult AssignmentHome()
        {
            var assignments = _assignmentService.GetAssignment();

            return View(assignments);
        }

        [Route("/postNewAssignment")]
        [HttpPost]
        public IActionResult PostNewAssignment([FromForm] Assignment assignment)
        {
            var assignments = _assignmentService.PostNewAssignment(assignment);

            return Ok(assignments);

        }
    }
}