using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CoursesAPI.Models;

namespace CoursesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly CoursesContext _context;

        public AlunosController(CoursesContext context) => _context = context;

        //GET       api/alunos
        
        [HttpGet]
        public ActionResult<IEnumerable<Aluno>> GetAlunos(){
            return _context.Alunos;
        }
    }
}