using Microsoft.EntityFrameworkCore;

namespace CoursesAPI.Models
{
    public class CoursesContext : DbContext
    {
        public CoursesContext(DbContextOptions<CoursesContext> options) :base(options)
        {
        }
        public DbSet<Aluno> Alunos { get; set;}
        public DbSet<Professor> Professores { get; set;}
    }
}