using System.ComponentModel.DataAnnotations;

namespace CoursesAPI.Models
{
    public class Professor : Pessoa
    {
        public string Materia { get; set;}
    }
}