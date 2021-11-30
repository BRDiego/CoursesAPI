using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CoursesAPI.Models;

namespace CoursesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessoresController : ControllerBase
    {
        private readonly CoursesContext _context;

        public ProfessoresController(CoursesContext context) => _context = context;

        //GET       api/professores
        
        [HttpGet]
        public ActionResult<IEnumerable<Professor>> GetProfessores(){
            return _context.Professores;
        }
    }
}