using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public ActionResult<IEnumerable<Professor>> GetProfessores()
        {
            return _context.Professores;
        }

        //GET       api/professores/id
        [HttpGet("{id}")]
        public ActionResult<Professor> GetProfessor(int id)
        {
            var prof = _context.Professores.Find(id);
            if(prof == null)
            {
                return NotFound();
            }
            return prof;
        }

        //POST      api/professores
        [HttpPost]
        public ActionResult<Professor> CreateProfessor(Professor prof)
        {
            _context.Professores.Add(prof);
            _context.SaveChanges();
            return CreatedAtAction("GetProfessor",new Professor{Id = prof.Id}, prof);
        }

        //PUT       api/professores/id
        [HttpPut("{id}")]
        public ActionResult<Professor> UpdateProfessor(int id, Professor prof)
        {
            if(prof.Id != id)
            {
                return BadRequest();
            }

            _context.Entry(prof).State = EntityState.Modified;
            _context.SaveChanges();
            return NoContent();
        }

        //DELETE        api/professores/id
        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<Professor>> DeleteProfessor(int id)
        {
            var prof = _context.Professores.Find(id);
            if(prof == null)
            {
                return NotFound();
            }
            _context.Professores.Remove(prof);
            _context.SaveChanges();
            return _context.Professores;
        }
    }
}