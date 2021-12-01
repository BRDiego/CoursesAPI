using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CoursesAPI.Models;
using Microsoft.EntityFrameworkCore;

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
        public ActionResult<IEnumerable<Aluno>> GetAlunos()
        {
            return _context.Alunos;
        }

        //GET       api/alunos/id
        [HttpGet("{id}")]
        public ActionResult<Aluno> GetAluno(int id)
        {
            var alunoItem = _context.Alunos.Find(id);
            if(alunoItem == null)
            {
                return NotFound();
            }
            return alunoItem;
        }

        //POST      api/alunos
        [HttpPost]
        public ActionResult<Aluno> CreateAluno(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            _context.SaveChanges();
            return CreatedAtAction("GetAluno", new Aluno{Id = aluno.Id}, aluno);
        }

        //PUT       api/alunos/id
        [HttpPut("{id}")]
        public ActionResult<Aluno> UpdateAluno(int id, Aluno aluno)
        {
            if(id != aluno.Id)
            {
                return BadRequest();
            }
            try
            {
                _context.Entry(aluno).State = EntityState.Modified;
                _context.SaveChanges();
                return NoContent();
            }
            catch(DbUpdateConcurrencyException)
            {
                return NotFound();
            }
        }

        //DELETE        api/alunos/id
        [HttpDelete("{id}")]
        public ActionResult<IEnumerable<Aluno>> DeleteAluno(int id)
        {
            var alunoItem = _context.Alunos.Find(id);
            if(alunoItem == null)
            {
                return NotFound();
            }
            _context.Alunos.Remove(alunoItem);
            _context.SaveChanges();
            return _context.Alunos;
        }

    }
}